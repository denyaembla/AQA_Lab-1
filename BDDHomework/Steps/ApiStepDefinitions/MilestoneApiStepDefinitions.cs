using System.Net;
using BDDHomework.Clients;
using BDDHomework.Models;
using NUnit.Framework;

namespace BDDHomework.Steps.ApiStepDefinitions;

[Binding]
public sealed class MilestoneApiStepDefinitions : BaseStepDefinition
{
    private Milestone _gotMilestone = null!;
    private HttpStatusCode _deletionCallStatusCode;

    public MilestoneApiStepDefinitions(FeatureContext featureContext) : base(featureContext)
    {
    }

    [When(@"user creates milestone"), Given(@"user has created milestone"), Scope(Tag = "API")]
    public void WhenUserCreatesMilestone()
    {
        OnSiteMilestone = MilestoneService.AddMilestone(FromDbMilestoneToAdd, OnSiteProject.Id.ToString()).Result;
    }

    [Then(@"milestone is created"), Given(@"milestone has been created"), Scope(Tag = "API")]
    public void ThenMilestoneIsCreated()
    {
        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode,
                $"Milestone creation status code is not {HttpStatusCode.OK}.");

            Assert.AreEqual(FromDbMilestoneToAdd.Name, OnSiteMilestone.Name,
                $"Created on server milestone's name should be {FromDbMilestoneToAdd.Name}.");

            Assert.AreEqual(FromDbMilestoneToAdd.Description, OnSiteMilestone.Description,
                $"Created on server milestone's description should be {FromDbMilestoneToAdd.Description}.");

            Assert.AreEqual(FromDbMilestoneToAdd.Refs, OnSiteMilestone.Refs,
                $"Created on server milestone's refs should be {FromDbMilestoneToAdd.Refs}.");
        });
    }

    [When(@"user retrieves milestone"), Scope(Tag = "API")]
    public void WhenUserRetrievesMilestone()
    {
        _gotMilestone = MilestoneService.GetMilestone(OnSiteMilestone.Id.ToString()).Result;
    }

    [Then(@"milestone is retrieved"), Scope(Tag = "API")]
    public void ThenMilestoneIsRetrieved()
    {
        var addedMilestone = OnSiteMilestone;

        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode,
                $"Get milestone status code is not {HttpStatusCode.OK}.");

            Assert.AreEqual(addedMilestone.Name, _gotMilestone.Name,
                $"Retrieved milestone's name should be {addedMilestone.Name}.");

            Assert.AreEqual(addedMilestone.Description, _gotMilestone.Description,
                $"Retrieved milestone's description should be {addedMilestone.Description}.");

            Assert.AreEqual(addedMilestone.Refs, _gotMilestone.Refs,
                $"Retrieved milestone's refs should be {addedMilestone.Refs}.");
        });
    }

    [When(@"user updates milestone's properties"), Scope(Tag = "API")]
    public void WhenUserUpdatesMilestonesName()
    {
        FromDbMilestoneToUpdateWith.Id = OnSiteMilestone.Id;

        OnSiteMilestone = MilestoneService.UpdateMilestone(FromDbMilestoneToUpdateWith).Result;
    }

    [Then(@"milestone's properties are updated"), Scope(Tag = "API")]
    public void ThenMilestonesNameIsUpdated()
    {
        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode,
                $"Milestone update status code is not {HttpStatusCode.OK}.");

            Assert.AreEqual(FromDbMilestoneToUpdateWith.Name, OnSiteMilestone.Name,
                $"Updated milestone's name is not {FromDbMilestoneToUpdateWith.Name}.");

            Assert.AreEqual(FromDbMilestoneToUpdateWith.Description, OnSiteMilestone.Description,
                $"Updated milestone's description is not {FromDbMilestoneToUpdateWith.Description}.");

            Assert.AreEqual(FromDbMilestoneToUpdateWith.Refs, OnSiteMilestone.Refs,
                $"Updated milestone's refs is not {FromDbMilestoneToUpdateWith.Refs}.");

            Assert.AreEqual(FromDbMilestoneToUpdateWith.IsStarted, OnSiteMilestone.IsStarted,
                $"Updated milestone's IsStarted field is not set to {FromDbMilestoneToUpdateWith.IsStarted}");
        });
    }

    [When(@"user deletes milestone"), Scope(Tag = "API")]
    public void WhenUserDeletesMilestone()
    {
        _deletionCallStatusCode = MilestoneService.DeleteMilestone(OnSiteMilestone.Id.ToString());
    }

    [Then(@"milestone is deleted"), Scope(Tag = "API")]
    public void ThenMilestoneIsDeleted()
    {
        Assert.AreEqual(HttpStatusCode.OK, _deletionCallStatusCode,
            $"Milestone deletion status code is not {HttpStatusCode.OK}.");

        var milestonesAfterDeletion = MilestoneService.GetMilestones(OnSiteProject.Id.ToString()).Result;
        Assert.AreEqual(0, milestonesAfterDeletion.MilestoneList.Length, "Milestone wasn't deleted.");
    }
}
