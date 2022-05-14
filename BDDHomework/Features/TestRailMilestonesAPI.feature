@API
Feature: TestRailMilestonesAPI
Milestones are associated with project and one of the best ways to track the progress and timeline. It is similar
to the small targets in a project. Milestones can be created, retrieved, updated and deleted. Both via website ui
and api calls.

Note: The following scenarios represent steps of one sequece.

    @API
    Scenario: 01) Create miletsone via API
    Checks if milestone can be created via API.

        Given user has created a project via API
        When user creates milestone
        Then milestone is created

    @API
    Scenario: 02) Retrieve miletsone via API
    Checks if milestone can be retrieved via API.

        When user retrieves milestone
        Then milestone is retrieved

    @API
    Scenario: 03) Update miletsone via API
    Checks if milestone can be updated via API.

        When user updates milestone's properties
        Then milestone's properties are updated

    @API
    Scenario: 04) Delete miletsone via API
    Checks if milestone can be deleted via API.

        When user deletes milestone
        Then milestone is deleted
