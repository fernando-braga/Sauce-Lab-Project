Feature: Logout

As a user
I want to be able to logout on application

@tag1
Scenario: Logout successfully
	
	Given I am logged on the products page
	And I click on the left hamburger menu
	When I click on Logout option
	Then I am logget out


@tag2
Scenario: Check if product remains in cart after log out and log in again
	
	Given I am logged on the products page
	And I click on Add To Cart for a product
	And I click on the left hamburger menu
	And I click on Logout option
	When I log on application again
	Then the product is still on the cart
