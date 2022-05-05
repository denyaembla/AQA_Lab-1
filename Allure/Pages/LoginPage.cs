using System;
using Allure_Reporting.Services;
using OpenQA.Selenium;

namespace Allure_Reporting.Pages;

public class LoginPage : BasePage
{
    private const string END_POINT = "/";

    private static readonly By UsernameInputBy = By.Id("user-name");
    private static readonly By PasswordInputBy = By.Id("password"); 
    private static readonly By LoginButtonBy = By.Id("login-button"); 
    
    public LoginPage(IWebDriver driver) : base(driver){}

    protected override void OpenPage() => Driver.Navigate().GoToUrl(Configurator.Url + END_POINT);

    protected override bool IsPageOpened()
    {
        try
        {
            return UsernameInput.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IWebElement UsernameInput => Driver.FindElement(UsernameInputBy);
    public IWebElement PasswordInput => Driver.FindElement(PasswordInputBy);
    public IWebElement LoginButton => Driver.FindElement(LoginButtonBy);
    
}
