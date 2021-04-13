Feature: CraigslistDemo
	Craigslist Selenium Demonstration

@smkoke
Scenario: Get top result for 'Mountain Bike' search
	Given I launch the appliction
	And I enter 'Mountain Bike' into the searchbox
	And I hit 'Enter'
	And I click 'search'
	And I click 'has image'
	And I enter the price
		| Min Price | Max Price |
		| 250       | 500       |
	And I scroll down
	And I click the 'update search' button
	And I click the top post
	Then I should get the top price and ad information
	