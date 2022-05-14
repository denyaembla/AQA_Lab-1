using BDDHomework.Pages;
using NUnit.Framework;

namespace BDDHomework.Steps.UiStepDefinitions;

[Binding]
public class ProjectUiStepDefinitions : BaseStepDefinition
{
    private readonly DashboardPage _dashboardPage;
    private readonly AddProjectPage _addProjectPage;
    private readonly ProjectsAdministrationPage _projectsAdministrationPage;

    public ProjectUiStepDefinitions(FeatureContext featureContext) : base(featureContext)
    {
        _dashboardPage = new DashboardPage(Driver);
        _addProjectPage = new AddProjectPage(Driver);
        _projectsAdministrationPage = new ProjectsAdministrationPage(Driver);
    }

    [Given(@"user has created a project via UI")]
    public void GivenUserHasCreatedAProjectViaUi()
    {
        UserClicksAddProjectButton();
        
        Assert.That(_addProjectPage.PageOpened, "Add project page wasn't opened.");

        UserPopulatesProjectData(FromDbProject.Name, FromDbProject.Announcement);
        UserSubmitsProjectForm();
        
        Assert.That(_projectsAdministrationPage.PageOpened, "Project administration page wasn't opened.");
        
        UserClicksDashboardNavigationButton();

        Assert.That(_dashboardPage.PageOpened, "Dashboard page wasn't opened.");

        UserOpensSpecificProjectPage(FromDbProject.Name);
    }

    private void UserClicksAddProjectButton()
    {
        _dashboardPage.AddProjectButton.Click();
    }
    
    private void UserPopulatesProjectData(string projectName, string projectDescription)
    {
        _addProjectPage.NameField.SendKeys(projectName);
        _addProjectPage.AnnouncementField.SendKeys(projectDescription);
    }

    private void UserSubmitsProjectForm()
    {
        _addProjectPage.AddProjectButton.Click();
    }

    private void UserClicksDashboardNavigationButton()
    {
        _projectsAdministrationPage.DashboardNavigationButton.Click();
    }

    private void UserOpensSpecificProjectPage(string projectName)
    {
        _dashboardPage.ProjectName(projectName).Click();
    }
    
    // DEVNOTE: Private methods here can be used as whens and thens for other scenarios which don't exist yet.
}
