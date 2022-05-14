using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class DashboardPage : BasePage
{
    private static readonly By AddProjectButtonLocator = By.Id("sidebar-projects-add");
    
    public IWebElement AddProjectButton => WaitService.WaitUntilElementExists(AddProjectButtonLocator);

    public DashboardPage(IWebDriver driver) : base(driver)
    {
    }

    private static By ProjectNameLocator(string projectName) =>
        By.XPath($"//div[@id = 'content_container'] // *[text() = '{projectName}']");

    public IWebElement ProjectName(string projectName) =>
        WaitService.WaitUntilElementExists(ProjectNameLocator(projectName));

    protected override By GetPageIdentifier()
    {
        return AddProjectButtonLocator;
    }
}
