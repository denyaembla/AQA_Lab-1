using JsExecutor.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace JsExecutor.Tests;

public class JsExecutorTest : BaseTest
{
    private Actions _actions;
    private IJavaScriptExecutor _jsExecutor;

    [Test]
    public void OnlinerTest()
    {
        var onlinerPage = new OnlinerPage(Driver, true);

        _jsExecutor = (IJavaScriptExecutor) Driver;
        var value = "Холодильник";

        _jsExecutor.ExecuteScript("document.getElementsByClassName('fast-search__input')[0].setAttribute('value','"+ value +"')", value);
        onlinerPage.SearchBar.Click();
        
        Driver.SwitchTo().Frame(onlinerPage.SearchFrame);
        var firstResultItemName = onlinerPage.FirstResultItem.Text;

        onlinerPage.InFrameSearchBar.Clear();
        _actions = new Actions(Driver);
        _actions.SendKeys(onlinerPage.InFrameSearchBar, firstResultItemName).Perform();

        Assert.AreEqual(firstResultItemName, onlinerPage.FirstResultItem.Text);
    }
}
