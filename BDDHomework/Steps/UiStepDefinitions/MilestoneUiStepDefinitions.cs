using BDDHomework.Pages;
using NUnit.Framework;

namespace BDDHomework.Steps.UiStepDefinitions;

[Binding]
public class MilestoneUiStepDefinitions : BaseStepDefinition
{
    private readonly ProjectPage _projectPage;
    private readonly AddOrUpdateMilestonePage _addOrUpdateMilestonePage;
    private readonly MilestonesNavigationPage _milestonesNavigationPage;
    private readonly MilestonePage _milestonePage;

    public MilestoneUiStepDefinitions(FeatureContext featureContext) : base(featureContext)
    {
        _projectPage = new ProjectPage(Driver);
        _addOrUpdateMilestonePage = new AddOrUpdateMilestonePage(Driver);
        _milestonesNavigationPage = new MilestonesNavigationPage(Driver);
        _milestonePage = new MilestonePage(Driver);
    }

    [When(@"user clicks Add Milestone button")]
    public void WhenUserClicksAddMilestoneButton()
    {
        Assert.That(_projectPage.ProjectName.Displayed, "Can't proceed without Project Page being opened.");

        _projectPage.AddMilestoneButton.Click();
    }

    [When((@"populates ""(.*)"" milestone's data"))]
    public void WhenPopulatesMilestoneData(string flag)
    {
        Assert.That(_addOrUpdateMilestonePage.PageOpened, "Can't proceed without Add/Update Milestone Page being opened.");

        var nameToInsert = flag == "updated" ? FromDbMilestoneToUpdateWith.Name : FromDbMilestoneToAdd.Name;

        if (flag == "updated")
        {
            _addOrUpdateMilestonePage.NameField.Clear();
        }

        _addOrUpdateMilestonePage.NameField.SendKeys(nameToInsert);
    }

    [When(@"submits the milestone's form")]
    public void WhenSubmitsTheMilestonesForm()
    {
        _addOrUpdateMilestonePage.AddMilestoneButton.Click();
    }

    [Then(@"the ""(.*)"" milestone is displayed")]
    public void ThenTheMilestoneIsDisplayed(string flag)
    {
        if (flag == "updated")
        {
            Assert.That(_milestonePage.MilestoneName.Text.Equals(FromDbMilestoneToUpdateWith.Name), 
                "Updated milestone's name wasn't found.");

            return;
        }

        Assert.That(_milestonesNavigationPage.PageOpened, "Milestone navigation page wasn't opened.");
        Assert.That(_milestonesNavigationPage.MilestoneName(FromDbMilestoneToAdd.Name).Displayed,
            "Added/updated milestone wasn't found in milestones list.");
    }

    [When(@"user clicks on created milestone name")]
    public void WhenUserClicksOnCreatedMilestoneName()
    {
        _milestonesNavigationPage.MilestoneName(FromDbMilestoneToAdd.Name).Click();
    }

    [Then(@"the new milestone's page is displayed")]
    public void ThenTheNewMilestonesPageIsDisplayed()
    {
        Assert.That(_milestonePage.PageOpened, "Created milestone's page wasn't opened.");
    }

    [When(@"user clicks on edit button")]
    public void WhenUserClicksOnEditButton()
    {
        _milestonePage.EditButton.Click();
    }

    [When(@"navigates to Milestones page")]
    public void WhenNavigatesToMilestonesPage()
    {
        _milestonePage.NavigationMilestonesButton.Click();
    }

    [When(@"deletes the updated milestone")]
    public void WhenDeletesTheUpdatedMilestone()
    {
        _milestonesNavigationPage.DeleteButton.Click();
        _milestonesNavigationPage.DialogOkButton.Click();
    }

    [Then(@"milestone is not displayed")]
    public void ThenMilestoneIsNotDisplayed()
    {
        Assert.That(_milestonesNavigationPage.NoMilestonesYetMessage.Displayed);
    }
}
