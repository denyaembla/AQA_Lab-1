using System;
using Allure_Reporting.Services;
using Allure_Reporting.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Allure_Reporting.Tests;

public class BaseTest
{
    protected static IWebDriver _driver;
    protected LoginStep _loginStep;
    protected ShoppingStep _shoppingStep;
    protected CheckoutStep _checkoutStep;

    [SetUp]
    public void SetUp()
    {
        _driver = new BrowserService().Driver;
        _loginStep = new LoginStep(_driver);
        _shoppingStep = new ShoppingStep(_driver);
        _checkoutStep = new CheckoutStep(_driver);
    }

    [TearDown]
    public void TearDown()
    {
       _driver.Quit();
    }

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
