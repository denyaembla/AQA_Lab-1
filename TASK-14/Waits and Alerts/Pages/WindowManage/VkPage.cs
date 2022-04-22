using System;
using Alerts_and_Waits.Services;
using OpenQA.Selenium;

namespace Alerts_and_Waits.Pages.WindowManage;

public class VkPage : BasePage
{
    private static readonly By VkHeaderLocator = By.CssSelector("svg[width = '30'][height = '30'] path:nth-child(1)");
    private static readonly By VkSignInButtonLocator = By.CssSelector(".quick_login_button");
    private static readonly By GroupTitleLocator = By.XPath("*//div[@class='page_top']/h1[@class='page_name']");

    public IWebElement VkHeader => WaitService.WaitUntilElementExists(VkHeaderLocator);
    public IWebElement VkSignInButton => WaitService.WaitUntilElementExists(VkSignInButtonLocator);
    public IWebElement OnlinerVkGroupTitle => WaitService.WaitUntilElementExists(GroupTitleLocator);


    public VkPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
        
    protected override void OpenPage()
    {
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return VkHeader.Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
