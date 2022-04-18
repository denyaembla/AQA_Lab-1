using System;
using System.Collections.ObjectModel;
using Alerts_and_Waiters.Services;
using OpenQA.Selenium;

namespace Alerts_and_Waiters.Pages.WindowManage;

public class OnlinerTvWindowPage : BasePage
{

    private readonly string END_POINT = "/tv";
    private static readonly By VkFooterLinkLocator = By.CssSelector(".footer-style__social-button_vk");
    private static readonly By FbFooterLinkLocator = By.CssSelector(".footer-style__social-button_fb");
    private static readonly By TwFooterLinkLocator = By.CssSelector(".footer-style__social-button_tw");
    
    public IWebElement VkFooterLink => WaitService.WaitUntilElementExists(VkFooterLinkLocator);
    public IWebElement FbFooterLink => WaitService.WaitUntilElementExists(FbFooterLinkLocator);
    public IWebElement TwFooterLink => WaitService.WaitUntilElementExists(TwFooterLinkLocator);
    
    public OnlinerTvWindowPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return TwFooterLink.Displayed;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
