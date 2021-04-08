using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace SeleniumWebDriver
{
    public class Homepage
    {
        IWebDriver driver;
        private string baseUrl = "https://the-internet.herokuapp.com/";

        private By basicAuth = By.LinkText("Basic Auth");
        private By addRemoveElement = By.LinkText("Add/Remove Elements");
        private By brokenImages = By.LinkText("Broken Images");
        private By checkboxes = By.LinkText("Checkboxes");
        private By dropdown = By.LinkText("Dropdown");




        // private By  = By.LinkText("");

        [SetUp]
        public void SetupBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = baseUrl;
        }

        [TearDown]
        public void Shutdown()
        {
            driver.Close();
        }

        [Test]
        public void BasicAuth()
        {
            driver.FindElement(basicAuth).Click();
            BasicAuthPage.BasicAuth(driver);           
        }

        [Test]
        public void BrokenImages()
        {
            driver.FindElement(brokenImages).Click();
            BrokenImagesPage.BrokenImagesTest(driver);
        }

        [Test]
        public void AddRemoveElements()
        {
            driver.FindElement(addRemoveElement).Click();
            AddRemoveElementsPage.AddRemoveElementsTest(driver);
        }

        [Test]
        public void Checkboxes()
        {
            driver.FindElement(checkboxes).Click();
            CheckboxesPage.CheckboxesTest(driver);
        }

        [Test]
        public void Dropdown()
        {  
            driver.FindElement(dropdown).Click();
            DropdownPage.DropdownTest(driver);
        }


    }
}
