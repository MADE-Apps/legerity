namespace Legerity.Windows.Elements.WCT
{
    using System;
    using Legerity.Windows.Elements.Core;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the Windows Community Toolkit BladeViewItem control.
    /// </summary>
    public class BladeViewItem : WindowsElementWrapper
    {
        private readonly WeakReference parentBladeViewReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="BladeViewItem"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public BladeViewItem(WindowsElement element)
            : this(null, element)
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
            this.parentBladeViewReference is { IsAlive: true }
                ? this.parentBladeViewReference.Target as BladeView
                : null;

        /// <summary>
        /// Gets the <see cref="Button"/> element associated with the blade enlarge option.
        /// </summary>
        public virtual Button EnlargeButton => this.Element.FindElement(WindowsByExtras.AutomationId("EnlargeButton"));

        /// <summary>
        /// Gets the <see cref="Button"/> element associated with the blade close option.
        /// </summary>
        public virtual Button CloseButton => this.Element.FindElement(WindowsByExtras.AutomationId("CloseButton"));

        /// <summary>
        /// Closes the blade item.
        /// </summary>
        public virtual void Close()
        {
            this.CloseButton.Click();
        }
    }
}