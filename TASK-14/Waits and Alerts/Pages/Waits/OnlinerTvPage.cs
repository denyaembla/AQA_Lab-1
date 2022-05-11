using System;
using System.Collections.ObjectModel;
using Alerts_and_Waits.Services;
using OpenQA.Selenium;

namespace Alerts_and_Waits.Pages.Waits;

public class OnlinerTvWaitPage : BasePage
{
    private readonly string END_POINT = "/tv";

    private static readonly By CheckboxLocators =
        By.XPath("//div[@class='schema-product__group']/div/div/div/div/label[@class='schema-product__control']");

    private static readonly By CompareButtonLocator = By.CssSelector(".compare-button__sub_main");

    public ReadOnlyCollection<IWebElement> Checkboxes => Driver.FindElements(CheckboxLocators);
    public IWebElement CompareButton => Driver.FindElement(CompareButtonLocator);

    public OnlinerTvWaitPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.OnlinerUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return Checkboxes[^1].Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }
}