using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private By challengingDom = By.LinkText("Challenging DOM");
        private By checkboxes = By.LinkText("Checkboxes");
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
            var userName = "admin";
            var passWord = "admin";

            driver.Manage().Cookies.DeleteAllCookies();

            driver.FindElement(basicAuth).Click();
            driver.Navigate().GoToUrl($"https://{userName}:{passWord}@the-internet.herokuapp.com/basic_auth");

            // Message
            var message = driver.FindElement(By.CssSelector("#content > div > p"));
            Assert.IsTrue(message.Text.Contains
                ("Congratulations! You must have the proper credentials."),
                "Incorrect message displayed.");

            if (driver.PageSource.Contains("Not authorized"))
            {
                Console.WriteLine("Not authorized, incorrect credentials");
            }
            
            Console.WriteLine("Basic Auth pass");
        }

        [Test]
        public void BrokenImages()
        {
            driver.FindElement(brokenImages).Click();

            // Broken Image
            var brokenImage = driver.FindElement(By.CssSelector("#content > div > img:nth-child(2)"));

            Boolean isImageLoaded = (Boolean)((IJavaScriptExecutor)driver)
                .ExecuteScript("return arguments[0].complete && typeof arguments[0]" +
                ".naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", brokenImage);


            Console.WriteLine("Broken Image should return false: " + isImageLoaded);


            // Working image (banner "fork me on GitHub")
            var workingImage = driver.FindElement(By.CssSelector("body > div:nth-child(2) > a > img"));

            Boolean isImageLoaded2 = (Boolean)((IJavaScriptExecutor)driver)
                .ExecuteScript("return arguments[0].complete && typeof arguments[0]" +
                ".naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", workingImage);

            Console.WriteLine("Working Image should return true: " + isImageLoaded2);

            Assert.IsFalse(isImageLoaded, "Broken image shows.");
            Assert.IsTrue(isImageLoaded2, "Working image does not show");
        }

        [Test]
        public void AddRemoveElements()
        {
            driver.FindElement(addRemoveElement).Click();
            Thread.Sleep(500);
            // ensure 'Delete' button not present on page load.
            try
            {
                bool deleteButton = driver.FindElement(By.ClassName("added-manually")).Displayed;
                Assert.IsFalse(deleteButton, "Delete button present on page load.");
            }
            catch
            {
                Console.WriteLine("Delete button not present on page load, pass.");
            }


            // Click 'Add Element'
            driver.FindElement(By.CssSelector("#content > div > button")).Click();
            Thread.Sleep(500);

            // ensure 'Delete' button now present.
            try
            {
                bool deleteButton = driver.FindElement(By.ClassName("added-manually")).Displayed;
                Console.WriteLine("Delete button present after clicking 'Add Element,' pass.");
            }
            catch
            {
                Assert.Fail("Delete Button not present");
            }


            // Click 'Delete'
            driver.FindElement(By.ClassName("added-manually")).Click();
            Thread.Sleep(500);

            // Ensure 'Delete' button no longer displayed.
            try
            {
                bool deleteButton = driver.FindElement(By.ClassName("added-manually")).Displayed;
                Assert.IsFalse(deleteButton, "Delete button still present after 'delete' clicked.");
            }
            catch
            {
                Console.WriteLine("Delete button not present after 'delete' clicked, pass.");
            }
        }


    }
}
