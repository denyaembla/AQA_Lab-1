using System;
using Alerts_and_Waiters.Services;
using OpenQA.Selenium;

namespace Alerts_and_Waiters.Pages.WindowManage;

public class FacebookPage : BasePage
{
    private const string Endpoint = "/onlinerby";
        
    private static readonly By FacebookHeaderLocator = By.CssSelector("div.tkr6xdv7");
    private static readonly By FirstAboutTabLocator = By.XPath("(//*[contains(text(), 'Информация') or contains(text(), 'About')]) [1]");
    private static readonly By OnlinerTitleLocator = By.XPath("//h1[contains(text(), 'onlíner')]");
        
    public IWebElement FacebookHeader => WaitService.WaitUntilElementExists(FacebookHeaderLocator);
    public IWebElement FirstAboutTab => WaitService.WaitUntilElementExists(FirstAboutTabLocator);
    public IWebElement OnlinerTitle => WaitService.WaitUntilElementExists(OnlinerTitleLocator);
        
    public FacebookPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
        
    protected override void OpenPage()
    {
        
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return FacebookHeader.Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
