using System;
using OpenQA.Selenium;

namespace Alerts_and_Waits.Pages.WindowManage;

public class TwitterPage : BasePage
{
    private static readonly By TwitterLogoLocator = By.CssSelector("h1[role = 'heading']");
    private static readonly By ExploreButtonLocator = By.CssSelector("[href = '/explore']");
    private static readonly By MainOnlinerTitleLocator = By.XPath("(//span[contains(text(), 'onlíner')]) [1]");
        
    public IWebElement TwitterLogo => WaitService.WaitUntilElementExists(TwitterLogoLocator);
    public IWebElement ExploreButton => WaitService.WaitUntilElementExists(ExploreButtonLocator);
    public IWebElement MainOnlinerTitle => WaitService.WaitUntilElementExists(MainOnlinerTitleLocator);
        
    public TwitterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
        
    protected override void OpenPage()
    {
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return TwitterLogo.Displayed;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
