namespace Legerity
{
    using System;

    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a base wrapper for elements to expose platform element logic.
    /// </summary>
    /// <typeparam name="TElement">
    /// The type of <see cref="AppiumWebElement"/>.
    /// </typeparam>
    public abstract class ElementWrapper<TElement>
        where TElement : AppiumWebElement
    {
        private readonly WeakReference elementReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementWrapper{TElement}"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="TElement"/> reference.
        /// </param>
        protected ElementWrapper(TElement element)
        {
            this.elementReference = new WeakReference(element);
        }

        /// <summary>Gets the original <see cref="TElement"/> reference object.</summary>
        public TElement Element =>
            this.elementReference != null && this.elementReference.IsAlive
                ? this.elementReference.Target as TElement
                : null;
    }
}