using System;
using JsExecutor.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JsExecutor.Tests;

public abstract class BaseTest
{
    [ThreadStatic] private static IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        _driver = new BrowserService().WebDriver;
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }

    protected static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
