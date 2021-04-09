using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Threading;

namespace SeleniumWebDriver
{
    public class Setups
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        public enum Browser
        {
            Chrome,
            Firefox,
            IE
        }
        public IWebDriver GetWebDriverForBrowser(Browser browser)
        {
            IWebDriver driver = null;

            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;

                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;

                case Browser.IE:
                    driver = new InternetExplorerDriver();
                    break;
            }

            if (driver != null)
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return driver;
        }
    }
}
