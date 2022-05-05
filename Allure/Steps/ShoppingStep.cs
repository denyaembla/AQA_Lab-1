using Allure_Reporting.Pages;
using OpenQA.Selenium;

namespace Allure_Reporting.Steps;

public class ShoppingStep : BaseStep
{
    public ShoppingStep(IWebDriver driver) : base(driver)
    {
    }

    public InventoryPage AddItemToCartAndReturn(int itemNumber)
    {
        InventoryPage.ItemsCollection[itemNumber].Click();
        InventoryPage.AddToCartGeneric.Click();
        InventoryPage.BackToProducts.Click();

        return InventoryPage;
    }

    public CartPage GoToFirstCheckout()
    {
        InventoryPage.GoToCart.Click();
        return CartPage;
    }
}
