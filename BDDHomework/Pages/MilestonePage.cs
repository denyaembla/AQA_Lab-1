using OpenQA.Selenium;

namespace BDDHomework.Pages; 

public class MilestonePage : BasePage
{
    private static readonly By MilestoneNameLocator = By.CssSelector("#content-header .content-header-title");
    private static readonly By EditButtonLocator = By.CssSelector("#content-header .button-edit");
    private static readonly By NavigationMilestonesButtonLocator = By.Id("navigation-milestones");
    
    public IWebElement MilestoneName => WaitService.WaitUntilElementExists(MilestoneNameLocator);
    
    public IWebElement EditButton => WaitService.WaitUntilElementExists(EditButtonLocator);
    
    public IWebElement NavigationMilestonesButton => WaitService.WaitUntilElementExists(NavigationMilestonesButtonLocator);
    
    public MilestonePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return MilestoneNameLocator;
    }
}
