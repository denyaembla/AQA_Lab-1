using System;
using System.Collections.ObjectModel;
using JsExecutor.Services;
using OpenQA.Selenium;

namespace JsExecutor.Pages;

public class OnlinerPage : BasePage
{
    private static readonly By TitleLocator = By.CssSelector(".onliner_logo");
    private static readonly By SearchBarLocator = By.CssSelector("[name = 'query']");
    private static readonly By SearchFrameLocator = By.CssSelector(".modal-iframe");
    private static readonly By FirstResultItemLocator = By.CssSelector(".result__item .product__details .product__title-link");
    private static readonly By InFrameSearchBarLocator = By.CssSelector(".search__input");

    public IWebElement Title => WaitService.WaitUntilElementExists(TitleLocator);
    public IWebElement SearchBar => WaitService.WaitUntilElementExists(SearchBarLocator);
    public IWebElement SearchFrame => WaitService.WaitUntilElementExists(SearchFrameLocator);
    public IWebElement FirstResultItem => WaitService.WaitUntilElementExists(FirstResultItemLocator);
    public IWebElement InFrameSearchBar => WaitService.WaitUntilElementExists(InFrameSearchBarLocator);
        
    public OnlinerPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.OnlinerUrl);
    }
    
    protected override bool IsPageOpened()
    {
        try
        {
            return Title.Displayed;
        }
        catch (NullReferenceException)
        {
            return false;
        }
    }
}
