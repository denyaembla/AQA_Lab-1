using System;
using Alerts_and_Waits.Pages;
using Alerts_and_Waits.Pages.Alerts;
using NUnit.Framework;

namespace Alerts_and_Waits.Tests;

public class AlertsTest : BaseTest
{
    [Test]
    public void Alerts_Test()
    {
        var alertsPage = new AlertsPage(Driver, true);
        alertsPage.JsAlert.Click();
        var jsAlert = Driver.SwitchTo().Alert();
        Console.WriteLine(jsAlert.Text);
        jsAlert.Accept();
        Assert.AreEqual("You successfully clicked an alert", alertsPage.ResultField.Text);

        alertsPage.JsConfirm.Click();
        var jsConfirm = Driver.SwitchTo().Alert();
        Console.WriteLine(jsAlert.Text);
        jsConfirm.Accept();
        Assert.AreEqual("You clicked: Ok", alertsPage.ResultField.Text);

        alertsPage.JsPrompt.Click();
        Driver.SwitchTo().Alert().Dismiss();
        Assert.AreEqual("You entered: null", alertsPage.ResultField.Text);

        alertsPage.JsPrompt.Click();
        var alertPrompt = Driver.SwitchTo().Alert();
        alertPrompt.SendKeys("Good site");
        alertPrompt.Accept();
        Assert.AreEqual("You entered: Good site", alertsPage.ResultField.Text);
    }
}
