Feature: FinalTest

A short summary of the feature
Background: 
Given that I am log in on the system
@tag1
Scenario:  purches and item of cloting with a discount
	Given I got the piece of cloting in cart
	When I apply a 15 percent discount code 
	Then to see if it work
	When I place the order 
	Then i check that the order number is persent in my order
