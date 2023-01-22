namespace Legerity.Windows.Extensions
{
    using System;
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a collection of extensions for retrieving element attributes.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Retrieves the AutomationId attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve an AutomationId from.</param>
        /// <returns>The AutomationId of the element.</returns>
        public static string GetAutomationId(this IWebElement element)
        {
            return element.GetAttribute("AutomationId");
        }

        /// <summary>
        /// Retrieves the AutomationId attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve an AutomationId from.</param>
        /// <returns>The AutomationId of the element.</returns>
        public static string GetAutomationId<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetAutomationId(element.Element);
        }

        /// <summary>
        /// Retrieves the HelpText attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the HelpText from.</param>
        /// <returns>The HelpText of the element.</returns>
        public static string GetHelpText(this IWebElement element)
        {
            return element.GetAttribute("HelpText");
        }

        /// <summary>
        /// Retrieves the HelpText attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the HelpText from.</param>
        /// <returns>The HelpText of the element.</returns>
        public static string GetHelpText<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetHelpText(element.Element);
        }

        /// <summary>
        /// Retrieves the Value.Value attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve a value from.</param>
        /// <returns>The value of the element.</returns>
        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("Value.Value");
        }

        /// <summary>
        /// Retrieves the Value.Value attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a value from.</param>
        /// <returns>The value of the element.</returns>
        public static string GetValue<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetValue(element.Element);
        }

        /// <summary>
        /// Retrieves the Value.IsReadonly attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the readonly state from.</param>
        /// <returns>A value indicating whether the item is readonly.</returns>
        public static bool IsReadonly(this IWebElement element)
        {
            return element.GetAttribute("Value.IsReadOnly").Equals("True", StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Retrieves the Value.IsReadonly attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the readonly state from.</param>
        /// <returns>A value indicating whether the item is readonly.</returns>
        public static bool IsReadonly<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return IsReadonly(element.Element);
        }

        /// <summary>
        /// Retrieves the Toggle.ToggleState attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve a toggle state from.</param>
        /// <returns>The <see cref="ToggleState"/> of the element.</returns>
        public static ToggleState GetToggleState(this IWebElement element)
        {
            return element.GetAttribute("Toggle.ToggleState") switch
            {
                "1" => ToggleState.Checked,
                "2" => ToggleState.Indeterminate,
                _ => ToggleState.Unchecked
            };
        }

        /// <summary>
        /// Retrieves the Toggle.ToggleState attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve a toggle state from.</param>
        /// <returns>The <see cref="ToggleState"/> of the element.</returns>
        public static ToggleState GetToggleState<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetToggleState(element.Element);
        }

        /// <summary>
        /// Retrieves the SelectionItem.IsSelected attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the selected state from.</param>
        /// <returns>A value indicating whether the item is selected.</returns>
        public static bool IsSelected(this IWebElement element)
        {
            return element.GetAttribute("SelectionItem.IsSelected")
                .Equals("True", StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Retrieves the SelectionItem.IsSelected attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the selected state from.</param>
        /// <returns>A value indicating whether the item is selected.</returns>
        public static bool IsSelected<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return IsSelected(element.Element);
        }

        /// <summary>
        /// Retrieves the RangeValue.Value attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the range value from.</param>
        /// <returns>The range value of the element.</returns>
        public static double GetRangeValue(this IWebElement element)
        {
            return double.Parse(element.GetAttribute("RangeValue.Value"));
        }

        /// <summary>
        /// Retrieves the RangeValue.Value attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the range value from.</param>
        /// <returns>The range value of the element.</returns>
        public static double GetRangeValue<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetRangeValue(element.Element);
        }

        /// <summary>
        /// Retrieves the RangeValue.Maximum attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the range max value from.</param>
        /// <returns>The range max value of the element.</returns>
        public static double GetRangeMaximum(this IWebElement element)
        {
            return double.Parse(element.GetAttribute("RangeValue.Maximum"));
        }

        /// <summary>
        /// Retrieves the RangeValue.Maximum attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the range max value from.</param>
        /// <returns>The range max value of the element.</returns>
        public static double GetRangeMaximum<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetRangeMaximum(element.Element);
        }

        /// <summary>
        /// Retrieves the RangeValue.Minimum attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the range min value from.</param>
        /// <returns>The range min value of the element.</returns>
        public static double GetRangeMinimum(this IWebElement element)
        {
            return double.Parse(element.GetAttribute("RangeValue.Minimum"));
        }

        /// <summary>
        /// Retrieves the RangeValue.Minimum attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the range min value from.</param>
        /// <returns>The range min value of the element.</returns>
        public static double GetRangeMinimum<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetRangeMinimum(element.Element);
        }

        /// <summary>
        /// Retrieves the RangeValue.SmallChange attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the range step value from.</param>
        /// <returns>The range step value of the element.</returns>
        public static double GetRangeSmallChange(this IWebElement element)
        {
            return double.Parse(element.GetAttribute("RangeValue.SmallChange"));
        }

        /// <summary>
        /// Retrieves the RangeValue.SmallChange attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the range step value from.</param>
        /// <returns>The range step value of the element.</returns>
        public static double GetRangeSmallChange<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return GetRangeSmallChange(element.Element);
        }

        /// <summary>
        /// Retrieves the RangeValue.IsReadOnly attribute from the specified element.
        /// </summary>
        /// <param name="element">The <see cref="IWebElement"/> to retrieve the readonly state from.</param>
        /// <returns>A value indicating whether the item is readonly.</returns>
        public static bool IsRangeReadonly(this IWebElement element)
        {
            return bool.Parse(element.GetAttribute("RangeValue.IsReadOnly"));
        }

        /// <summary>
        /// Retrieves the RangeValue.IsReadOnly attribute from the specified element.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of <see cref="RemoteWebElement"/>.
        /// </typeparam>
        /// <param name="element">The <see cref="IElementWrapper{TElement}"/> to retrieve the readonly state from.</param>
        /// <returns>A value indicating whether the item is readonly.</returns>
        public static bool IsRangeReadonly<TElement>(this IElementWrapper<TElement> element)
            where TElement : IWebElement
        {
            return IsRangeReadonly(element.Element);
        }
    }
}