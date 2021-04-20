using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;
using static SeleniumWebDriver.Setups;

namespace SeleniumWebDriver.DataDrivenTests
{
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    [TestFixture(Browser.IE)]
    [Parallelizable]
    public class DataDrivenCLTests
    {
        IWebDriver driver;
        string useBrowser;
        private Browser browser;
        string search;

        public DataDrivenCLTests(Browser browser)
        {
            //var dr = new Setups();
            //driver = dr.GetWebDriverForBrowser(browser);
            this.browser = browser;
        }

        [Test]
        public void CraigslistDataDrivenTests()
        {
            try
            {
                // Get Data:
                var db = new ReadFromDb();
                var numTests = db.GetNumberOfSearches();

                var i = 1;
                while (i <= numTests)
                {
                    var data = db.GetSearchData(i);
                    search = data.SearchTerm;

                    // Fire up the driver:
                    DriverReset(browser);
                    WebDriverWait _wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                    driver.Manage().Window.Maximize();
                    driver.Url = ConfigurationManager.AppSettings["craigslistUrl"];

                    // Search for Mountain Bike
                    driver.FindElement(By.Id("query")).SendKeys(search + Keys.Enter);

                    // Refine search
                    _wait.Until(d => d.FindElement(By.Name("hasPic")));

                    if (data.HasImage) driver.FindElement(By.Name("hasPic")).Click();
                    if (data.PostedToday) driver.FindElement(By.Name("postedToday")).Click();
                    if (data.IncludeNearby) driver.FindElement(By.Name("searchNearby")).Click();


                    driver.FindElement(By.Name("min_price")).SendKeys(data.MinPrice.ToString());
                    driver.FindElement(By.Name("max_price")).SendKeys(data.MaxPrice.ToString());

                    driver.FindElement(By.Id("all-purveyor")).SendKeys(Keys.PageDown + Keys.PageDown);
                    Thread.Sleep(1000);

                    // Click 'update search'
                    driver.FindElement(By.CssSelector(
                        "#searchform > div.search-options-container > div.search-options > div.searchgroup.resetsearch > button"))
                        .Click();

                    // Click on top post
                    driver.FindElement(By.ClassName("result-title")).Click();

                    // Get Posting price and text
                    var price = driver.FindElement(By.ClassName("price")).Text;
                    var postedText = driver.FindElement(By.Id("postingbody")).Text;

                    price = price.Replace("$", "");
                    decimal postedPrice = Convert.ToDecimal(price);

                    WriteToLog.Log(useBrowser, data.SearchTerm, "pass", postedPrice, postedText, "");
                    Console.WriteLine("Passed. See logs for details.");

                    driver.Close();
                    i++;
                }
            }
            catch (Exception e)
            {
                WriteToLog.Log(useBrowser, search, "fail", 0, "", e.ToString());
                Console.WriteLine($"fail {e.ToString()}");
            }
        }


        public void DriverReset(Browser browser)
        {
            // Used for running multiple tests under same TestFixture
            try
            {
                driver.Close();
            }
            catch
            {
                // do nothing
            }
            var dr = new Setups();
            driver = dr.GetWebDriverForBrowser(browser);
            useBrowser = browser.ToString();
        }
    }
}


//Console.WriteLine($"Number of tests: {numTests}");



//Console.WriteLine($"Id: {data.Id}");
//Console.WriteLine($"Search: {data.SearchTerm}");
//Console.WriteLine($"Has Image: {data.HasImage}");
//Console.WriteLine($"Posted Today: {data.PostedToday}");
//Console.WriteLine($"Nearby: {data.IncludeNearby}");
//Console.WriteLine($"Min Price: {data.MinPrice}");
//Console.WriteLine($"Max Price: {data.MaxPrice}");
