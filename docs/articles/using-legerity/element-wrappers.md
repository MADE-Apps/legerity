---
uid: using_legerity_element_wrappers
title: Element Wrappers
---

# Element wrappers

Element wrappers are a unique feature of Legerity that allow you to "wrap" an application driver element with a custom class that mimics the functionality and exposed properties of the actual UI element. As they are a wrapper, they also expose the original `RemoteWebElement` that they are wrapping so you can still access the underlying functionality.

This makes it much easier for you to find your elements in your tests and interact with them, without having to worry about the underlying implementation of the UI element.

And because element wrappers start their life as a `RemoteWebElement` created from an application driver instance, the wrapper instance will always be in sync with the creating driver.

Legerity provides a set of core element wrappers for Windows, Android, iOS, and the Web, but you can also create your own custom element wrappers for your own custom controls. They have a base type, [`ElementWrapper`](xref:Legerity.ElementWrapper`1), that provides a set of common functionality that can be used across all of your elements.

You can discover the platform specific element wrappers in the API references for each platform:

- [Android](xref:Legerity.Android.Elements.Core)
- [iOS](xref:Legerity.IOS.Elements.Core)
- [Windows](xref:Legerity.Windows.Elements.Core)
  - [WinUI](xref:Legerity.Windows.Elements.WinUI)
  - [Windows Community Toolkit](xref:Legerity.Windows.Elements.WCT)
  - [Telerik UI for UWP](xref:Legerity.Windows.Elements.Telerik)
  - [MADE.NET UI](xref:Legerity.Windows.Elements.MADE)
- [Web](xref:Legerity.Web.Elements.Core)

## Finding elements with element wrappers

If you're familiar with the methods for finding elements with an application driver, you'll know exactly how to find them with an element wrapper.

Each element wrapper has been created using [implicit operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators) that allow you to find elements and simply cast them to the element wrapper type.

For this example, we'll use the [`Slider`](xref:Legerity.Windows.Elements.Core.Slider) element wrapper from the Windows platform.

```csharp
Slider slider = app.FindElement(By.Id("MySlider"));
```

We use the `FindElement` method on the application driver to find an element. By default, this would return a `RemoteWebElement` or platform alternative.

However, we can assign this to a `Button` element wrapper instead, which will allow us to access all of the additional functionality that is exposed by `Button`.

## Interacting with elements

Once you have found an element, you can interact with it using the exposed properties and methods.

We'll continue with our example using the `Slider` element, and see how we can use the element wrapper to make selecting a value on the slider easier.

```csharp
Slider slider = app.FindElement(By.Id("MySlider"));
slider.SetValue(3);
```

Here's what that would look like if we didn't use the element wrapper:

```csharp
RemoteWebElement slider = app.FindElement(By.Id("MySlider"));
slider.Click(); // Select the element for interaction
var currentSliderValue = double.Parse(slider.GetAttribute("RangeValue.Value"));
while(Math.Abs(currentSliderValue - 3) > double.Epsilon)
{
    slider.SendKeys(currentSliderValue < 3 ? Keys.ArrowRight : Keys.ArrowLeft);
    currentSliderValue = double.Parse(slider.GetAttribute("RangeValue.Value"));
}
```

> [!NOTE]
> The actual `Slider` implementation for setting the value also takes into account the minimum and maximum values of the slider. This is not shown in the example above which would make the implementation more complex.

As you can see, the element wrapper makes it much easier to interact with the element, and also makes the code much more maintainable and readable.

## Finding elements withing element wrappers

Element wrappers also expose a `FindElement` method that allows you to find elements within the element wrapper. This is a common scenario where you have a complex UI element that contains other elements.

By taking advantage of element wrappers, those elements within elements can also be wrapped with element wrappers, making it easier to find and interact with them too.

```csharp
Slider slider = app.FindElement(By.Id("MySlider"));
SliderThumb thumb = slider.FindElement(By.ClassName("SliderThumb"));
```

## Creating custom element wrappers

You can create your own custom element wrappers for your own custom controls. This is done by creating a class that inherits from an element wrapper base type or another custom element wrapper.

Your core element wrapper base types are:

- [`ElementWrapper`](xref:Legerity.ElementWrapper`1)
- [`AndroidElementWrapper`](xref:Legerity.Android.Elements.AndroidElementWrapper)
- [`IOSElementWrapper`](xref:Legerity.IOS.Elements.IOSElementWrapper)
- [`WindowsElementWrapper`](xref:Legerity.Windows.Elements.WindowsElementWrapper)
- [`WebElementWrapper`](xref:Legerity.Web.Elements.WebElementWrapper)

Using one of these base types will allow you to inherit the functionality of the base type for that platform, and hooks into all the additional features offered by Legerity to support `ElementWrapper` types.

For example, if you wanted to create a custom element wrapper for a custom control on the Windows platform, you would create a class that inherits from `WindowsElementWrapper`.

Here's an example of a custom element wrapper for a text box control that exposes the text value with the ability to set it.

```csharp
public class TextBox : WindowsElementWrapper
{
    public TextBox(RemoteWebElement element)
        : base(element)
    {
    }

    public virtual string Text => this.Element.GetAttribute("Value.Value");

    public static implicit operator TextBox(WindowsElement element)
    {
        return new TextBox(element);
    }

    public static implicit operator TextBox(AppiumWebElement element)
    {
        return new TextBox(element as WindowsElement);
    }

    public void SetText(string text)
    {
        this.Click();
        this.Element.Clear();
        this.Element.SendKeys(text);
    }
}
```

This custom element wrapper can then be used in your tests in the same way as the built-in element wrappers.

```csharp
TextBox textBox = app.FindElement(By.Id("MyTextBox"));
textBox.SetText("Hello World!");
```
