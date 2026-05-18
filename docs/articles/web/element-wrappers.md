---
uid: web-element-wrappers
title: Web - Element wrappers
---

# Web element wrappers

`Legerity.Web` provides typed wrappers for standard HTML form controls. Each wrapper extends [`WebElementWrapper`](xref:Legerity.Web.Elements.WebElementWrapper) and adds properties and methods specific to the HTML element it represents.

All web wrappers use implicit operators, so you can assign the result of `FindElement` directly to the wrapper type:

```csharp
TextInput email = app.FindElement(By.Id("email"));
Select country = app.FindElement(By.Id("country"));
CheckBox terms = app.FindElement(By.Id("acceptTerms"));
```

## TextInput

Wraps `<input type="text">`, `<input type="email">`, `<input type="password">`, and similar text-based inputs.

```csharp
TextInput email = app.FindElement(By.Id("email"));

// Read the current value
string currentText = email.Text;

// Set text (clears existing content first)
email.SetText("user@example.com");

// Append text to existing content
email.AppendText(" additional text");

// Clear the field
email.ClearText();
```

## TextArea

Wraps `<textarea>` elements. Same API as `TextInput`:

```csharp
TextArea comments = app.FindElement(By.Id("comments"));
comments.SetText("This is my feedback.");
string value = comments.Text;
```

## NumberInput

Wraps `<input type="number">`. Provides numeric-aware interactions:

```csharp
NumberInput quantity = app.FindElement(By.Id("quantity"));
quantity.SetText("5");
string value = quantity.Text;
```

## DateInput

Wraps `<input type="date">`:

```csharp
DateInput birthDate = app.FindElement(By.Id("dob"));
birthDate.SetDate(new DateTime(1990, 6, 15));
```

## Select

Wraps `<select>` elements with single and multi-select support:

```csharp
Select country = app.FindElement(By.Id("country"));

// Check if multi-select
bool isMultiple = country.IsMultiple;

// Get all available options
IReadOnlyCollection<Option> options = country.Options;

// Get currently selected option(s)
Option selected = country.SelectedOption;
IReadOnlyCollection<Option> allSelected = country.SelectedOptions;

// Select by visible text
country.SelectOptionByDisplayValue("United Kingdom");
```

## Option

Wraps individual `<option>` elements within a `<select>`:

```csharp
Option firstOption = app.FindElement(By.CssSelector("select#country option:first-child"));
string text = firstOption.Text;
bool isSelected = firstOption.Selected;
```

## CheckBox

Wraps `<input type="checkbox">`:

```csharp
CheckBox terms = app.FindElement(By.Id("acceptTerms"));
bool isChecked = terms.IsChecked;

terms.Check();    // Ensures checked
terms.Uncheck();  // Ensures unchecked
```

## RadioButton

Wraps `<input type="radio">`:

```csharp
RadioButton option = app.FindElement(By.Id("optionA"));
bool isSelected = option.IsSelected;
option.Click();
```

## Button

Wraps `<button>` and `<input type="button">`:

```csharp
Button submit = app.FindElement(By.Id("submit"));
submit.Click();
bool isEnabled = submit.IsEnabled;
```

## FileInput

Wraps `<input type="file">` for file upload:

```csharp
FileInput upload = app.FindElement(By.Id("fileUpload"));
upload.SetFilePath(@"C:\Documents\report.pdf");
```

## RangeInput

Wraps `<input type="range">` (slider):

```csharp
RangeInput volume = app.FindElement(By.Id("volume"));
volume.SetValue(75);
```

## Image

Wraps `<img>` elements:

```csharp
Image logo = app.FindElement(By.Id("logo"));
string src = logo.Source;
string alt = logo.AltText;
```

## List

Wraps `<ul>` and `<ol>` elements:

```csharp
List navMenu = app.FindElement(By.Id("mainNav"));
IReadOnlyCollection<WebElement> items = navMenu.Items;
int count = navMenu.Items.Count;
```

## Table

Wraps `<table>` elements:

```csharp
Table dataTable = app.FindElement(By.Id("results"));
IReadOnlyCollection<TableRow> rows = dataTable.Rows;
IReadOnlyCollection<WebElement> headers = dataTable.Headers;
```

## TableRow

Wraps `<tr>` elements:

```csharp
TableRow firstRow = app.FindElement(By.CssSelector("table#results tr:first-child"));
IReadOnlyCollection<WebElement> cells = firstRow.Cells;
```

## Form

Wraps `<form>` elements:

```csharp
Form loginForm = app.FindElement(By.Id("loginForm"));
loginForm.Submit();
```

## WebElementWrapper base

All web wrappers inherit from `WebElementWrapper`, which provides:

| Member | Description |
|--------|-------------|
| `Element` | The underlying `WebElement`. |
| `ElementDriver` | The `WebDriver` instance. |
| `Driver` | Typed `WebDriver` reference. |
| `IsVisible` | Whether the element is displayed. |
| `IsEnabled` | Whether the element is interactive. |
| `Click()` | Click the element. |
| `GetAttribute(name)` | Read an HTML attribute. |
| `FindElement(locator)` | Find a child element. |
| `FindElements(locator)` | Find all matching child elements. |

## Creating custom web wrappers

For components not covered by the built-in wrappers (e.g., custom dropdown menus, modal dialogs, card components), create your own by extending `WebElementWrapper`:

```csharp
public class DropdownMenu : WebElementWrapper
{
    public DropdownMenu(WebElement element) : base(element) { }

    public static implicit operator DropdownMenu(WebElement e) => new(e);

    public bool IsOpen => FindElement(By.ClassName("dropdown-content")).Displayed;

    public IReadOnlyCollection<WebElement> MenuItems =>
        FindElements(By.ClassName("dropdown-item"));

    public void Open()
    {
        if (!IsOpen) FindElement(By.ClassName("dropdown-trigger")).Click();
    }

    public void SelectItem(string text)
    {
        Open();
        FindElements(By.ClassName("dropdown-item"))
            .First(item => item.Text == text)
            .Click();
    }
}
```

For more details on creating custom wrappers, see [Element wrappers](xref:core-element-wrappers).
