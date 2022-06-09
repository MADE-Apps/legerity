namespace WebTests.Pages
{
    using System.Collections.ObjectModel;
    using System.Linq;

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

        public HomePage(RemoteWebDriver app)
            : base(app)
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