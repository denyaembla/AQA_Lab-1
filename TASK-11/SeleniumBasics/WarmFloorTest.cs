using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics;

public class Tests
{
    
    private IWebDriver _driver;

    [SetUp]
    protected void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Test]
    public void WarmFloorSmokeTest()
    {
        _driver.Navigate().GoToUrl("https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx");

        var widthFloor = _driver.FindElement(By.Id("el_f_width"));
        widthFloor.SendKeys("4");

        var lengthFloor = _driver.FindElement(By.Id("el_f_lenght"));
        lengthFloor.SendKeys("6");

        var roomTypeTemp = _driver.FindElement(By.Id("room_type"));
        var roomType = new SelectElement(roomTypeTemp);
        roomType.SelectByIndex(3);

        var heatingTypeTemp = _driver.FindElement(By.Id("heating_type"));
        var heatingType = new SelectElement(heatingTypeTemp);
        heatingType.SelectByValue("3");

        var warmthLosses = _driver.FindElement(By.Id("el_f_losses"));
        warmthLosses.SendKeys("100");

        var calculateButton = _driver.FindElement(By.ClassName("buttHFcalc"));
        calculateButton.Click();
        
        Thread.Sleep(5000);

        var resultHeatingPower = _driver.FindElement(By.Id("floor_cable_power"));
        var resultCablePower = _driver.FindElement(By.Id("spec_floor_cable_power"));

        Assert.Multiple(() =>
        {
            Assert.AreEqual("56", resultHeatingPower.GetAttribute("value"));
            Assert.AreEqual("2", resultCablePower.GetAttribute("value"));
        });
    }

    [TearDown]
    protected void TearDown()
    {
        _driver.Quit();
    }
}
