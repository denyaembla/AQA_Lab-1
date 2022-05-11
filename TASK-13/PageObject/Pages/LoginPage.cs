using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class LoginPage : BasePage
{
    private const string END_POINT = "/";

    private static readonly By UsernameInputBy = By.Id("user-name");
    private static readonly By PasswordInputBy = By.Id("password");
    private static readonly By LoginButtonBy = By.Id("login-button");

    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
    }

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