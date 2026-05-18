---
uid: tools-page-object-generator
title: Page object generator
---

# Page object generator

`Legerity.PageObjectGenerator` (command: `legerity-pop`) is a CLI tool that generates C# page object classes from your application's layout files. It parses XAML (Windows), AXML (Android), Storyboard/XIB (iOS), and HTML (Web) files, identifies UI elements with automation-friendly identifiers, and produces `BasePage`-derived classes with typed element properties and constructors.

This eliminates the tedious manual work of creating page objects for screens with many controls.

## Installation

Install as a .NET global tool:

```powershell
dotnet tool install -g Legerity.PageObjectGenerator
```

## Usage

```powershell
legerity-pop -i <input-folder> -o <output-folder> -n <namespace> -p <platform>
```

### Options

| Option | Description | Required |
|--------|-------------|----------|
| `-i`, `--input` | Path to the folder containing layout files (`.xaml`, `.axml`, `.storyboard`, `.xib`, `.html`, or `.htm`). | Yes |
| `-o`, `--output` | Path to the folder where generated `.cs` files are written. | Yes |
| `-n`, `--namespace` | The C# namespace for the generated classes. | Yes |
| `-p`, `--platform` | Target platform: `Windows`, `Android`, `IOS`, or `Web`. | Yes |

### Example

Generate page objects for a Windows XAML app:

```powershell
legerity-pop -i ./src/MyApp/Views -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p Windows
```

Generate page objects for an Android app:

```powershell
legerity-pop -i ./src/MyApp/Resources/layout -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p Android
```

Generate page objects for an iOS app:

```powershell
legerity-pop -i ./src/MyApp/Base.lproj -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p IOS
```

Generate page objects for a web app:

```powershell
legerity-pop -i ./src/MyApp/wwwroot -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p Web
```

## How it works

### Windows (XAML)

The generator scans `.xaml` files for elements that have one of:

- `AutomationProperties.AutomationId`
- `x:Name`
- `x:Uid`

For each identifiable element, it generates a property using the appropriate Legerity element wrapper and `WindowsByExtras.AutomationId()` as the locator.

**Input XAML:**

```xml
<Page x:Class="MyApp.Views.MainPage">
    <TextBox AutomationProperties.AutomationId="NameInput" />
    <ComboBox AutomationProperties.AutomationId="CountrySelector" />
    <Button AutomationProperties.AutomationId="SubmitButton" Content="Submit" />
    <DatePicker AutomationProperties.AutomationId="BirthDate" />
</Page>
```

**Generated C#:**

```csharp
namespace MyApp.UITests.Pages;

public class MainPage : BasePage
{
    public MainPage() { }

    public MainPage(WebDriver app) : base(app) { }

    protected override By Trait => WindowsByExtras.AutomationId("NameInput");

    public TextBox NameInput =>
        FindElement(WindowsByExtras.AutomationId("NameInput"));

    public ComboBox CountrySelector =>
        FindElement(WindowsByExtras.AutomationId("CountrySelector"));

    public Button SubmitButton =>
        FindElement(WindowsByExtras.AutomationId("SubmitButton"));

    public DatePicker BirthDate =>
        FindElement(WindowsByExtras.AutomationId("BirthDate"));
}
```

### Android (AXML)

The generator scans `.axml` files for elements with:

- `android:id` (`@+id/name`)
- `android:contentDescription`

For each identifiable element, it generates a property using the appropriate Legerity Android element wrapper.

**Input AXML:**

```xml
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android">
    <EditText android:id="@+id/nameInput" />
    <Spinner android:id="@+id/categorySpinner" />
    <Button android:id="@+id/submitButton" />
    <DatePicker android:id="@+id/birthDate" />
</LinearLayout>
```

**Generated C#:**

```csharp
namespace MyApp.UITests.Pages;

public class FormInputLayout : BasePage
{
    public FormInputLayout() { }

    public FormInputLayout(WebDriver app) : base(app) { }

    protected override By Trait => By.Id("nameInput");

    public EditText NameInput =>
        FindElement(By.Id("nameInput"));

    public Spinner CategorySpinner =>
        FindElement(By.Id("categorySpinner"));

    public Button SubmitButton =>
        FindElement(By.Id("submitButton"));

    public DatePicker BirthDate =>
        FindElement(By.Id("birthDate"));
}
```

## Supported control mappings

The generator maps layout element types to Legerity wrappers:

### Windows

| XAML element | Legerity wrapper |
|-------------|-----------------|
| `TextBox` | `TextBox` |
| `PasswordBox` | `PasswordBox` |
| `ComboBox` | `ComboBox` |
| `Button` | `Button` |
| `CheckBox` | `CheckBox` |
| `RadioButton` | `RadioButton` |
| `Slider` | `Slider` |
| `DatePicker` | `DatePicker` |
| `TimePicker` | `TimePicker` |
| `ToggleSwitch` | `ToggleSwitch` |
| `ListView` | `ListView` |
| `TextBlock` | `TextBlock` |
| Other core controls | `WindowsElementWrapper` |

#### WinUI controls

When WinUI controls are detected in a XAML page, the generator automatically maps them to WinUI-specific wrappers and adds the required `using Legerity.Windows.Elements.WinUI` directive.

| XAML element | Legerity wrapper |
|-------------|-----------------|
| `InfoBar` | `InfoBar` |
| `MenuBar` | `MenuBar` |
| `MenuBarItem` | `MenuBarItem` |
| `NavigationView` | `NavigationView` |
| `NavigationViewItem` | `NavigationViewItem` |
| `NumberBox` | `NumberBox` |
| `RatingControl` | `RatingControl` |
| `TabView` | `TabView` |

### Android

| AXML element | Legerity wrapper |
|-------------|-----------------|
| `EditText` | `EditText` |
| `Spinner` | `Spinner` |
| `Button` | `Button` |
| `CheckBox` | `CheckBox` |
| `RadioButton` | `RadioButton` |
| `Switch` | `Switch` |
| `DatePicker` | `DatePicker` |
| `ToggleButton` | `ToggleButton` |
| `TextView` | `TextView` |
| `View` | `View` |
| Other views | `AndroidElementWrapper` |

### iOS (Storyboard / XIB)

The generator scans `.storyboard` and `.xib` files for elements with:

- `accessibilityIdentifier`
- `label` or `text` attributes

For each identifiable element, it generates a property using the appropriate Legerity iOS element wrapper. Accessibility identifiers use `By.Name()` as the locator (standard Appium mapping), while label/text attributes use `IOSByExtras.Label()`.

| Storyboard element | Legerity wrapper |
|-------------|-----------------|
| `button` | `Button` |
| `label` | `Label` |
| `textField` | `TextField` |
| `slider` | `Slider` |
| `switch` | `Switch` |
| `progressView` | `ProgressView` |
| Other elements | `IOSElementWrapper` |

### Web (HTML)

The generator scans `.html` and `.htm` files for elements with:

- `id`
- `name`
- `data-testid`

For each identifiable element, it generates a property using the appropriate Legerity Web element wrapper. The locator strategy follows priority order: `id` uses `By.Id()`, `name` uses `By.Name()`, and `data-testid` uses `By.CssSelector()`.

| HTML element | Legerity wrapper |
|-------------|-----------------|
| `<button>` | `Button` |
| `<input type="text/email/password/search/tel/url">` | `TextInput` |
| `<input type="checkbox">` | `CheckBox` |
| `<input type="radio">` | `RadioButton` |
| `<input type="number">` | `NumberInput` |
| `<input type="range">` | `RangeInput` |
| `<input type="date">` | `DateInput` |
| `<input type="file">` | `FileInput` |
| `<select>` | `Select` |
| `<textarea>` | `TextArea` |
| `<img>` | `Image` |
| `<table>` | `Table` |
| `<form>` | `Form` |
| `<ul>`, `<ol>` | `List` |
| Other elements | `WebElementWrapper` |

## Limitations

- **Custom controls** are generated with the platform's base wrapper type (e.g., `WindowsElementWrapper`, `AndroidElementWrapper`). You'll need to manually update these to your custom wrapper types.
- **Generated code is a starting point.** The generator creates element properties but not interaction methods. Add `Login()`, `Submit()`, and other behavioral methods manually.
- **Web HTML parsing** identifies elements by `id`, `name`, or `data-testid` attributes. Elements without these attributes are skipped.
- **iOS Storyboard/XIB parsing** relies on `accessibilityIdentifier`, `label`, or `text` attributes. Set accessibility identifiers on your iOS controls for best results.

## Best practices

- **Run the generator early in your project** to get a head start on page objects, then maintain them manually as your app evolves.
- **Set identifiers on every interactive control.** Use `AutomationProperties.AutomationId` (Windows), `android:id` (Android), `accessibilityIdentifier` (iOS), or `id`/`data-testid` (Web).
- **Review and customize the generated `Trait` property.** The generator picks the first identifiable element, which may not be the best indicator that the page is loaded.
- **Add interaction methods after generation.** The generator creates the element properties; you add the behavioral methods that combine them into meaningful user actions.
