using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Configuration;

namespace SeleniumWebDriver
{
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    [TestFixture(Browser.IE)]
    [Parallelizable]
    public class CraigslistDemo : Setups
    {
        /// <summary>
        /// Basic demonstration of Selenium in C#
        /// </summary>
        public CraigslistDemo(Browser browser)
        {
            driver = GetWebDriverForBrowser(browser);
        }

        [Test]
        public void MountainBikeSearchTestCase()
        {
            WebDriverWait _wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["craigslistUrl"];

            // Search for Mountain Bike
            driver.FindElement(By.Id("query")).SendKeys("Mountain Bike" + Keys.Enter);

            // Refine search
            _wait.Until(d => d.FindElement(By.Name("hasPic")));
            driver.FindElement(By.Name("hasPic")).Click();
            driver.FindElement(By.Name("min_price")).SendKeys("250");
            driver.FindElement(By.Name("max_price")).SendKeys("500");

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

            Console.WriteLine(
                price + Environment.NewLine +
                postedText);
        }

    }
}
