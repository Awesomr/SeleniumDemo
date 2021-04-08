using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    class BasicAuthPage
    {
        private static readonly string _userName = "admin";
        private static readonly string _password = "admin";

        public static void BasicAuth(IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl($"https://{_userName}:{_password}@the-internet.herokuapp.com/basic_auth");

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
    }
}
