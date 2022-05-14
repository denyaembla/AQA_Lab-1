using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class ProjectPage : BasePage
{
    private static readonly By ProjectNameLocator = By.Id("navigation-project");
    private static readonly By AddMilestoneButtonLocator = By.Id("navigation-overview-addmilestones");
    
    public IWebElement ProjectName => WaitService.WaitUntilElementExists(ProjectNameLocator);
    
    public IWebElement AddMilestoneButton => WaitService.WaitUntilElementExists(AddMilestoneButtonLocator);

    public ProjectPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return ProjectNameLocator;
    }
}
