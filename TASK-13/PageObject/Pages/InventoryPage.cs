using System;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class InventoryPage : BasePage
{
    private const string END_POINT = "/inventory.html";
    
    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By BackPackId = By.Id("item_4_title_link");
    private static readonly By BackToProductsId = By.Id("back-to-products");
    private static readonly By AddBackpackToCartId = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By GoToCard = By.CssSelector(".shopping_cart_badge");
    private static readonly By FlashlightId = By.Id("item_0_title_link");
    private static readonly By AddFlashlightToCartId = By.Id("add-to-cart-sauce-labs-bike-light");
    public InventoryPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl){}

    protected override void OpenPage() => Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);

    protected override bool IsPageOpened()
    {
        try
        {
            return InventoryPageTitle.Displayed;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public IWebElement InventoryPageTitle => Driver.FindElement(TitleBy);
    public IWebElement BackPack => Driver.FindElement(BackPackId);
    public IWebElement Flashlight => Driver.FindElement(FlashlightId);
    public IWebElement BackToProducts => Driver.FindElement(BackToProductsId);
    public IWebElement AddBackpackToCart => Driver.FindElement(AddBackpackToCartId);
    public IWebElement AddFlashlightToCart => Driver.FindElement(AddFlashlightToCartId);
    public IWebElement GoToCart => Driver.FindElement(GoToCard);
}
