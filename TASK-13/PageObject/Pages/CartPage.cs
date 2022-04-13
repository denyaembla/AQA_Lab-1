using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CartPage : BasePage
{
    private const string END_POINT = "/cart.html";
    
    private static readonly By TitleBy = By.CssSelector("span[class='title']");
    private static readonly By ItemsToBuyCollectionLocator = By.XPath("//div[@class='inventory_item_name']");
    private static readonly By GoToCheckoutButtonId = By.Id("checkout");
    
    public  List<IWebElement> ItemsToBuy => new (Driver.FindElements(ItemsToBuyCollectionLocator));
    public  IWebElement CartpageTitle => Driver.FindElement(TitleBy);
    public  IWebElement CheckoutButton => Driver.FindElement(GoToCheckoutButtonId);

    public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    protected override void OpenPage() => Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);

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
