using System;
using Alerts_and_Waiters.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Alerts_and_Waiters.Tests;

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


    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}