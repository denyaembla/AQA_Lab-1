using System;
using Alerts_and_Waits.Services;
using OpenQA.Selenium;

namespace Alerts_and_Waits.Pages.Alerts;

public class AlertsPage : BasePage
{
    private const string END_POINT = "/javascript_alerts";

    private static readonly By PageIsReadyFlag = By.XPath("//div/h4");
    public IWebElement PageIsReady => WaitService.WaitUntilElementExists(PageIsReadyFlag);

    private static readonly By JsAlertLocator = By.CssSelector("button[onclick='jsAlert()']");
    private static readonly By JsConfirmLocator = By.CssSelector("button[onclick='jsConfirm()']");
    private static readonly By JsPromptLocator = By.XPath("//button[@onclick='jsPrompt()']");
    private static readonly By ResultFieldId = By.Id("result");


    public IWebElement JsAlert => Driver.FindElement(JsAlertLocator);
    public IWebElement JsConfirm => Driver.FindElement(JsConfirmLocator);
    public IWebElement JsPrompt => Driver.FindElement(JsPromptLocator);
    public IWebElement ResultField => Driver.FindElement(ResultFieldId);


    public AlertsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AlertsUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return PageIsReady.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}
