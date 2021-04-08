using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    class AddRemoveElementsPage
    {
        public static void AddRemoveElementsTest(IWebDriver driver)
        {
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
