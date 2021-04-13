# SeleniumDemo
by Adam De King </br>

Basic demonstration of Selenium Web Driver with NUnit, using different drivers and different locators.</br>
Using parallelism to run multiple tests at once. (Currently set to 3) </br>
Includes Data Driven test with reading test data from an Excel file. </br>
API Tests using HttpClient for GET and POST requests. </br>
Database integration for logging. </br>


Specflow Craigslist Demo in Gherkin:
Feature: CraigslistDemo
	Craigslist Selenium Demonstration

@smoke
Scenario: Get top result for 'Mountain Bike' search
	Given I launch the appliction
	And I enter 'Mountain Bike' into the searchbox
	And I click 'has image'
	And I enter the price
		| MinPrice | MaxPrice |
		| 250      | 500      |
	And I scroll down
	And I click the 'update search' button
	And I click the top post
	Then I should get the top price and ad information


Also includes basic Craigslist test in basic Selenium: (Chrome, Firefox, and Internet Explorer, also in parallel) </br>
## Sample Test Case:
Go To: Bellingham Craigslist </br>
Search: "Mountain Bike" </br>
 </br>
In 'Advanced Search' frame: </br>
Select: 'has image' checkbox </br>
Select: price between $250 and $500 </br>
Click: 'update search' </br>
 </br>
In Search Results: </br>
Select: top post </br>
Return: 'Price' and 'Ad content' </br>
