Feature: Login Functionality

As I user
I want to be able to enter credentials 
So I can login successfully on the application

@tag1

Scenario: Successful Login
	
	Given I enter valid credentials on home page
	Then I can login successfully and proceed to products page
