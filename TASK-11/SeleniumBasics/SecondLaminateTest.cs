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

        /*      Piece of code in attempt to skip advertisement
        TimeSpan waitingTime = TimeSpan.FromSeconds(7);
        WebDriverWait wait = new WebDriverWait(_driver, waitingTime);
        IWebElement adsCloser = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementExists(By.Id("own-timer")));

        if (adsCloser.Displayed)
        {
            adsCloser.Click();
        }
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        */      

        var roomLength = _driver.FindElement(By.Name("calc_roomwidth"));
        roomLength.SendKeys(Keys.Control + "A" + Keys.Delete);
        roomLength.SendKeys("12");
        
        var roomWidth = _driver.FindElement(By.Name("calc_roomheight"));
        roomWidth.SendKeys(Keys.Control + "A" + Keys.Delete);
        roomWidth.SendKeys("9");
        
        var laminateLength = _driver.FindElement(By.Name("calc_lamwidth"));
        laminateLength.Clear();
        laminateLength.SendKeys("1000");
        
        var laminateWidth  = _driver.FindElement(By.Name("calc_lamheight"));
        laminateWidth.Clear();
        laminateWidth.SendKeys("200");
        
        var inPackage = _driver.FindElement(By.Name("calc_inpack"));
        inPackage.Clear();
        inPackage.SendKeys("10");
        
        var packagePrice = _driver.FindElement(By.Name("calc_price"));
        packagePrice.Clear();
        packagePrice.SendKeys("600");

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
        
        Thread.Sleep(5000);

        //var area = _driver.FindElement(By.Id("s_lam"));
        var resultArea = _driver.FindElement(By.XPath("//*[@id='s_la']/b"));

        var resultCost = _driver.FindElement(By.XPath("//*[@id='l_price']/b"));

        Assert.Multiple(() =>
        {
            Assert.AreEqual("107.58", resultArea.Text);
            Assert.AreEqual("55411", resultCost.Text);
        });

    }

    [TearDown]
    public void TearDown()
    {
        //_driver.Quit();
    }
}
