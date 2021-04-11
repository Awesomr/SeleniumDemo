using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    public static class FormAuthenticationPage
    {
        private static By userNameBox = By.Id("username");
        private static By passwordBox = By.Id("password");
        private static By loginButton = By.CssSelector("#login > button > i");
        private static By logoutButton = By.CssSelector("#content > div > a");


        public static void FormAuthenticationTest(IWebDriver driver)
        {
            var data = ReadData.GetDataFromExcelFile();
            var numberOfTests = (data.Length / 2) - 1;
            string currentUserName;
            string currentPassword;
           
            for (int i = 1; i < data.GetLength(0); i++)
            {
                currentUserName = data[i, 0].ToString();
                currentPassword = data[i, 1].ToString();

                driver.FindElement(userNameBox).SendKeys(currentUserName);
                driver.FindElement(passwordBox).SendKeys(currentPassword);
                Thread.Sleep(500);

                driver.FindElement(loginButton).Click();

                bool loggedIn = driver.PageSource.Contains("Secure Area");
                
                // Test for Pass:
                if (i != numberOfTests)
                {
                    Assert.IsTrue(loggedIn,
                    $"Credentials not working: {Environment.NewLine}" +
                    $"Username: {currentUserName}{Environment.NewLine}" +
                    $"Password: {currentPassword}{Environment.NewLine}");

                    driver.FindElement(logoutButton).Click();

                    Assert.IsTrue(driver.PageSource.Contains("You logged out of the secure area"),
                        "Did not log out of secure area");

                    Console.WriteLine($"{currentUserName} login, logout successful.");
                    Thread.Sleep(500);
                }

                // Test for Fail:
                else
                {
                    Assert.IsFalse(loggedIn,
                    $"Credentials worked that should not have: {Environment.NewLine}" +
                    $"Username: {currentUserName}{Environment.NewLine}" +
                    $"Password: {currentPassword}{Environment.NewLine}");

                    Console.WriteLine($"{currentUserName} login, logout failed as expected.");
                    Thread.Sleep(500);
                }
            }
        }

        
        public static void Print2DArray<T>(T[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
