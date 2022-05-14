@UI
Feature: TestRailMilestonesUI
Milestones are associated with project and one of the best ways to track the progress and timeline. It is similar
to the small targets in a project. Milestones can be created, retrieved, updated and deleted. Both via website ui
and api calls.

Note: The following scenarios represent steps of one sequece.

    @UI
    Scenario: 01) Create miletsone via UI
    Checks if milestone can be created via UI.

        Given user has authorized
        And user has created a project via UI
        When user clicks Add Milestone button
        And populates "new" milestone's data
        And submits the milestone's form
        Then the "new" milestone is displayed

    @UI
    Scenario: 02) Check miletsone via UI
    Checks if milestone can be entered into via UI.

        When user clicks on created milestone name
        Then the new milestone's page is displayed

    @UI
    Scenario: 03) Update miletsone via UI
    Checks if milestone can be updated via UI.

        When user clicks on edit button
        And populates "updated" milestone's data
        And submits the milestone's form
        Then the "updated" milestone is displayed

    @UI
    Scenario: 04) Delete miletsone via UI
    Checks if milestone can be updated via UI.

        When navigates to Milestones page
        And deletes the updated milestone
        Then milestone is not displayed
