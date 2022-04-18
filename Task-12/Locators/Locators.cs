using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators;

public class Tests
{
    private IWebDriver _driver;
    private static readonly string _index = "index.html";
    private static char _separator = Path.DirectorySeparatorChar;

    private static string FilePath()
    {
        var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + _separator + _index;
        return path;
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _driver = new ChromeDriver();
    }

    [Test]
    public void XPath_Test()
    {
        _driver.Navigate().GoToUrl(FilePath());

        var xpath1 = _driver.FindElement(By.XPath("(//*[contains(text(),'Test')])[2]"));
        var xpath2 = _driver.FindElement(By.XPath("//*[text() ='Test'][@ids]"));
        var xpath3 = _driver.FindElement(By.XPath("//*[normalize-space() ='Title 2']"));
        var xpath4 = _driver.FindElement(By.XPath("//h1[span[normalize-space() = 'Title 3']]"));
        var xpath5 = _driver.FindElement(By.XPath(
            "(*//div[normalize-space('Title 2')]/following-sibling :: div//*[@class='arrow'])[2]"));

        Assert.Multiple(() =>
        {
            Assert.IsTrue(xpath1.Displayed);
            Assert.IsTrue(xpath2.Displayed);
            Assert.IsTrue(xpath3.Displayed);
            Assert.IsTrue(xpath4.Displayed);
            Assert.IsTrue(xpath5.Displayed);
        });
    }

    [Test]
    public void CssSelectors_Test()
    {
        _driver.Navigate().GoToUrl(FilePath());

        var css1 = _driver.FindElement(By.CssSelector("span[id='123']"));
        var css2 = _driver.FindElements(By.CssSelector(".arrow"));
        var css3 = _driver.FindElement(By.CssSelector("[id='123']"));
        var css4 = _driver.FindElements(By.CssSelector("h1 > * "));
        var css5 = _driver.FindElements(By.CssSelector("span[value^='12']"));
        
        Assert.Multiple(() =>
        {
            Assert.IsTrue(css1.Displayed);
            Assert.AreEqual(6, css2.Count);
            Assert.IsTrue(css3.Displayed);
            Assert.AreEqual(6, css4.Count);
            Assert.AreEqual(2, css5.Count);
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
}
