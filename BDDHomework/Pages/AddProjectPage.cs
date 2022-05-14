using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class AddProjectPage : BasePage
{
    private static readonly By NameFieldLocator = By.Id("name");
    private static readonly By AnnouncementFieldLocator = By.Id("announcement");
    private static readonly By AddProjectButtonLocator = By.Id("accept");

    public IWebElement NameField => WaitService.WaitUntilElementExists(NameFieldLocator);

    public IWebElement AnnouncementField => WaitService.WaitUntilElementExists(AnnouncementFieldLocator);

    public IWebElement AddProjectButton => WaitService.WaitUntilElementExists(AddProjectButtonLocator);

    public AddProjectPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return AddProjectButtonLocator;
    }
}
