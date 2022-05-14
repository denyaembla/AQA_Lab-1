using BDDHomework.Configuration;
using BDDHomework.Pages;
using NUnit.Framework;

namespace BDDHomework.Steps.UiStepDefinitions;

[Binding]
public sealed class LoginUiStepDefinitions : BaseStepDefinition
{
    private readonly LoginPage _loginPage;
    private readonly DashboardPage _dashboardPage;

    public LoginUiStepDefinitions(FeatureContext featureContext) : base(featureContext)
    {
        _loginPage = new LoginPage(Driver);
        _dashboardPage = new DashboardPage(Driver);
    }

    [Given(@"user has authorized")]
    public void GivenUserHasAuthorized()
    {
        UserEntersEmail(Configurator.Admin.Email);
        UserEntersPassword(Configurator.Admin.Password);
        UserClicksLogInButton();

        Assert.That(_dashboardPage.PageOpened, "Something went wrong during logging in. Dashboard page wasn't opened.");
    }

    private void UserEntersEmail(string email)
    {
        _loginPage.UserNameField.SendKeys(email);
    }

    private void UserEntersPassword(string password)
    {
        _loginPage.PasswordField.SendKeys(password);
    }

    private void UserClicksLogInButton()
    {
        _loginPage.LoginButton.Click();
    }

    // DEVNOTE: Private methods here can be used as whens and thens for other scenarios which don't exist yet.
}
