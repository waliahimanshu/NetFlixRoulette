Feature: UserStories
	
@mytag
Scenario: Add two numbers
	Given A user running the command line application
	And I can supply a valid paramter on the command line
	When I hit return
    Then I can query the API for results

