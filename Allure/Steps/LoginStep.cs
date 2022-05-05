using Allure_Reporting.Pages;
using Allure_Reporting.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace Allure_Reporting.Steps;

public class LoginStep : BaseStep
{
    
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    private void EnterLoginData(string username, string password)
    {
        LoginPage.UsernameInput.SendKeys(username);
        LoginPage.PasswordInput.SendKeys(password);
        LoginPage.LoginButton.Submit();
    }
    
    public InventoryPage SuccessLogin(string username, string password)
    {
        EnterLoginData(username, password);
        return InventoryPage;
    }

    public LoginPage IncorrectLogin(string email, string psw)
    {
        EnterLoginData(email, psw);
        return LoginPage;
    }
    
    
    
    
    
    
}
