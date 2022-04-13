using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Tests;

public class LoginTest : BaseTest
{
    [Test]
    public void Test_Success_Login()
    {
        
        var loginPage = new LoginPage(Driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();

        var productsPage = new InventoryPage(Driver, false);
        
        Assert.AreEqual("PRODUCTS", productsPage.InventoryPageTitle.Text);
    }
}
