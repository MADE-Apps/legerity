namespace WindowsCommunityToolkitSampleApp.Elements
{
    using System.Linq;
    using Legerity.Extensions;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Elements.WCT;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    public class VsCodeInAppNotification : InAppNotification
    {
        public VsCodeInAppNotification(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the dismiss button.
        /// </summary>
        public override Button DismissButton => this.Element.FindElements(By.ClassName("Button")).FirstOrDefault(x => x.GetName() == "Close");

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="VsCodeInAppNotification"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="VsCodeInAppNotification"/>.
        /// </returns>
        public static implicit operator VsCodeInAppNotification(WindowsElement element)
        {
            return new VsCodeInAppNotification(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="VsCodeInAppNotification"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="VsCodeInAppNotification"/>.
        /// </returns>
        public static implicit operator VsCodeInAppNotification(AppiumWebElement element)
        {
            return new VsCodeInAppNotification(element as WindowsElement);
        }
    }
}
