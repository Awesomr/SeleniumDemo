# SeleniumDemo
by Adam De King </br>

Basic demonstration of Selenium Web Driver with NUnit, using different drivers and different locators.</br>
Using parallelism to run multiple tests at once. (Currently set to 3) </br>
Includes Data Driven test with reading test data from an Excel file. </br>
API Tests using HttpClient for GET and POST requests. </br>
Database integration for logging. </br>


## Specflow Craigslist Demo in Gherkin: </br>
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

## Also includes basic Craigslist test using database lookups:  </br>
(Chrome, Firefox, and Internet Explorer, also in parallel) </br>
</br>
![database search img](./images/SqlSearchTable.jpg)
</br>
![Test Explorer img](./images/TestExplorer.jpg)
</br>
Results are saved to a logging table. </br>
![database logs img](./images/SqlLogsTable.jpg)
</br>

