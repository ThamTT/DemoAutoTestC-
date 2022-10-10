Feature: Login

@mytag
Scenario: Perform login to the application
	Given Open the application
	When I Input value to field 
		| Field			| Value			|
		|   Username    |  admin		|
		|     Password  |  123abc		|
	And I click login button
	Then Check message error should be shown

@tag
Scenario Outline: Login with invalid details
	Given Open the application
	When I Input value to field
		| Field    | Value      |
		| Username | <username> |
		| Password | <password> |
	And I click login button
	Then Verify <Message> error should be shown

Examples:
	| username | password | Message |
	| admin    | 123      |  Invalid username or password. Please try again.       |
	|          | 123abc   |   Invalid username or password. Please try again.      |
