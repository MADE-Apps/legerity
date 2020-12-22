namespace Legerity.Windows.Elements.WCT
{
    using System;
    using Core;
    using Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit BladeViewItem control.
    /// </summary>
    public class BladeViewItem : WindowsElementWrapper
    {
        private readonly By enlargeButtonQuery = ByExtensions.AutomationId("EnlargeButton");

        private readonly By closeButtonQuery = ByExtensions.AutomationId("CloseButton");

        private readonly WeakReference parentBladeViewReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="BladeViewItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public BladeViewItem(WindowsElement element) : this(null, element)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BladeViewItem"/> class.
        /// </summary>
        /// <param name="parentBladeView">
        /// The parent <see cref="BladeView"/>.
        /// </param>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public BladeViewItem(
            BladeView parentBladeView,
            WindowsElement element)
            : base(element)
        {
            if (parentBladeView != null)
            {
                this.parentBladeViewReference = new WeakReference(parentBladeView);
            }
        }

        /// <summary>Gets the original parent <see cref="BladeView"/> reference object.</summary>
        public BladeView ParentMenuBar =>
            this.parentBladeViewReference != null && this.parentBladeViewReference.IsAlive
                ? this.parentBladeViewReference.Target as BladeView
                : null;

        /// <summary>
        /// Gets the <see cref="Button"/> element associated with the blade enlarge option.
        /// </summary>
        public Button EnlargeButton => this.Element.FindElement(this.enlargeButtonQuery);

        /// <summary>
        /// Gets the <see cref="Button"/> element associated with the blade close option.
        /// </summary>
        public Button CloseButton => this.Element.FindElement(this.closeButtonQuery);

        /// <summary>
        /// Closes the blade item.
        /// </summary>
        public void Close()
        {
            this.CloseButton.Click();
        }
    }
}