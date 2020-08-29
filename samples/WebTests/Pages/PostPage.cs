namespace WebTests.Pages
{
    using System;
    using System.Threading;

    using Legerity;
    using Legerity.Pages;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class PostPage : BasePage
    {
        protected override By Trait => By.ClassName("single-post");

        public PostPage ReadPost(double readTimeMinutes = 1)
        {
            DateTime expectedDateTime = DateTime.UtcNow.AddMinutes(readTimeMinutes);
            while (DateTime.UtcNow < expectedDateTime)
            {
                var actions = new Actions(AppManager.WebApp);
                actions.SendKeys(Keys.ArrowDown);
                actions.Perform();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }

            return this;
        }
    }
}