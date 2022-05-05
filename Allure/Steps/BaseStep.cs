using Allure_Reporting.Pages;
using OpenQA.Selenium;

namespace Allure_Reporting.Steps;

public class BaseStep
{
    private IWebDriver _driver;

    protected LoginPage LoginPage;
    protected InventoryPage InventoryPage;
    protected CartPage CartPage;
    protected CheckoutStepOnePage CheckoutStepOnePage;
    protected CheckoutStepTwoPage CheckoutStepTwoPage;
    protected CheckoutCompletePage CheckoutCompletePage;

    public BaseStep(IWebDriver driver)
    {
        _driver = driver;

        LoginPage = new LoginPage(_driver);
        InventoryPage = new InventoryPage(_driver);
        CartPage = new CartPage(_driver);
        CheckoutStepOnePage = new CheckoutStepOnePage(_driver);
        CheckoutStepTwoPage = new CheckoutStepTwoPage(_driver);
        CheckoutCompletePage = new CheckoutCompletePage(_driver);
    }
    
    public static string GetDataOfElementByClassNameUsingJsExecutor(IWebDriver driver,
        string classNameLocator, int childNode, string type)
    {
        var js = (IJavaScriptExecutor)driver;
        var result = js.ExecuteScript(
                $"return document.getElementsByClassName('{classNameLocator}')[0].childNodes[{childNode}].{type};")
            .ToString();
    
        return result;
    }
}
