using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class Homepage : Setups
    {
        private Browser browser;
        private string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        private readonly By basicAuth = By.LinkText("Basic Auth");
        private readonly By addRemoveElement = By.LinkText("Add/Remove Elements");
        private readonly By brokenImages = By.LinkText("Broken Images");
        private readonly By checkboxes = By.LinkText("Checkboxes");
        private readonly By dropdown = By.LinkText("Dropdown");
        private readonly By formAuthentication = By.LinkText("Form Authentication");

        public Homepage(Browser browser)
        {
            this.browser = browser;
        }

        [Test]
        public void BasicAuth()
        {
            DriverReset(browser);
            driver.FindElement(basicAuth).Click();
            BasicAuthPage.BasicAuth(driver);
        }

        [Test]
        public void BrokenImages()
        {
            DriverReset(browser);
            driver.FindElement(brokenImages).Click();
            BrokenImagesPage.BrokenImagesTest(driver);
        }

        [Test]
        public void AddRemoveElements()
        {
            DriverReset(browser);
            driver.FindElement(addRemoveElement).Click();
            AddRemoveElementsPage.AddRemoveElementsTest(driver);
        }

        [Test]
        public void Checkboxes()
        {
            DriverReset(browser);
            driver.FindElement(checkboxes).Click();
            CheckboxesPage.CheckboxesTest(driver);
        }

        [Test]
        public void Dropdown()
        {
            DriverReset(browser);
            driver.FindElement(dropdown).Click();
            DropdownPage.DropdownTest(driver);
        }

        [Test]
        public void FormAuthentication()
        {
            DriverReset(browser);
            driver.FindElement(formAuthentication).Click();
            FormAuthenticationPage.FormAuthenticationTest(driver);
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

            driver = GetWebDriverForBrowser(browser);
            driver.Manage().Window.Maximize();
            driver.Url = baseUrl;
        }
    }
}