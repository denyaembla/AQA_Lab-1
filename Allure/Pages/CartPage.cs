using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Allure_Reporting.Services;
using OpenQA.Selenium;

namespace Allure_Reporting.Pages;

public class CartPage : BasePage
{
    private const string END_POINT = "/cart.html";
    
    private static readonly By TitleBy = By.CssSelector("span[class='title']");
    private static readonly By ItemsToBuyCollectionLocator = By.XPath("//div[@class='inventory_item_name']");
    private static readonly By GoToCheckoutButtonId = By.Id("checkout");
    
    public  ReadOnlyCollection<IWebElement> ItemsToBuy => Driver.FindElements(ItemsToBuyCollectionLocator);
    public  IWebElement CartpageTitle => Driver.FindElement(TitleBy);
    public  IWebElement CheckoutButton => Driver.FindElement(GoToCheckoutButtonId);

    public CartPage(IWebDriver driver) : base(driver)
    {
    }
    protected override void OpenPage() => Driver.Navigate().GoToUrl(Configurator.Url + END_POINT);

    protected override bool IsPageOpened()
    {
        try
        {
            return CartpageTitle.Displayed;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    
    
    

}
