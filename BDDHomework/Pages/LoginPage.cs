using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class LoginPage : BasePage
{
    private static readonly By UserNameFieldLocator = By.Id("name");
    private static readonly By PasswordFieldLocator = By.Id("password");
    private static readonly By LoginButtonLocator = By.Id("button_primary");

    public IWebElement UserNameField => WaitService.WaitUntilElementExists(UserNameFieldLocator);
    
    public IWebElement PasswordField => WaitService.WaitUntilElementExists(PasswordFieldLocator);
    
    public IWebElement LoginButton => WaitService.WaitUntilElementExists(LoginButtonLocator);

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return LoginButtonLocator;
    }
}
