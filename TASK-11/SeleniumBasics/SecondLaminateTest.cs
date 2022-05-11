using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics;

public class SecondLaminateTest
{
    private IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
    }

    protected void ClearWebField(IWebElement element)
    {
        while (!element.GetAttribute("value").Equals(""))
        {
            element.SendKeys(Keys.Backspace);
            element.SendKeys(Keys.Delete);
        }
    }

    [Test]
    public void SecondLaminate_SmokeTest()
    {
        _driver.Navigate().GoToUrl("https://masterskayapola.ru/kalkulyator/laminata.html");
        Thread.Sleep(5000);
        var roomLength = _driver.FindElement(By.Name("calc_roomwidth"));
        ClearWebField(roomLength);
        roomLength.SendKeys("12");

        var roomWidth = _driver.FindElement(By.Name("calc_roomheight"));
        ClearWebField(roomWidth);
        roomWidth.SendKeys("9");

        var laminateLength = _driver.FindElement(By.Name("calc_lamwidth"));
        ClearWebField(laminateLength);
        laminateLength.SendKeys("1000");

        var laminateWidth = _driver.FindElement(By.Name("calc_lamheight"));
        ClearWebField(laminateWidth);
        laminateWidth.SendKeys("200");

        var inPackage = _driver.FindElement(By.Name("calc_inpack"));
        ClearWebField(inPackage);
        inPackage.SendKeys("10");

        var directionTemp = _driver.FindElement(By.Name("calc_direct"));
        var direction = new SelectElement(directionTemp);
        direction.SelectByValue("toh");

        var shifting = _driver.FindElement(By.Name("calc_bias"));
        ClearWebField(shifting);
        shifting.SendKeys("250");

        var indent = _driver.FindElement(By.Name("calc_walldist"));
        ClearWebField(indent);
        indent.SendKeys("10");
        
        Thread.Sleep(1500);

        var calculateButton = _driver.FindElement(By.ClassName("btn"));
        calculateButton.Click();

        var resultArea = _driver.FindElement(By.XPath("//*[@id='s_lam']/b"));
        var resultCost = _driver.FindElement(By.XPath("//*[@id='l_price']/b"));

        Assert.Multiple(() =>
        {
            Assert.AreEqual("107.58", resultArea.Text);
            Assert.AreEqual("55000", resultCost.Text);
        });
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Manage().Cookies.DeleteAllCookies();
        _driver.Quit();
    }
}
