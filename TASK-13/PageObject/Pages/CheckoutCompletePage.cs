using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutCompletePage : BasePage
{
    private const string END_POINT = "/checkout-complete.html";

    public CheckoutCompletePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
    }

    private readonly By CheckoutCompletePageTitle = By.ClassName("title");
    public IWebElement CheckoutTitle => Driver.FindElement(CheckoutCompletePageTitle);

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