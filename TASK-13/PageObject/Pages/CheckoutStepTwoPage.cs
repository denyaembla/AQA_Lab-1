using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepTwoPage : BasePage
{
    private const string END_POINT = "/checkout-step-two.html";

    public CheckoutStepTwoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return CheckoutStepTwoTitle.Displayed;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    private static readonly By CheckoutStepTwoId = By.ClassName("title");
    private static readonly By FinishId = By.Id("finish");
    public static IWebElement CheckoutStepTwoTitle => Driver.FindElement(CheckoutStepTwoId);
    public IWebElement FinishButton => Driver.FindElement(FinishId);
}
