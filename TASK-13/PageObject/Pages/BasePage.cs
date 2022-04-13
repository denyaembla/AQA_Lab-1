using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Pages;

public abstract class BasePage
{
    private const int WaitForPageLoadingTime = 60;
    [ThreadStatic] private static IWebDriver _driver;
    protected abstract void OpenPage();
    protected abstract bool IsPageOpened();
    
    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;

        if (openPageByUrl)
        {
            OpenPage();
        }

        WaitForOpening();
    }
    
    private void WaitForOpening()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (!isPageOpenedIndicator && secondsCount < WaitForPageLoadingTime)
        {
            Thread.Sleep(1000);
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();
        }

        if (!isPageOpenedIndicator)
        {
            throw new AssertionException("Page wasn't opened");
        }
    }
}
