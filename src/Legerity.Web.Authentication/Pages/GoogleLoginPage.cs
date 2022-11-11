namespace Legerity.Web.Authentication.Pages
{
    using System;
    using Legerity.Extensions;
    using Legerity.Pages;
    using Legerity.Web.Elements.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a page object for the Google login page.
    /// </summary>
    public class GoogleLoginPage : BasePage
    {
        /// <summary>
        /// The expected title of the Google login page.
        /// </summary>
        public const string Title = "Sign in";

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLoginPage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within 2 seconds.
        /// </summary>
        public GoogleLoginPage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLoginPage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within 2 seconds.
        /// </summary>
        /// <param name="app">
        /// The instance of the started application driver that will be used to drive the page interaction.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in 2 seconds.</exception>
        public GoogleLoginPage(RemoteWebDriver app)
            : base(app)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLoginPage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within the given timeout.
        /// </summary>
        /// <param name="traitTimeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in the given timeout.</exception>
        public GoogleLoginPage(TimeSpan? traitTimeout)
            : base(traitTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLoginPage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within the given timeout.
        /// </summary>
        /// <param name="app">
        /// The instance of the started application driver that will be used to drive the page interaction.
        /// </param>
        /// <param name="traitTimeout">
        /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
        /// </param>
        /// <exception cref="T:Legerity.Exceptions.DriverNotInitializedException">Thrown if AppManager.StartApp() has not been called.</exception>
        /// <exception cref="T:Legerity.Exceptions.PageNotShownException">Thrown if the page is not shown in the given timeout.</exception>
        public GoogleLoginPage(RemoteWebDriver app, TimeSpan? traitTimeout)
            : base(app, traitTimeout)
        {
        }

        /// <summary>
        /// Gets the input element for providing an email address.
        /// </summary>
        public virtual TextInput EmailInput => this.App.FindWebElement(WebByExtras.InputType("email"));

        /// <summary>
        /// Gets the input element for providing a password.
        /// </summary>
        public virtual TextInput PasswordInput => this.App.FindWebElement(WebByExtras.InputType("password"));

        /// <summary>
        /// Gets the button element for continuing the sign-in flow through the Google login UI.
        /// </summary>
        public virtual Button NextButton => this.App.FindWebElement(By.Id("identifierNext"));

        /// <summary>
        /// Gets the button element for completing the sign-in flow through the Google login UI.
        /// </summary>
        public virtual Button SignInButton => this.App.FindWebElement(By.Id("passwordNext"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.ClassName("view_container");

        /// <summary>
        /// Login a Google user by email and password.
        /// </summary>
        /// <param name="email">The email address to authenticate with.</param>
        /// <param name="password">The password associated with the email address to authenticate with.</param>
        /// <returns>The <see cref="GoogleLoginPage"/> instance.</returns>
        public GoogleLoginPage Login(string email, string password)
        {
            (bool hasEmailInput, GoogleLoginPage _) =
                this.TryWaitUntil(page => page.EmailInput.IsVisible, this.WaitTimeout);
            if (!hasEmailInput)
            {
                // Cannot login as email address input not shown (possibly logged in already?)
                return this;
            }

            this.EmailInput.SetText(email);

            // Google login uses a 2-step process for email and password.
            this.NextButton.Click();

            (bool isPasswordInputVisible, GoogleLoginPage _) =
                this.TryWaitUntil(page => page.PasswordInput.IsVisible, this.WaitTimeout);
            if (!isPasswordInputVisible)
            {
                return this;
            }

            this.PasswordInput.SetText(password);
            this.SignInButton.Click();

            return this;
        }
    }
}