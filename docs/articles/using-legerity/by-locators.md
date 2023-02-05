---
uid: using_legerity_by_locators
title: By Locators
---

# By locators

Locators are a fundamental page of automated UI testing, allow you to find elements within your application using a variety of different strategies, such as XPath, CSS selectors, or accessibility identifiers.

Built on top of the capabilities of Selenium, Legerity provides a set of extra common and platform specific `By` locators that you can use to find elements within your application.

You can find more information about the available locators in the following API references:

- [Common By locators](xref:Legerity.ByExtras)
- [Windows By locators](xref:Legerity.Windows.WindowsByExtras)
- [iOS By locators](xref:Legerity.IOS.IOSByExtras)
- [Android By locators](xref:Legerity.Android.AndroidByExtras)
- [Web By locators](xref:Legerity.Web.WebByExtras)
- [By All locator](xref:Legerity.ByAll)

## Finding elements that match all locators

The `ByAll` locator allows you to find elements that match all of the provided locators. This is useful when you want to find an element that matches multiple criteria, such as a button that has a specific text.

```csharp
RemoteWebElement element = app.FindElement(new ByAll(By.TagName("button"), ByExtras.Text("Send Message")));
```

## Finding elements by text

The Core package provides `ByExtras.Text` and `ByExtras.PartialText` locators that can be used to find elements on the page by their text content. These can be used across any app platform!

```csharp
RemoteWebElement element1 = app.FindElement(ByExtras.Text("My text"));
RemoteWebElement element2 = app.FindElement(ByExtras.PartialText("text"));
```

> [!NOTE]
> These locators should only be used when you are sure that the text you are searching for is unique on the page. If there are multiple elements with the same text, you may get unexpected results.

## Finding elements by label on iOS

The iOS package provides `ByExtras.Label` and `ByExtras.PartialLabel` locators that can be used to find elements on the page by their label content for iOS applications.

```csharp
RemoteWebElement element1 = app.FindElement(ByExtras.Label("My label"));
RemoteWebElement element2 = app.FindElement(ByExtras.PartialLabel("label"));
```

## Finding elements by content description on Android

The Android package provides `ByExtras.ContentDescription` and `ByExtras.PartialContentDescription` locators that can be used to find elements on the page by their content description for Android applications. This is particularly useful for certain elements that put their text content in the content description.

```csharp
RemoteWebElement element1 = app.FindElement(ByExtras.ContentDescription("My content description"));
RemoteWebElement element2 = app.FindElement(ByExtras.PartialContentDescription("description"));
```

## Finding elements by value on iOS

There are occasions where you may want to find an element by its value, such as a text field or a slider. The iOS package provides `ByExtras.Value` and `ByExtras.PartialValue` locators that can be used to find elements on the page by their value content for iOS applications.

```csharp
RemoteWebElement element1 = app.FindElement(ByExtras.Value("50"));
RemoteWebElement element2 = app.FindElement(ByExtras.PartialValue("%"));
```

## Finding web `Input` element by type

Finding elements by their type is a common requirement when testing web applications. The Web package provides `ByExtras.InputType` locators that can be used to find input elements on the page by their type, such as `email` or `password`.

```csharp
RemoteWebElement emailElement = app.FindElement(ByExtras.InputType("email"));
RemoteWebElement passwordElement = app.FindElement(ByExtras.InputType("password"));
```

## Finding Windows elements by `AutomationId`

Windows UI elements often have a unique `AutomationId` property that can be used to identify elements on the page. The Windows package provides `ByExtras.AutomationId` locators that can be used to find elements on the page by this property.

```csharp
RemoteWebElement element = app.FindElement(ByExtras.AutomationId("MyAutomationId"));
```

> [!NOTE]
> This locator exists due to the way that the Windows Application Driver works when finding elements by ID.
