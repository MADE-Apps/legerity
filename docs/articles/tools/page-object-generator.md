---
uid: tools-page-object-generator
title: Page object generator
---

# Page object generator

`Legerity.PageObjectGenerator` (command: `legerity-pop`) is a CLI tool that generates C# page object classes from your application's layout files. It parses XAML (Windows) and AXML (Android) files, identifies UI elements with automation-friendly identifiers, and produces `BasePage`-derived classes with typed element properties.

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
| `-i`, `--input` | Path to the folder containing layout files (`.xaml` or `.axml`). | Yes |
| `-o`, `--output` | Path to the folder where generated `.cs` files are written. | Yes |
| `-n`, `--namespace` | The C# namespace for the generated classes. | Yes |
| `-p`, `--platform` | Target platform: `Windows` or `Android`. | Yes |

### Example

Generate page objects for a Windows XAML app:

```powershell
legerity-pop -i ./src/MyApp/Views -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p Windows
```

Generate page objects for an Android app:

```powershell
legerity-pop -i ./src/MyApp/Resources/layout -o ./tests/MyApp.UITests/Pages -n MyApp.UITests.Pages -p Android
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
    protected override By Trait => WindowsByExtras.AutomationId("NameInput");

    public TextBox NameInput =>
        App.FindElement(WindowsByExtras.AutomationId("NameInput"));

    public ComboBox CountrySelector =>
        App.FindElement(WindowsByExtras.AutomationId("CountrySelector"));

    public Button SubmitButton =>
        App.FindElement(WindowsByExtras.AutomationId("SubmitButton"));

    public DatePicker BirthDate =>
        App.FindElement(WindowsByExtras.AutomationId("BirthDate"));
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
    protected override By Trait => By.Id("nameInput");

    public EditText NameInput =>
        App.FindElement(By.Id("nameInput"));

    public Spinner CategorySpinner =>
        App.FindElement(By.Id("categorySpinner"));

    public Button SubmitButton =>
        App.FindElement(By.Id("submitButton"));

    public DatePicker BirthDate =>
        App.FindElement(By.Id("birthDate"));
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
| Other controls | `WebElement` (raw) |

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
| Other views | `WebElement` (raw) |

## Limitations

- **iOS and Web are not currently supported.** iOS apps don't use declarative layout files that can be easily parsed. Web apps use HTML which has a different structure.
- **Custom controls** are generated with raw `WebElement` types. You'll need to manually update these to your custom wrapper types.
- **Generated code is a starting point.** The generator creates element properties but not interaction methods. Add `Login()`, `Submit()`, and other behavioral methods manually.

## Best practices

- **Run the generator early in your project** to get a head start on page objects, then maintain them manually as your app evolves.
- **Set `AutomationProperties.AutomationId`** (Windows) or `android:id` (Android) on every interactive control in your app. These are what the generator uses to create element properties.
- **Review and customize the generated `Trait` property.** The generator picks the first identifiable element, which may not be the best indicator that the page is loaded.
- **Add interaction methods after generation.** The generator creates the element properties; you add the behavioral methods that combine them into meaningful user actions.
