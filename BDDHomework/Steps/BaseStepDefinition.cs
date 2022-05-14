using BDDHomework.Models;
using BDDHomework.Services.ApiServices;
using OpenQA.Selenium;

namespace BDDHomework.Steps;

public class BaseStepDefinition
{
    protected readonly ProjectService ProjectService;
    protected readonly MilestoneService MilestoneService;
    
    protected static Project FromDbProject = null!;
    protected static Milestone FromDbMilestoneToAdd = null!;
    protected static Milestone FromDbMilestoneToUpdateWith = null!;
    
    protected IWebDriver Driver { get; }

    protected internal static Project OnSiteProject { get; protected set; } = null!;
    
    protected static Milestone OnSiteMilestone { get; set; } = null!;
    
    protected BaseStepDefinition(FeatureContext featureContext)
    {
        ProjectService = (ProjectService) featureContext["ProjectService"];
        MilestoneService = (MilestoneService) featureContext["MilestoneService"];
        
        FromDbProject = (Project) featureContext["FromDbProject"];
        FromDbMilestoneToAdd = (Milestone) featureContext["FromDbMilestoneToAdd"];
        FromDbMilestoneToUpdateWith = (Milestone) featureContext["FromDbMilestoneToUpdateWith"];
        
        Driver = (IWebDriver) featureContext["Driver"];
    }
}
