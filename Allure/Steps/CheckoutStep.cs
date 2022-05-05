using Allure_Reporting.Pages;
using Allure_Reporting.Services;
using OpenQA.Selenium;

namespace Allure_Reporting.Steps;

public class CheckoutStep : BaseStep
{
    public CheckoutStep(IWebDriver driver) : base(driver)
    {
    }

    public CheckoutStepOnePage GoToFillingCheckout()
    {
        CartPage.CheckoutButton.Click();

        return CheckoutStepOnePage;
    }

    public CheckoutStepTwoPage FillInfoAndCheckout(
        string firstname,
        string lastname,
        string zipcode)
    {
        CheckoutStepOnePage.FirstNameField.SendKeys(firstname);
        CheckoutStepOnePage.LastNameField.SendKeys(lastname);
        CheckoutStepOnePage.ZipField.SendKeys(zipcode);
        CheckoutStepOnePage.ContinueButton.Click();

        return CheckoutStepTwoPage;
    }
    
    public CheckoutCompletePage FinishShopping()
    {
        CheckoutStepTwoPage.FinishButton.Click();
        
        return CheckoutCompletePage;
    }
}
