---
uid: core-wait-conditions
title: Wait conditions
---

# Wait conditions

UI tests frequently need to wait for something to happen before proceeding: a page to load, an element to appear, a spinner to disappear, a URL to change. Raw Selenium provides `WebDriverWait` for this, but the API requires boilerplate setup every time you use it.

Legerity provides `WaitUntil` and `TryWaitUntil` extension methods on drivers, page objects, and element wrappers, plus a library of pre-built condition functions that cover the most common scenarios.

## WaitUntil and TryWaitUntil

Both methods take a condition delegate, an optional timeout, and an optional retry count. The difference is in failure behavior:

- **`WaitUntil`** throws an exception if the condition isn't met within the timeout.
- **`TryWaitUntil`** returns `false` if the condition isn't met, without throwing.

### On a driver

```csharp
// Wait for the page title to change
app.WaitUntil(
    driver => driver.Title == "Dashboard",
    TimeSpan.FromSeconds(5),
    retries: 3);

// Check without throwing
bool loaded = app.TryWaitUntil(
    driver => driver.FindElement(By.Id("content")).Displayed,
    TimeSpan.FromSeconds(5));
```

### On a page object

```csharp
var homePage = new HomePage();
homePage.WaitUntil(
    page => page.SearchBox.Displayed,
    TimeSpan.FromSeconds(5));
```

### On an element wrapper

```csharp
TextInput searchBox = app.FindElement(By.Id("search"));
searchBox.SetText("Legerity");

searchBox.WaitUntil(
    element => element.Text == "Legerity",
    TimeSpan.FromSeconds(3));
```

### Parameters

| Parameter | Description | Default |
|-----------|-------------|---------|
| `condition` | A delegate that returns `true` when the condition is met. Receives the target object (driver, page, or element). | Required |
| `timeout` | How long to wait before giving up. | `null` (immediate check) |
| `retries` | How many times to retry the full wait cycle if it fails. | `0` |

> [!NOTE]
> If you omit the timeout, the condition is evaluated once immediately. If it fails, the method either throws (`WaitUntil`) or returns `false` (`TryWaitUntil`). Always provide a timeout when waiting for asynchronous UI changes.

## Pre-built wait conditions

[`WaitUntilConditions`](xref:Legerity.Helpers.WaitUntilConditions) provides ready-to-use condition functions for common scenarios. These are designed to be passed directly to `WaitUntil` and `TryWaitUntil`.

### Title conditions

Wait for the browser or application title to match:

```csharp
// Exact title match
app.WaitUntil(WaitUntilConditions.TitleIs("Dashboard"), TimeSpan.FromSeconds(5));

// Partial title match
app.WaitUntil(WaitUntilConditions.TitleContains("Dash"), TimeSpan.FromSeconds(5));
```

### URL conditions

Wait for the browser URL to change (useful after navigation or redirects):

```csharp
// Exact URL match
app.WaitUntil(WaitUntilConditions.UrlIs("https://myapp.com/dashboard"), TimeSpan.FromSeconds(5));

// Partial URL match
app.WaitUntil(WaitUntilConditions.UrlContains("/dashboard"), TimeSpan.FromSeconds(5));
```

### Element exists

Wait for an element to exist in the DOM (it may or may not be visible):

```csharp
// On a driver
app.WaitUntil(WaitUntilConditions.ElementExists(By.Id("results")), TimeSpan.FromSeconds(5));

// On a page object
page.WaitUntil(
    WaitUntilConditions.ElementExistsInPage<SearchResultsPage>(By.Id("results")),
    TimeSpan.FromSeconds(5));

// On an element wrapper
wrapper.WaitUntil(
    WaitUntilConditions.ElementExistsInElementWrapper<TextInput>(By.ClassName("suggestion")),
    TimeSpan.FromSeconds(3));
```

### Element visible

Wait for an element to be both present and visible:

```csharp
// On a driver
app.WaitUntil(WaitUntilConditions.ElementIsVisible(By.Id("modal")), TimeSpan.FromSeconds(5));

// On a page object
page.WaitUntil(
    WaitUntilConditions.ElementIsVisibleInPage<HomePage>(By.Id("welcomeBanner")),
    TimeSpan.FromSeconds(5));
```

### Element not visible

Wait for an element to disappear (useful for loading spinners and overlays):

```csharp
// On a driver
app.WaitUntil(
    WaitUntilConditions.ElementIsNotVisible(By.Id("loadingSpinner")),
    TimeSpan.FromSeconds(10));

// On a page object
page.WaitUntil(
    WaitUntilConditions.ElementIsNotVisibleInPage<DashboardPage>(By.ClassName("overlay")),
    TimeSpan.FromSeconds(10));
```

## Complete conditions reference

| Condition | Scope | Description |
|-----------|-------|-------------|
| `TitleIs(title)` | Driver | Title equals the given string. |
| `TitleContains(text)` | Driver | Title contains the given substring. |
| `UrlIs(url)` | Driver | URL equals the given string. |
| `UrlContains(text)` | Driver | URL contains the given substring. |
| `ElementExists(locator)` | Driver | Element is present in the DOM. |
| `ElementExistsInElement<T>(locator)` | Element | Child element exists within an element. |
| `ElementExistsInElementWrapper<T>(locator)` | Element wrapper | Child element exists within a wrapper. |
| `ElementExistsInPage<T>(locator)` | Page object | Element exists within a page. |
| `ElementIsVisible(locator)` | Driver | Element is present and visible. |
| `ElementIsVisibleInElement<T>(locator)` | Element | Child element is visible within an element. |
| `ElementIsVisibleInElementWrapper<T>(locator)` | Element wrapper | Child element is visible within a wrapper. |
| `ElementIsVisibleInPage<T>(locator)` | Page object | Element is visible within a page. |
| `ElementIsNotVisible(locator)` | Driver | Element is not visible (or not present). |
| `ElementIsNotVisibleInElement<T>(locator)` | Element | Child element is not visible within an element. |
| `ElementIsNotVisibleInElementWrapper<T>(locator)` | Element wrapper | Child element is not visible within a wrapper. |
| `ElementIsNotVisibleInPage<T>(locator)` | Page object | Element is not visible within a page. |

## Custom conditions

You can write any condition inline:

```csharp
// Wait for a list to have at least 5 items
app.WaitUntil(
    driver => driver.FindElements(By.ClassName("result-item")).Count >= 5,
    TimeSpan.FromSeconds(10));

// Wait for a specific element wrapper state
TextInput input = app.FindElement(By.Id("email"));
input.WaitUntil(
    el => el.Text.Contains("@") && el.Text.Contains("."),
    TimeSpan.FromSeconds(5));
```

## Best practices

- **Always provide a timeout for async waits.** Without a timeout, the condition is checked once and immediately fails if not met.
- **Use `TryWaitUntil` for optional conditions.** If the element might not appear (e.g., a conditional tooltip), use `TryWaitUntil` to avoid exceptions.
- **Wait for elements to disappear before proceeding.** Loading spinners, overlays, and toasts can interfere with subsequent interactions. Use `ElementIsNotVisible` to wait for them to clear.
- **Prefer built-in conditions over inline delegates.** They're tested, handle edge cases, and make your intent clear.
- **Set reasonable timeouts.** 5-10 seconds covers most UI transitions. Longer timeouts (15-30 seconds) are appropriate for initial page loads or network-dependent operations. Avoid very short timeouts (<1 second) that cause flaky tests.
