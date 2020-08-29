namespace WebTests.Pages
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Legerity.Pages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the home page of the website.
    /// </summary>
    public class HomePage : BasePage
    {
        private readonly By heroPostsQuery = By.ClassName("nectar-recent-posts-single_featured");

        private readonly By heroPostItemQuery = By.ClassName("nectar-recent-post-slide");

        private readonly By readArticleButtonQuery = By.ClassName("nectar-button");

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.ClassName("home");

        public HomePage VerifyHeroPostsShown()
        {
            IWebElement heroPostsContainer = this.WebApp.FindElement(this.heroPostsQuery);

            ReadOnlyCollection<IWebElement> heroPosts = heroPostsContainer.FindElements(this.heroPostItemQuery);

            Assert.AreEqual(3, heroPosts.Count);

            return this;
        }

        public PostPage NavigateToHeroPost()
        {
            IWebElement heroPostsContainer = this.WebApp.FindElement(this.heroPostsQuery);

            ReadOnlyCollection<IWebElement> heroPosts = heroPostsContainer.FindElements(this.heroPostItemQuery);

            IWebElement heroPost = heroPosts.FirstOrDefault(p => p.Displayed);
            IWebElement readButton = heroPost.FindElement(this.readArticleButtonQuery);

            readButton.Click();

            return new PostPage();
        }
    }
}