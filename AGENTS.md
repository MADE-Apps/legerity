# AGENTS.md

## Architecture

Legerity is a .NET UI test framework, wrapping Selenium WebDriver and Appium, to provide a simplified interaction model across platforms (Windows, Android, iOS, Web).

The codebase has three layers:

1. **Core** (`src/Legerity.Core/`) - Platform-agnostic abstractions: `BasePage`, `ElementWrapper<T>`, `AppManager`, locator strategies (`ByAll`, `ByNested`, `ByBuilder`). All platform libraries depend on this.
2. **Platform libraries** (`src/Legerity.{Windows,Android,IOS,Web,WinUI}/`) - Platform-specific element wrappers and extensions. Each wraps the corresponding Appium or Selenium driver.
3. **Meta-package** (`src/Legerity/`) - Aggregates all platform libraries via `ProjectReference`. Ships as a convenience NuGet package.

Supporting projects:

- `tools/Legerity.PageObjectGenerator/` - CLI tool (`legerity-pop`) that generates page objects from XAML/HTML.
- `tools/Legerity.Templates/` - `dotnet new` templates for test projects.
- `tools/Legerity.WindowsDriver/` - W3C WebDriver server for Windows applications, published as self-contained executables (win-x64, win-arm64).

## Build and Test

```bash
# Build
dotnet build src/Legerity.sln --configuration Release

# Run tests
dotnet test src/Legerity.sln --configuration Release

# Pack NuGet packages (auto-generated on build via GeneratePackageOnBuild)
dotnet build src/Legerity.sln --configuration Release

# Publish WindowsDriver
dotnet publish tools/Legerity.WindowsDriver/Legerity.WindowsDriver.csproj --configuration Release --runtime win-x64 -p:PublishSingleFile=true --self-contained
```

Versioning is derived from git tags (`v*`) via `build/GetBuildVersion.psm1`. NuGet publish is triggered only by pushing a `v*` tag to `main`.

## Development Workflow

When working on a task in this repository, follow these steps in order:

1. **Orient** - Read this file and the relevant source under `src/` or `tests/` to understand the area you are changing. Identify which layer (Core, Platform, Meta-package, Tools) the change belongs to.
2. **Branch** - Create a feature branch from `main`. Never commit directly to `main`.
3. **Implement** - Make the code changes. Keep changes scoped to the layer they belong in. If touching Core, verify no platform-specific dependencies leak in.
4. **Add/Update docs** - Add or update XML documentation on any public API you added or changed, update READMEs if necessary, confirm `docs/` are relevant and up-to-date. 
5. **Write/update tests** - Add tests in the corresponding `tests/` project. Use `Shouldly` for assertions. Inherit from `LegerityTestClass` if app lifecycle is needed, otherwise use plain `[TestFixture]`.
6. **Build** - Run `dotnet build src/Legerity.sln --configuration Release` and fix all errors (including missing XML doc warnings).
7. **Test** - Run tests scoped to the projects you changed, not the full solution. These are real UI tests and take time to run. Use `dotnet test <test-project-path> --configuration Release` targeting only the relevant test project(s). If you changed a specific element or its tests (e.g., `FlipView`), filter further with `--filter "FullyQualifiedName~FlipView"` to run only those tests. Only run the full `dotnet test src/Legerity.sln` if changes span multiple layers.
8. **Commit and push** - Commit with a clear message, push the branch. Do not use `--no-verify`.
9. **Open PR** - Open a pull request targeting `main`. CI will build and test automatically.

## Guidelines

### Must Never

- **Never add direct NuGet package references to `Legerity.Core` for test frameworks** (NUnit, xUnit, MSTest). Core is test-framework-agnostic by design. Test framework dependencies belong only in `tests/` projects via `tests/Directory.Build.props`.
- **Never reference platform-specific types in `Legerity.Core`**. Platform abstractions flow through `ElementWrapper<T>` and `BasePage` generics. Core uses namespace-scoped folders (`Android/`, `IOS/`, `Web/`, `Windows/`) for platform helpers but must not take hard dependencies on platform driver packages.
- **Never bypass `AppManager` to create driver instances directly in tests**. `AppManager` manages driver lifecycle, async-local context for parallel execution, and cleanup. Direct driver construction breaks test isolation.
- **Never remove or weaken `WeakReference` usage in `ElementWrapper<T>`**. Element lifecycle is intentionally weak-referenced to avoid holding stale Appium elements after page navigation.
- **Never add projects outside the solution file**. All `src/`, `tests/`, and `tools/` projects must be registered in `src/Legerity.sln`.
- **Never commit to `main` directly**. All changes go through GitHub pull requests. CI runs on PRs targeting `main`.
- **Never use `--no-verify` or skip CI checks** when pushing. The CI pipeline gates NuGet publishing.
- **Never hardcode driver versions in library projects**. ChromeDriver and similar test-time drivers are pinned in test `.csproj` files only, not in shipped libraries.

### Must Always

- **Always maintain the `BasePage.Trait` contract**. Every page object must define a `Trait` property that uniquely identifies the page. This is the verification mechanism for page load assertions.
- **Always use implicit operators on `ElementWrapper<T>` subclasses** to enable transparent conversion between raw elements and wrappers. This is the primary API ergonomics pattern.
- **Always add XML documentation to public APIs**. `GenerateDocumentationFile` is enabled in `src/Directory.Build.props`; undocumented public members will produce build warnings.
- **Always target `net10.0`** for all projects. Multi-targeting is not used.
- **Always include a `README.md` in each NuGet project directory**. It is packed into the NuGet package via `Directory.Build.props`.
- **Always run scoped tests before submitting a PR**. CI runs `dotnet test` on `windows-latest`.
- **Always use `ByExtras`, `ByAll`, or `ByNested` for complex element lookups** instead of raw `By` chains. These composable locator strategies are the intended API surface.

## Conventions

- **Assertion library**: Tests use `Shouldly`, not NUnit's built-in `Assert`.
- **Test base class**: Test classes that need app lifecycle management inherit from `LegerityTestClass`. Standalone unit tests (e.g., locator strategy tests) use plain NUnit `[TestFixture]`.
- **Element wrapper naming**: Platform wrappers follow `{ControlName}` naming (e.g., `TextBox`, `ComboBox`), not `{ControlName}Wrapper`. The generic base is `ElementWrapper<T>`.
- **Platform extension classes**: Each platform has a `{Platform}ByExtras` class (e.g., `WindowsByExtras`, `WebByExtras`) for platform-specific locator strategies.
- **EditorConfig enforced**: See `.editorconfig` for full rules.
- **Modifier ordering**: `public,private,protected,internal,static,extern,new,virtual,abstract,sealed,override,readonly,unsafe,volatile,async`.

## CI/CD

Three GitHub Actions workflows in `.github/workflows/`:

| Workflow | Trigger Paths | Purpose |
|----------|--------------|---------|
| `ci.yml` | `src/**`, `tests/**`, `build/**`, `tools/**` | Build + test; publish NuGet on `v*` tags |
| `docs.yml` | `docs/**` | Build DocFX site, deploy to GitHub Pages |
| `windows-driver.yml` | `tools/Legerity.WindowsDriver/**` | Build driver executables; create GitHub Release on `v*` tags |

NuGet packages are published to nuget.org using the `NUGET_API_KEY` secret. The publish step uses `--skip-duplicate` for idempotence.

## Dependencies to Understand

- **Appium.WebDriver 8.2.0** - The primary driver abstraction. All element interactions flow through Appium's `AppiumElement` type.
- **Selenium.WebDriver** - Transitive via Appium. `Legerity.Web` elements work with Selenium's `IWebDriver` and `IWebElement`.
- **SourceLink** - Enabled for all packages to support source-level debugging from NuGet.
