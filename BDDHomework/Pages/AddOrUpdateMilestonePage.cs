using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class AddOrUpdateMilestonePage : BasePage
{
    private static readonly By NameFieldLocator = By.Id("name");
    private static readonly By DescriptionFieldLocator = By.Id("description_display");
    private static readonly By AddMilestoneButtonLocator = By.Id("accept");

    public IWebElement NameField => WaitService.WaitUntilElementExists(NameFieldLocator);

    public IWebElement DescriptionField => WaitService.WaitUntilElementExists(DescriptionFieldLocator);

    public IWebElement AddMilestoneButton => WaitService.WaitUntilElementExists(AddMilestoneButtonLocator);

    public AddOrUpdateMilestonePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return AddMilestoneButtonLocator;
    }
}
