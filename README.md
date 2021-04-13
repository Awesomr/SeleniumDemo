# SeleniumDemo
by Adam De King </br>

Basic demonstration of Selenium Web Driver with NUnit, using different drivers and different locators.</br>
Using parallelism to run multiple tests at once. (Currently set to 3) </br>
Includes Data Driven test with reading test data from an Excel file. </br>
API Tests using HttpClient for GET and POST requests. </br>
Database integration for logging. </br>


Specflow Craigslist Demo in Gherkin: </br>
Feature: CraigslistDemo </br>
	Craigslist Selenium Demonstration </br>
 </br>
@smoke </br>
Scenario: Get top result for 'Mountain Bike' search </br>
	Given I launch the appliction </br>
	And I enter 'Mountain Bike' into the searchbox </br>
	And I click 'has image' </br>
	And I enter the price </br>
		| MinPrice | MaxPrice | </br>
		| 250      | 500      | </br>
	And I scroll down </br>
	And I click the 'update search' button </br>
	And I click the top post </br>
	Then I should get the top price and ad information </br>
 </br>

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
