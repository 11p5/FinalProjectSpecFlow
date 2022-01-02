Feature: Coupon
this feature is to see if the coupon works and is at 15%

@tag1
Scenario: see if the coupon works and it will be at 15%
	Given Tht we are on the the checkout page
	When we apply the coupon code into the system
	Then the coupon code we check that that it is 15%
	
