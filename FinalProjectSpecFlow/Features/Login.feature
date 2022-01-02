Feature: Login

This is act one for the login page

@tag1
Scenario: Using Username and password to login the site
	Given That we are on the login page 
	When That the "username" and "password"
	And The submit button is pressed
	Then The page is logged in 
