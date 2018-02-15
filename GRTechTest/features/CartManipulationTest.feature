Feature: CartManipulationTest
	Amazon has a robust shopping cart

@GRTest
Scenario: Cart Manipulation
	Given I am on Amazon
	When I add 3 products 
	Then I see my products in my shopping cart 
	And if I remove an item
	Then I will not see the deleted item
	Then I end my test
