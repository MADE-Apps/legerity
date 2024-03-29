namespace Legerity.Web.Authentication.Pages;

using System;
using Exceptions;
using Legerity.Extensions;
using Legerity.Pages;
using Legerity.Web.Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

/// <summary>
/// Defines a page object for the Facebook login page.
/// </summary>
public class FacebookLoginPage : BasePage
{
    /// <summary>
    /// The expected title of the Facebook login page.
    /// </summary>
    public const string Title = "Log in to Facebook";

    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookLoginPage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within 2 seconds.
    /// </summary>
    /// <exception cref="DriverNotInitializedException">Thrown when AppManager.StartApp() has not been called.</exception>
    /// <exception cref="PageNotShownException">Thrown when the page is not shown in 2 seconds.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public FacebookLoginPage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookLoginPage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within 2 seconds.
    /// </summary>
    /// <param name="app">
    /// The instance of the started application driver that will be used to drive the page interaction.
    /// </param>
    /// <exception cref="DriverNotInitializedException">Thrown when AppManager.StartApp() has not been called.</exception>
    /// <exception cref="PageNotShownException">Thrown when the page is not shown in 2 seconds.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public FacebookLoginPage(RemoteWebDriver app)
        : base(app)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookLoginPage"/> class using the <see cref="AppManager.App"/> instance that verifies the page has loaded within the given timeout.
    /// </summary>
    /// <param name="traitTimeout">
    /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
    /// </param>
    /// <exception cref="DriverNotInitializedException">Thrown when AppManager.StartApp() has not been called.</exception>
    /// <exception cref="PageNotShownException">Thrown when the page is not shown in the given timeout.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public FacebookLoginPage(TimeSpan? traitTimeout)
        : base(traitTimeout)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookLoginPage"/> class using a <see cref="RemoteWebDriver"/> instance that verifies the page has loaded within the given timeout.
    /// </summary>
    /// <param name="app">
    /// The instance of the started application driver that will be used to drive the page interaction.
    /// </param>
    /// <param name="traitTimeout">
    /// The amount of time the driver should wait when searching for the <see cref="Trait"/> if it is not immediately present.
    /// </param>
    /// <exception cref="DriverNotInitializedException">Thrown when AppManager.StartApp() has not been called.</exception>
    /// <exception cref="PageNotShownException">Thrown when the page is not shown in the given timeout.</exception>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public FacebookLoginPage(RemoteWebDriver app, TimeSpan? traitTimeout)
        : base(app, traitTimeout)
    {
    }

    /// <summary>
    /// Gets the input element for providing an email address.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextInput EmailInput => this.FindElement(By.Id("email"));

    /// <summary>
    /// Gets the input element for providing a password.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual TextInput PasswordInput => this.FindElement(WebByExtras.InputType("password"));

    /// <summary>
    /// Gets the button element for continuing the sign-in flow through the Facebook login UI.
    /// </summary>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    public virtual Button SignInButton => this.FindElement(By.Id("loginbutton"));

    /// <summary>
    /// Gets a given trait of the page to verify that the page is in view.
    /// </summary>
    protected override By Trait => By.ClassName("login_form_container");

    /// <summary>
    /// Login a Facebook user by email and password.
    /// </summary>
    /// <param name="email">The email address to authenticate with.</param>
    /// <param name="password">The password associated with the email address to authenticate with.</param>
    /// <returns>The <see cref="FacebookLoginPage"/> instance.</returns>
    /// <exception cref="NoSuchElementException">Thrown when no element matches the expected locator.</exception>
    /// <exception cref="StaleElementReferenceException">Thrown when an element is no longer valid in the document DOM.</exception>
    /// <exception cref="InvalidElementStateException">Thrown when an element is not enabled.</exception>
    /// <exception cref="ElementNotVisibleException">Thrown when an element is not visible.</exception>
    public FacebookLoginPage Login(string email, string password)
    {
        (bool hasEmailInput, FacebookLoginPage _) =
            this.TryWaitUntil(page => page.EmailInput.IsVisible, this.WaitTimeout);
        if (!hasEmailInput)
        {
            // Cannot login as email address input not shown (possibly logged in already?)
            return this;
        }

        this.EmailInput.SetText(email);
        this.PasswordInput.SetText(password);
        this.SignInButton.Click();
        return this;
    }
}