namespace WebTests.Pages
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity;
    using Legerity.Pages;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using Shouldly;

    /// <summary>
    /// Defines the home page of the website.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly By heroPostsLocator = By.ClassName("nectar-recent-posts-single_featured");

        private readonly By heroPostLocator = By.ClassName("nectar-recent-post-slide");

        private readonly By readPostButtonLocator = By.ClassName("nectar-button");

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within 2 seconds.
        /// </summary>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in 2 seconds.</exception>
        public HomePage()
            : this(AppManager.App, TimeSpan.FromSeconds(2))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within 2 seconds.
        /// </summary>
        /// <param name="app">
        /// The instance of the started application driver that will be used to drive the page interaction.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in 2 seconds.</exception>
        public HomePage(RemoteWebDriver app)
            : this(app, TimeSpan.FromSeconds(2))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within the given timeout.
        /// </summary>
        /// <param name="traitTimeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in the given timeout.</exception>
        public HomePage(TimeSpan? traitTimeout)
            : this(AppManager.App, traitTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within the given timeout.
        /// </summary>
        /// <param name="app">
        /// The instance of the started application driver that will be used to drive the page interaction.
        /// </param>
        /// <param name="traitTimeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in the given timeout.</exception>
        public HomePage(RemoteWebDriver app, TimeSpan? traitTimeout) : base(app, traitTimeout)
        {
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.ClassName("home");

        public HomePage VerifyHeroPostsShown()
        {
            IWebElement heroPostsContainer = this.WebApp.FindElement(this.heroPostsLocator);

            ReadOnlyCollection<IWebElement> heroPosts = heroPostsContainer.FindElements(this.heroPostLocator);
            heroPosts.Count.ShouldBe(3);

            return this;
        }

        public PostPage NavigateToFirstHeroPost()
        {
            IWebElement heroPostsContainer = this.WebApp.FindElement(this.heroPostsLocator);

            ReadOnlyCollection<IWebElement> heroPosts = heroPostsContainer.FindElements(this.heroPostLocator);

            IWebElement heroPost = heroPosts.FirstOrDefault(p => p.Displayed);
            IWebElement readButton = heroPost.FindElement(this.readPostButtonLocator);

            readButton.Click();

            return new PostPage();
        }

        public PostPage NavigateToHeroPostByIndex(int idx)
        {
            IWebElement heroPostsContainer = this.WebApp.FindElement(this.heroPostsLocator);

            ReadOnlyCollection<IWebElement> heroPosts = heroPostsContainer.FindElements(this.heroPostLocator);

            IWebElement heroPost = heroPosts[idx];
            IWebElement readButton = heroPost.FindElement(this.readPostButtonLocator);
            
            readButton.Click();

            return new PostPage();
        }
    }
}