using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumBasics;

public class FirstLaminateTest
{
    private IWebDriver _driver;

    [SetUp]
    protected void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Test]
    public void LaminateSmokeTest()
    {
        _driver.Navigate().GoToUrl("https://calc.by/building-calculators/laminate.html");

        IWebElement heightOfRoom = _driver.FindElement(By.Id("ln_room_id"));
        heightOfRoom.Clear();
        heightOfRoom.SendKeys("500");

        IWebElement widthOfRoom = _driver.FindElement(By.Id("wd_room_id"));
        widthOfRoom.Clear();
        widthOfRoom.SendKeys("400");
        
        IWebElement lengthOfLaminatePanel = _driver.FindElement(By.Id("ln_lam_id"));
        lengthOfLaminatePanel.Clear();
        lengthOfLaminatePanel.SendKeys("2000");
        
        IWebElement widthOfLaminatePanel = _driver.FindElement(By.Id("wd_lam_id"));
        widthOfLaminatePanel.Clear();
        widthOfLaminatePanel.SendKeys("200");
        
        IWebElement direction = _driver.FindElement(By.Id("direction-laminate-id1"));
        direction.Click();

        IWebElement calculateButton = _driver.FindElement(By.LinkText("Рассчитать"));
        calculateButton.Click();
        
        Thread.Sleep(10000);

        IWebElement resultBoardsAmount = _driver.FindElement(
            By.XPath("//*[@id='t3-content']/div[3]/article/section/div[2]/div[3]/div[2]/div[1]/span"));
        IWebElement resultPackagesAmount = _driver.FindElement(
            By.XPath("//*[@id='t3-content']/div[3]/article/section/div[2]/div[3]/div[2]/div[2]/span"));
      
        Assert.Multiple(() =>
        {
            Assert.AreEqual("53", resultBoardsAmount.Text);
            Assert.AreEqual("7", resultPackagesAmount.Text);
        });
    }

    [TearDown]
    protected void TearDown()
    {
        _driver.Quit();
    }
}
