namespace BDDHomework.Steps.ApiStepDefinitions;

[Binding]
public sealed class ProjectApiStepDefinitions : BaseStepDefinition
{
    public ProjectApiStepDefinitions(FeatureContext featureContext) : base(featureContext)
    {
    }

    [Given(@"user has created a project via API"), Scope(Tag = "API")]
    public void GivenUserHasCreatedAProjectViaApi()
    {
        var newProject = FromDbProject;

        OnSiteProject = ProjectService.AddProject(newProject).Result;
    }
}
