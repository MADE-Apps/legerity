namespace Legerity.Windows.Elements.Core
{
    using System;
    using System.Threading;

    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the core UWP InkToolbar control.
    /// </summary>
    public partial class InkToolbar : WindowsElementWrapper
    {
        private readonly By ballpointPenFlyoutQuery = By.Name("Ballpoint pen flyout");

        private readonly By pencilFlyoutQuery = By.Name("Pencil flyout");

        private readonly By highlighterFlyoutQuery = By.Name("Highlighter flyout");

        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbar"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public InkToolbar(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the ballpoint pen button.
        /// </summary>
        public RadioButton BallpointPenButton =>
            this.Element.FindElement(ByExtensions.AutomationId("InkToolbarBallpointPenButton"));

        /// <summary>
        /// Gets the currently selected ballpoint pen color.
        /// </summary>
        public string SelectedBallpointPenColor => this.BallpointPenFlyout.SelectedColor;

        /// <summary>
        /// Gets the element associated with the pencil button.
        /// </summary>
        public RadioButton PencilButton =>
            this.Element.FindElement(ByExtensions.AutomationId("InkToolbarPencilButton"));

        /// <summary>
        /// Gets the currently selected pencil color.
        /// </summary>
        public string SelectedPencilColor => this.PencilFlyout.SelectedColor;

        /// <summary>
        /// Gets the element associated with the highlighter button.
        /// </summary>
        public RadioButton HighlighterButton =>
            this.Element.FindElement(ByExtensions.AutomationId("InkToolbarHighlighterButton"));

        /// <summary>
        /// Gets the currently selected highlighter color.
        /// </summary>
        public string SelectedHighlighterColor => this.HighlighterFlyout.SelectedColor;

        /// <summary>
        /// Gets the element associated with the ruler button.
        /// </summary>
        public ToggleButton RulerButton =>
            this.Element.FindElement(ByExtensions.AutomationId("InkToolbarStencilButton"));

        private InkToolbarBallpointPenFlyout BallpointPenFlyout =>
            this.Driver.FindElement(this.ballpointPenFlyoutQuery);

        private InkToolbarPencilFlyout PencilFlyout => this.Driver.FindElement(this.pencilFlyoutQuery);

        private InkToolbarHighlighterFlyout HighlighterFlyout => this.Driver.FindElement(this.highlighterFlyoutQuery);

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="InkToolbar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbar"/>.
        /// </returns>
        public static implicit operator InkToolbar(WindowsElement element)
        {
            return new InkToolbar(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="InkToolbar"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="InkToolbar"/>.
        /// </returns>
        public static implicit operator InkToolbar(AppiumWebElement element)
        {
            return new InkToolbar(element as WindowsElement);
        }

        /// <summary>
        /// Selects the ballpoint pen option.
        /// </summary>
        public void SelectBallpointPen()
        {
            if (!this.BallpointPenButton.IsSelected)
            {
                this.BallpointPenButton.Click();
            }
        }

        /// <summary>
        /// Opens the ballpoint pen flyout.
        /// </summary>
        public void OpenBallpointPenFlyout()
        {
            this.SelectBallpointPen();

            this.BallpointPenButton.Click();
            this.VerifyDriverElementShown(this.ballpointPenFlyoutQuery, TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Sets the toolbar to the ballpoint pen with the given color.
        /// </summary>
        /// <param name="color">
        /// The color to set.
        /// </param>
        public void SetBallpointPenColor(string color)
        {
            this.OpenBallpointPenFlyout();
            this.BallpointPenFlyout.SetColor(color);
        }

        /// <summary>
        /// Selects the pencil option.
        /// </summary>
        public void SelectPencil()
        {
            if (!this.PencilButton.IsSelected)
            {
                this.PencilButton.Click();
            }
        }

        /// <summary>
        /// Opens the pencil flyout.
        /// </summary>
        public void OpenPencilFlyout()
        {
            this.SelectPencil();

            this.PencilButton.Click();
            this.VerifyDriverElementShown(this.pencilFlyoutQuery, TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Sets the toolbar to the pencil with the given color.
        /// </summary>
        /// <param name="color">
        /// The color to set.
        /// </param>
        public void SetPencilColor(string color)
        {
            this.OpenPencilFlyout();
            this.PencilFlyout.SetColor(color);
        }

        /// <summary>
        /// Selects the highlighter option.
        /// </summary>
        public void SelectHighlighter()
        {
            if (!this.HighlighterButton.IsSelected)
            {
                this.HighlighterButton.Click();
            }
        }

        /// <summary>
        /// Opens the pencil flyout.
        /// </summary>
        public void OpenHighlighterFlyout()
        {
            this.SelectHighlighter();

            this.HighlighterButton.Click();
            this.VerifyDriverElementShown(this.highlighterFlyoutQuery, TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Sets the toolbar to the pencil with the given color and size.
        /// </summary>
        /// <param name="color">
        /// The color to set.
        /// </param>
        public void SetHighlighterColor(string color)
        {
            this.OpenHighlighterFlyout();
            this.HighlighterFlyout.SetColor(color);
        }
    }
}