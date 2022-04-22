using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Wrappers.Wrappers;

namespace Wrappers.Tests;

public class TableTest : BaseTest
{

    
    [Test]
    public void Table_Link_Test()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");
        var editTextString = Driver.FindElements(By.XPath("//table/tbody/tr/td/a"))[0].GetAttribute("text");
        var deleteTextString = Driver.FindElements(By.XPath("//table/tbody/tr/td/a"))[1].GetAttribute("text");
        
        var linkText1 = "edit";
        var linkText2 = "delete";
        
        Table table = new Table(Driver, By.TagName("table"));
        
        Assert.AreEqual(editTextString, table.GetLinkByText(linkText1).Text);
        Assert.AreEqual(deleteTextString, table.GetLinkByText(linkText2).Text);
    }
}

    
