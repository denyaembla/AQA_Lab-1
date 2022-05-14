using BDDHomework.Clients;
using BDDHomework.Configuration;
using BDDHomework.Databases;
using BDDHomework.Models;
using BDDHomework.Services.ApiServices;
using BDDHomework.Services.SeleniumServices;
using BDDHomework.Steps;
using NLog;
using OpenQA.Selenium;

namespace BDDHomework.Hooks;

[Binding]
public class Hooks
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static RestClientExtended _restClientExtended = null!;

    private static ProjectService _adminProjectService = null!;
    private static MilestoneService _adminMilestoneService = null!;

    private static Project _fromDbProject = null!;
    private static Milestone _fromDbMilestoneToAdd = null!;
    private static Milestone _fromDbMilestoneToUpdateWith = null!;

    private static IWebDriver _driver = null!;

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        using (var dbConnector = new DataBaseConnector())
        {
            const int projectToAddDbId = 1;
            const int milestoneToAddDbId = 1;
            const int milestoneToUpdateWithDbId = 2;

            _restClientExtended = new RestClientExtended();
            _adminProjectService = new ProjectService(_restClientExtended);
            _adminMilestoneService = new MilestoneService(_restClientExtended);

            _fromDbProject = dbConnector.Projects.Find(projectToAddDbId) ??
                             throw new InvalidOperationException(
                                 $"No record with {projectToAddDbId} as primary key was found.");

            Logger.Info($"Successfully read {_fromDbProject.Name} from database.");

            _fromDbMilestoneToAdd = dbConnector.Milestones.Find(milestoneToAddDbId) ??
                                    throw new InvalidOperationException(
                                        $"No record with {milestoneToAddDbId} as primary key was found.");

            Logger.Info($"Successfully read {_fromDbMilestoneToAdd.Name} from database.");

            _fromDbMilestoneToUpdateWith = dbConnector.Milestones.Find(milestoneToUpdateWithDbId) ??
                                           throw new InvalidOperationException(
                                               $"No record with {milestoneToUpdateWithDbId} as primary key was found.");

            Logger.Info($"Successfully read {_fromDbMilestoneToUpdateWith.Name} from database.");
        }
    }

    [BeforeFeature, Scope(Tag = "UI")]
    public static void BeforeUiTest()
    {
        _driver = new BrowserService().Driver;
        _driver.Navigate().GoToUrl(Configurator.AppSettings.BaseUrl);
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        featureContext.Add("Driver", _driver);

        featureContext.Add("ProjectService", _adminProjectService);
        featureContext.Add("MilestoneService", _adminMilestoneService);

        featureContext.Add("FromDbProject", _fromDbProject);
        featureContext.Add("FromDbMilestoneToAdd", _fromDbMilestoneToAdd);
        featureContext.Add("FromDbMilestoneToUpdateWith", _fromDbMilestoneToUpdateWith);
    }

    [AfterFeature]
    public static void AfterFeature(FeatureContext featureContext)
    {
        featureContext.Remove("Driver");

        featureContext.Remove("ProjectService");
        featureContext.Remove("MilestoneService");

        featureContext.Remove("FromDbProject");
        featureContext.Remove("FromDbMilestoneToAdd");
        featureContext.Remove("FromDbMilestoneToUpdateWith");
    }

    [AfterFeature, Scope(Tag = "API")]
    public static void DeleteCreatedProject()
    {
        _adminProjectService.DeleteProject(BaseStepDefinition.OnSiteProject.Id.ToString());
    }

    [AfterFeature, Scope(Tag = "UI")]
    public static void AfterUiCloseDriverDeleteTestProject()
    {
        _driver.Quit();

        var projects = _adminProjectService.GetProjects().Result;
        var projectToDeleteId = projects.ProjectsList.First(project => project.Name == _fromDbProject.Name).Id;

        _adminProjectService.DeleteProject(projectToDeleteId.ToString());
    }
}

// TODO: The scopes of before- and after- methods should be updated when adding new features.
