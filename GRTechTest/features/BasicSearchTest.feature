Feature: BasicSearchTest
	Amazon has a robust search feature

@GRTest
Scenario Outline: Handle basic searches
	Given I am on Amazon
	When I search for a <product>
	Then I recieve results for that <product>
	Then I end my test
	
	Examples:
	| product                                         |
	| LG 24UD58-B 24-Inch 4k Monitor                  |
	| Metasploit: The Penetration Tester's Guide Book |
	| Cat Cup                                         |
	| skjhgagfagfaafafga                              |