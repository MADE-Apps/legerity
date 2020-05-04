namespace Legerity.Windows.Elements
{
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines an element wrapper for a <see cref="WindowsElement"/>.
    /// </summary>
    public abstract class WindowsElementWrapper : ElementWrapper<WindowsElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsElementWrapper"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        protected WindowsElementWrapper(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the instance of the Appium driver for the Windows application.
        /// </summary>
        public WindowsDriver<WindowsElement> Driver => AppManager.WindowsApp;
    }
}