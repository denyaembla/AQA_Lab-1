using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Tests;

public class BaseTest
{
    [ThreadStatic] private static IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new BrowserService().WebDriver;
    }

    [TearDown]
    public void TearDown()
    {
       _driver.Quit();
    }

    public static void Login()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
    }

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
