using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebDriver.Specflow.Features
{
    [Binding]
    public class CraigslistDemoSteps
    {
        CraigslistSearch craigslistSearch = null;

        [Given(@"I launch the appliction")]
        public void GivenILaunchTheAppliction()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["craigslistUrl"];
            craigslistSearch = new CraigslistSearch(driver);
        }
        
        [Given(@"I enter '(.*)' into the searchbox")]
        public void GivenIEnterIntoTheSearchbox(string p0)
        {
            craigslistSearch.EnterSearchTerm(p0);
        }

        [Given(@"I click 'has image'")]
        public void GivenIClick()
        {
            craigslistSearch.ClickHasImage();
        }
        
        [Given(@"I enter the price")]
        public void GivenIEnterThePrice(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            craigslistSearch.EnterPriceRange((decimal)data.MinPrice, (decimal)data.MaxPrice);
        }

        [Given(@"I scroll down")]
        public void GivenIScrollDown()
        {
            craigslistSearch.SearchFormPageDown();
        }

        [Given(@"I click the 'update search' button")]
        public void GivenIClickTheButton()
        {
            craigslistSearch.ClickUpdateSearch();
        }
        
        [Given(@"I click the top post")]
        public void GivenIClickTheTopPost()
        {
            craigslistSearch.ClickTopPostOfUpdatedSearch();
        }
        
        [Then(@"I should get the top price and ad information")]
        public void ThenIShouldGetTheTopPriceAndAdInformation()
        {
            var price = craigslistSearch.GetListingPrice();
            var ad = craigslistSearch.GetAdContent();

            decimal decPrice = Convert.ToDecimal(price.Replace("$", ""));

            Assert.IsTrue(decPrice < 501 && decPrice > 249);
            Assert.IsTrue(ad != null);

            
        }
        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            craigslistSearch.WebDriver.Dispose();            
        }

    }
}
