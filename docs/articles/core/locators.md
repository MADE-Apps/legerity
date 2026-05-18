---
uid: core-locators
title: Locators
---

# Locators

Locators are how you find elements in your application's UI tree. Selenium provides the standard set (`By.Id`, `By.ClassName`, `By.XPath`, `By.CssSelector`, etc.), and Legerity extends these with additional locator types and a fluent chaining API that makes complex queries readable.

## Standard Selenium locators

These work everywhere and are your starting point:

```csharp
app.FindElement(By.Id("submitButton"));
app.FindElement(By.ClassName("menu-item"));
app.FindElement(By.TagName("button"));
app.FindElement(By.CssSelector("input[type='email']"));
app.FindElement(By.XPath("//div[@role='dialog']//button"));
app.FindElement(By.Name("username"));
```

## ByExtras: cross-platform locators

[`ByExtras`](xref:Legerity.ByExtras) provides locators that work across all platforms:

### Text matching

Find elements by their visible text content:

```csharp
// Exact text match
var heading = app.FindElement(ByExtras.Text("Welcome back"));

// Partial text match
var link = app.FindElement(ByExtras.PartialText("Learn more"));
```

> [!NOTE]
> Text-based locators search all elements on the page. If multiple elements share the same text, you may get unexpected results. Combine with other locators for precision.

## ByAll: intersection matching

[`ByAll`](xref:Legerity.ByAll) finds elements that match **all** of the provided locators. This is useful when a single locator isn't specific enough:

```csharp
// Find a button that has the text "Submit"
var submit = app.FindElement(new ByAll(By.TagName("button"), ByExtras.Text("Submit")));

// Find an input with a specific class
var emailInput = app.FindElement(new ByAll(By.TagName("input"), By.ClassName("email-field")));
```

`ByAll` finds all elements matching the first locator, then filters to only those that also match every subsequent locator. The result is the intersection.

## ByNested: sequential nesting

[`ByNested`](xref:Legerity.ByNested) finds elements by navigating a sequence of parent-child relationships:

```csharp
// Find a button inside a form inside a specific container
var button = app.FindElement(new ByNested(
    By.Id("PersonContainer"),
    By.TagName("form"),
    By.TagName("button")));
```

Each locator in the sequence scopes the search to children of the previous match. The nesting doesn't need to be direct; intermediate elements are fine. You could also find the same button with:

```csharp
var button = app.FindElement(new ByNested(By.Id("PersonContainer"), By.TagName("button")));
```

## Fluent chaining API

The fluent API is the recommended way to compose locator queries in v1.0. It provides extension methods on `By` that read naturally and eliminate the need to construct `ByAll` and `ByNested` instances manually.

### Simple shortcuts

These extend any `By` locator with filtering and scoping:

```csharp
// Filter by text (equivalent to ByAll with ByExtras.Text)
app.FindElement(By.TagName("button").WithText("Accept"));
app.FindElement(By.TagName("span").WithPartialText("error"));

// Filter by attribute
app.FindElement(By.TagName("input").WithAttribute("type", "email"));
app.FindElement(By.ClassName("card").WithPartialAttribute("data-id", "user-"));

// Combine locators (equivalent to ByAll)
app.FindElement(By.TagName("button").And(By.ClassName("primary")));

// Scope into children (equivalent to ByNested)
app.FindElements(By.Id("results").ThenFind(By.ClassName("result-item")));
```

### Builder API

For complex queries with multiple constraints, the builder API provides a structured approach:

**Same-element constraints** with `.That()`:

```csharp
// Find an input that is both type="email" and required
app.FindElement(By.TagName("input")
    .That(by => by
        .HasAttribute("type", "email")
        .HasAttribute("required", "true")));
```

**Scoped child search** with `.ThenFind()`:

```csharp
// Find radio inputs inside a form
app.FindElements(By.TagName("form")
    .ThenFind(by => by
        .TagName("input")
        .HasAttribute("type", "radio")));
```

Builder methods available inside `.That()` and `.ThenFind()`:

| Method | Description |
|--------|-------------|
| `.TagName(tag)` | Match by HTML/UI tag name. |
| `.Id(id)` | Match by element ID. |
| `.ClassName(name)` | Match by CSS class or UI class name. |
| `.CssSelector(selector)` | Match by CSS selector. |
| `.XPath(xpath)` | Match by XPath expression. |
| `.Name(name)` | Match by name attribute. |
| `.HasText(text)` | Filter by exact text content. |
| `.HasPartialText(text)` | Filter by partial text content. |
| `.HasAttribute(name, value)` | Filter by exact attribute value. |
| `.HasPartialAttribute(name, value)` | Filter by partial attribute value. |
| `.Matching(By)` | Filter by an arbitrary `By` locator. |

### Comparison with manual construction

The fluent API is syntactic sugar over `ByAll` and `ByNested`. These are equivalent:

```csharp
// Manual construction
page.FindElement(new ByAll(By.TagName("button"), ByExtras.Text("Accept")));
page.FindElements(new ByNested(By.TagName("form"), By.XPath("//input[@type='radio']")));

// Fluent shortcuts
page.FindElement(By.TagName("button").WithText("Accept"));
page.FindElements(By.TagName("form").ThenFind(By.XPath("//input[@type='radio']")));

// Fluent builder
page.FindElement(By.TagName("form")
    .ThenFind(by => by.TagName("input").HasAttribute("type", "radio")));
```

Use whichever style is clearest for your query. The fluent API shines for multi-constraint queries that would be verbose with manual construction.

## Platform-specific locators

Each platform package adds locators for platform-native identification strategies.

### Windows

[`WindowsByExtras`](xref:Legerity.Windows.WindowsByExtras) provides:

```csharp
// Find by AutomationId (the primary Windows element identifier)
app.FindElement(WindowsByExtras.AutomationId("SubmitButton"));
```

Fluent extensions:

```csharp
app.FindElement(By.ClassName("Button").WithAutomationId("Submit"));
app.FindElement(By.Id("form").ThenFindByAutomationId("SubmitButton"));
app.FindElement(By.TagName("input").That(by => by.HasAutomationId("EmailField")));
```

### Android

[`AndroidByExtras`](xref:Legerity.Android.AndroidByExtras) provides:

```csharp
// Find by content description (accessibility label)
app.FindElement(AndroidByExtras.ContentDescription("Submit button"));
app.FindElement(AndroidByExtras.PartialContentDescription("Submit"));
```

Fluent extensions:

```csharp
app.FindElement(By.ClassName("Button").WithContentDescription("Submit"));
app.FindElement(By.TagName("EditText")
    .That(by => by.HasContentDescription("Email field")));
```

### iOS

[`IOSByExtras`](xref:Legerity.IOS.IOSByExtras) provides:

```csharp
// Find by accessibility label
app.FindElement(IOSByExtras.Label("Submit"));
app.FindElement(IOSByExtras.PartialLabel("Sub"));

// Find by value
app.FindElement(IOSByExtras.Value("50"));
app.FindElement(IOSByExtras.PartialValue("%"));
```

Fluent extensions:

```csharp
app.FindElement(By.ClassName("XCUIElementTypeButton").WithLabel("Submit"));
app.FindElement(By.ClassName("XCUIElementTypeSlider")
    .That(by => by.HasValue("75")));
```

### Web

[`WebByExtras`](xref:Legerity.Web.WebByExtras) provides:

```csharp
// Find input elements by type
app.FindElement(WebByExtras.InputType("email"));
app.FindElement(WebByExtras.InputType("password"));
```

Fluent extensions:

```csharp
app.FindElement(By.TagName("form").ThenFindByInputType("email"));
app.FindElements(By.Id("dropdown").ThenFindOptions());
app.FindElements(By.TagName("ul").ThenFindListItems());
app.FindElements(By.TagName("table").ThenFindTableRows());
```

## Best practices

- **Prefer stable identifiers over positional locators.** `By.Id`, `AutomationId`, and `data-testid` attributes are resilient to layout changes. XPath with positional indexes (`div[3]/span[2]`) breaks when the DOM structure changes.
- **Use the fluent API for multi-constraint queries.** It's more readable than nested `ByAll`/`ByNested` constructors.
- **Scope searches with `ThenFind`.** Instead of a global XPath, find the parent container first and then search within it. This is faster and less fragile.
- **Use platform-specific locators where available.** `AutomationId` on Windows and `contentDescription` on Android are designed for test automation and are more reliable than generic locators.
- **Text-based locators are a last resort.** They're fragile across locales and break when copy changes. Use them only when no structural identifier is available.
