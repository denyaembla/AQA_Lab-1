using System;
using Allure_Reporting.Services;
using OpenQA.Selenium;

namespace Allure_Reporting.Pages;

public class CheckoutCompletePage : BasePage
{
    private const string END_POINT = "/checkout-complete.html";
    public CheckoutCompletePage(IWebDriver driver) : base(driver){}
    protected override void OpenPage() => Driver.Navigate().GoToUrl(Configurator.Url + END_POINT);
    
    private static readonly By CheckoutCompletePageTitle = By.ClassName("title");
    public static IWebElement CheckoutTitle => Driver.FindElement(CheckoutCompletePageTitle);
    protected override bool IsPageOpened()
    {
        try
        {
            return CheckoutTitle.Displayed;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    
    
}
