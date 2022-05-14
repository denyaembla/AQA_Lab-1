using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class ProjectsAdministrationPage : BasePage
{
    private static readonly By DashboardNavigationButtonLocator = By.Id("navigation-dashboard");
    
    public IWebElement DashboardNavigationButton => WaitService.WaitUntilElementExists(DashboardNavigationButtonLocator);

    public ProjectsAdministrationPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return DashboardNavigationButtonLocator;
    }
}
