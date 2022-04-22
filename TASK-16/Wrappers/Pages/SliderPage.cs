using System;
using OpenQA.Selenium;
using Wrappers.Services;

namespace Wrappers.Pages;

public class SliderPage : BasePage
{
    public SliderPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.SliderUrl);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return Title.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private By TitleLocator = By.XPath("//div[@class='example']/h3");
    private By SliderLocator = By.XPath("//div[@class='sliderContainer']/input");
    private By RangeId = By.Id("range");


    public IWebElement Title => WaitService.WaitForElementExists(TitleLocator);
    public IWebElement Slider => WaitService.WaitForElementExists(SliderLocator);
    public IWebElement Range => WaitService.WaitForElementExists(RangeId);
}
