---
uid: using_legerity_wait_conditions
title: Wait Conditions
---

# Wait conditions

When you are writing UI tests, you will often need to wait for a specific condition to be met before continuing with your test.

Selenium, by default, provide mechanisms to do this using your application driver. However, the approach to implementing them requires you to write a lot of boilerplate code to wait for a condition to be met.

Legerity provides a set of extensions for the application driver, [page objects](xref:using_legerity_page_objects), and [element wrappers](xref:using_legerity_element_wrappers) that you can use to easily wait for a condition to be met. In addition, we have custom defined wait conditions that you can use with these methods to make the process even easier.

## Wait for a condition to be met

When you want to wait for a condition to be met on an application driver, [page object](xref:using_legerity_page_objects), or [element wrapper](xref:using_legerity_element_wrappers), you can use the `WaitUntil` or `TryWaitUntil` extension methods.

These method takes in a condition delegate that returns a boolean value indicating whether the condition has been met. Depending on the object being extended, the delegate will provide you with the instance of it so you can perform your condition check.

 It also has optional parameters for a timeout and the number of retries to attempt before accepting the condition has not been met.

> [!NOTE]
> If the timeout is not configured, the condition will be checked immediately, and if it fails, the method will fail, throwing an exception.

```csharp
[Test]
public void ShouldWaitForConditionToBeMetOnAppDriver()
{
    this.App.WaitUntil(
        driver => driver.Title == "Bing",
        TimeSpan.FromSeconds(5),
        3);
}

[Test]
public void ShouldWaitForConditionToBeMetOnPageObject()
{
    new HomePage(this.App).WaitUntil(
        page => page.SearchBox.Displayed,
        TimeSpan.FromSeconds(5),
        3);
}

[Test]
public void ShouldWaitForConditionToBeMetOnElementWrapper()
{
    var inputText = "Hello, World";

    TextBox input = this.App.FindElement(By.Id("input"));
    input.SetText(inputText);

    input.WaitUntil(
        element => element.Text == inputText,
        TimeSpan.FromSeconds(5),
        3);
}
```

## Using Legerity wait conditions

Legerity provides a set of [custom wait conditions](xref:Legerity.Helpers.WaitUntilConditions) that you can use with the `WaitUntil` and `TryWaitUntil` extension methods.

These conditions are designed to make it easier to wait for a specific condition to be met, such as checking the title of the app, checking the URL, or checking if elements exist.

### Checking if the driver title is correct

You can use the `WaitUntilConditions.TitleIs` or `WaitUntilConditions.TitleContains` conditions to wait for the driver title to be the expected value.

```csharp
[Test]
public void ShouldWaitForTitleToBeCorrect()
{
    this.App.WaitUntil(
        WaitUntilConditions.TitleIs("Bing"),
        TimeSpan.FromSeconds(5),
        3);
}

[Test]
public void ShouldWaitForTitleToContainText()
{
    this.App.WaitUntil(
        WaitUntilConditions.TitleContains("Bing"),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking if the driver URL is correct

You can use the `WaitUntilConditions.UrlIs` or `WaitUntilConditions.UrlContains` conditions to wait for the driver URL to be the expected value.

```csharp
[Test]
public void ShouldWaitForUrlToBeCorrect()
{
    this.App.WaitUntil(
        WaitUntilConditions.UrlIs("https://www.bing.com/"),
        TimeSpan.FromSeconds(5),
        3);
}

[Test]
public void ShouldWaitForUrlToContainText()
{
    this.App.WaitUntil(
        WaitUntilConditions.UrlContains("bing.com"),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking if an element exists with a specific locator for a driver

You can use the `WaitUntilConditions.ElementExists` condition to wait for an element to exist with a specific locator.

```csharp
[Test]
public void ShouldWaitForElementToExist()
{
    this.App.WaitUntil(
        WaitUntilConditions.ElementExists(By.Id("input")),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking if an element exists with a specific locator for a page object

You can use the `WaitUntilConditions.ElementExistsInPage` condition to wait for an element to exist with a specific locator.

```csharp
[Test]
public void ShouldWaitForElementToExistInPage()
{
    new HomePage(this.App).WaitUntil(
        WaitUntilConditions.ElementExistsInPage<HomePage>(By.Id("input")),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking is an element is visible with a specific locator for a driver

You can use the `WaitUntilConditions.ElementIsVisible` condition to wait for an element to be visible with a specific locator.

```csharp
[Test]
public void ShouldWaitForElementToBeVisible()
{
    this.App.WaitUntil(
        WaitUntilConditions.ElementIsVisible(By.Id("input")),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking is an element is visible with a specific locator for a page object

You can use the `WaitUntilConditions.ElementIsVisibleInPage` condition to wait for an element to be visible with a specific locator.

```csharp
[Test]
public void ShouldWaitForElementToBeVisibleInPage()
{
    new HomePage(this.App).WaitUntil(
        WaitUntilConditions.ElementIsVisibleInPage<HomePage>(By.Id("input")),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking is an element is not visible with a specific locator for a driver

You can use the `WaitUntilConditions.ElementIsNotVisible` condition to wait for an element to be hidden (not visible) with a specific locator.

```csharp
[Test]
public void ShouldWaitForElementToNotBeVisible()
{
    this.App.WaitUntil(
        WaitUntilConditions.ElementIsNotVisible(By.Id("input")),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking is an element is not visible with a specific locator for a page object

You can use the `WaitUntilConditions.ElementIsNotVisibleInPage` condition to wait for an element to be hidden (not visible) with a specific locator.

```csharp
[Test]
public void ShouldWaitForElementToNotBeVisibleInPage()
{
    new HomePage(this.App).WaitUntil(
        WaitUntilConditions.ElementIsNotVisibleInPage<HomePage>(By.Id("input")),
        TimeSpan.FromSeconds(5),
        3);
}
```

### Checking a frame is available and switching to it

You can use the `WaitUntilConditions.FrameAvailableToSwitchTo` condition to wait for a frame in the driver to be available and switch to it.

```csharp
[Test]
public void ShouldWaitForFrameToBeAvailable()
{
    // By frame name
    this.App.WaitUntil(
        WaitUntilConditions.FrameAvailableToSwitchTo("frame"),
        TimeSpan.FromSeconds(5),
        3);

    // By frame locator
    this.App.WaitUntil(
        WaitUntilConditions.FrameAvailableToSwitchTo(By.Id("frame")),
        TimeSpan.FromSeconds(5),
        3);
}
```
