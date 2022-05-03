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

    [Test]
    public void HomeWorkLaminateSecondSmokeTest()
    {
        _driver.Navigate().GoToUrl("https://masterskayapola.ru/kalkulyator/laminata.html");
        Thread.Sleep(5000);
        var roomLength = _driver.FindElement(By.Name("calc_roomwidth"));
        roomLength.SendKeys(Keys.Control + "A" + Keys.Delete);
        roomLength.SendKeys("12");

        var roomWidth = _driver.FindElement(By.Name("calc_roomheight"));
        roomWidth.SendKeys(Keys.Control + "A" + Keys.Delete);
        roomWidth.SendKeys("9");

        var laminateLength = _driver.FindElement(By.Name("calc_lamwidth"));
        laminateLength.Clear();
        laminateLength.SendKeys("1000");

        var laminateWidth = _driver.FindElement(By.Name("calc_lamheight"));
        laminateWidth.Clear();
        laminateWidth.SendKeys("200");

        var inPackage = _driver.FindElement(By.Name("calc_inpack"));
        inPackage.Clear();
        inPackage.SendKeys("10");

        var directionTemp = _driver.FindElement(By.Name("calc_direct"));
        var direction = new SelectElement(directionTemp);
        direction.SelectByValue("toh");

        var shifting = _driver.FindElement(By.Name("calc_bias"));
        shifting.Clear();
        shifting.SendKeys("250");

        var indent = _driver.FindElement(By.Name("calc_walldist"));
        indent.Clear();
        indent.SendKeys("10");

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        var calculateButton = _driver.FindElement(By.ClassName("btn"));
        calculateButton.Click();

        var resultArea = _driver.FindElement(By.XPath("//*[@id='s_lam']/b"));
        var resultCost = _driver.FindElement(By.XPath("//*[@id='l_price']/b"));

        Assert.Multiple(() =>
        {
            Assert.AreEqual("103.84", resultArea.Text);
            Assert.AreEqual("250000", resultCost.Text);
        });
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Manage().Cookies.DeleteAllCookies();
        _driver.Quit();
    }
}
