Feature: Product Page

As a user
I want to be able to navigate through product page's functionalities
So I can add products to the cart, remove and make a purchase

@tag1
Scenario: Add product to cart

Given I am on the products page
When I click on Add To Cart for a product
Then the product should be added to my cart and the cart icon must display a number in red

@tag2
Scenario: Remove product from cart

Given I am on the products page
And I have a product added in my cart
When I click on Remove button
Then the red number displayed on the cart icon must be subtracted

@tag3
Scenario: Add more than one product to cart

Given I am on the products page
When I add more than one product product to cart
Then the red number displayed is equal to the number of products I added

@tag4
Scenario: View Cart

Given I am on the products page
And I have a product added in my cart
When I click on the cart icon
Then I must be able to proceed to Checkout page, Continue Shopping and Remove product

@tag5
Scenario: Complete purchase from cart

Given I am on the products page
And I have a product added in my cart
When I click on the cart icon
And I click on the checkout button
And I enter valid checkout information
Then I should be able to complete the purchase

@tag6
Scenario: Complete the purchase through the product list page

Given I am on the products page
And I click on a product from the list
And I add the product to cart
When I click on the cart icon
And I click on the checkout button
And I enter valid checkout information
Then I should be able to complete the purchase