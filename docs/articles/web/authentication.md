---
uid: web-authentication
title: Web - Authentication
---

# Web authentication

`Legerity.Web.Authentication` provides pre-built page objects for common third-party login flows. If your application delegates authentication to Azure AD, Google, or Facebook, these page objects handle the login interaction so your tests can get past the authentication wall without writing boilerplate login code for each provider.

```powershell
dotnet add package Legerity.Web.Authentication
```

## Azure AD login

[`AzureAdLoginPage`](xref:Legerity.Web.Authentication.Pages.AzureAdLoginPage) handles the Microsoft identity platform login flow:

```csharp
public class LoginTests : BaseTestClass
{
    [SetUp]
    public void SetUp() => StartApp();

    [TearDown]
    public void TearDown() => StopApp();

    [Test]
    public void ShouldLoginWithAzureAd()
    {
        // Navigate to your app's login page which redirects to Azure AD
        var loginPage = new AzureAdLoginPage();
        loginPage.Login("user@contoso.com", "password");

        // After login, you're redirected back to your app
        var dashboard = new DashboardPage();
        dashboard.VerifyPageShown();
    }
}
```

## Google login

[`GoogleLoginPage`](xref:Legerity.Web.Authentication.Pages.GoogleLoginPage) handles the Google OAuth flow:

```csharp
var googleLogin = new GoogleLoginPage();
googleLogin.Login("user@gmail.com", "password");
```

## Facebook login

[`FacebookLoginPage`](xref:Legerity.Web.Authentication.Pages.FacebookLoginPage) handles the Facebook OAuth flow:

```csharp
var fbLogin = new FacebookLoginPage();
fbLogin.Login("user@example.com", "password");
```

## Using in your page objects

A common pattern is to incorporate the authentication page into your own page object's login flow:

```csharp
public class MyAppLoginPage : BasePage
{
    protected override By Trait => By.Id("loginWithAzureAd");

    public DashboardPage LoginWithAzureAd(string email, string password)
    {
        App.FindElement(By.Id("loginWithAzureAd")).Click();

        var azureAdPage = new AzureAdLoginPage();
        azureAdPage.Login(email, password);

        return new DashboardPage();
    }
}
```

## Limitations

- These page objects are built against the standard login flows at the time of release. Provider UI changes may require updates.
- Multi-factor authentication (MFA) prompts are not handled. For MFA-protected accounts in test environments, configure the identity provider to exempt test accounts or use app passwords.
- OAuth consent screens are not handled. Ensure test accounts have pre-consented to the required permissions.

## Best practices

- **Use dedicated test accounts.** Don't use real user credentials in automated tests. Create test accounts with pre-consented permissions and disabled MFA.
- **Store credentials securely.** Use environment variables, user secrets, or a test configuration file that's excluded from source control. Never hardcode credentials in test code.
- **Handle redirect timing.** OAuth flows involve multiple redirects. Use appropriate `ImplicitWait` and `WaitTimeout` values to account for network latency.
