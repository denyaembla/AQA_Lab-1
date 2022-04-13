using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepOnePage : BasePage
{
    
    private const string END_POINT = "/checkout-step-one.html";
    
    private static readonly By FirstNameFieldId = By.Id("first-name");          //checkout step 1
    private static readonly By LastNameFieldId = By.Id("last-name");        //checkout step 1
    private static readonly By ZipFieldId = By.Id("postal-code");               //checkout step 1
    private static readonly By ContinueButtonId = By.Id("continue");            //checkout step 1
    private static readonly By CheckoutOneTitle = By.ClassName("title");             //ctrl+c -ed

    public IWebElement Title => Driver.FindElement(CheckoutOneTitle); //ctrl+c -ed
    public IWebElement FirstNameField = Driver.FindElement(FirstNameFieldId); //checkout step one
    public IWebElement LastNameField = Driver.FindElement(LastNameFieldId); //checkout step one
    public IWebElement ZipField = Driver.FindElement(ZipFieldId); //checkout step one
    public IWebElement ContinueButton = Driver.FindElement(ContinueButtonId); //checkout step one
    
    public CheckoutStepOnePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl){}
    protected override void OpenPage() => Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);

    protected override bool IsPageOpened()
    {
        try
        {
            return Title.Displayed;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    
}
