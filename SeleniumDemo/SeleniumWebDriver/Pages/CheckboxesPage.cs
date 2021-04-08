using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class CheckboxesPage
    {
        private static By checkbox1 = By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(1)");
        private static By checkbox2 = By.CssSelector("#checkboxes > input[type=checkbox]:nth-child(3)");

        public static void CheckboxesTest(IWebDriver driver)
        {          
            // Off, On
            Thread.Sleep(500);
            Assert.IsFalse(chkbx1(driver), "On startup, checkbox 1 is selected.");
            Assert.IsTrue(chkbx2(driver), "On startup, checkbox 2 is not selected.");

            // On, On
            driver.FindElement(checkbox1).Click();
            Thread.Sleep(500);
            Assert.IsTrue(chkbx1(driver), "While off, checking checkbox 1 does not selected it.");
            Assert.IsTrue(chkbx2(driver), "While on, checking checkbox 1 deselects checkbox 2.");

            // On, Off
            driver.FindElement(checkbox2).Click();
            Thread.Sleep(500);
            Assert.IsTrue(chkbx1(driver), "While on, checking checkbox 2 deselects checkbox 1");
            Assert.IsFalse(chkbx2(driver), "While on, checking checkbox 2 does not deselect checkbox 2.");

            // Off, Off
            driver.FindElement(checkbox1).Click();
            Thread.Sleep(500);
            Assert.IsFalse(chkbx1(driver), "While on, checking checkbox 1 does not deselected it.");
            Assert.IsFalse(chkbx2(driver), "While off, checkbox 1 deselects checkbox 2.");

            // Off, On
            driver.FindElement(checkbox2).Click();
            Thread.Sleep(500);
            Assert.IsFalse(chkbx1(driver), "While off, checking checkbox 2 deselects checkbox 1");
            Assert.IsTrue(chkbx2(driver), "While off, checking checkbox 2 does not deselect checkbox 2.");

            Console.WriteLine("Checkboxes performed as required.");
        }

        private static bool chkbx1(IWebDriver driver)
        {
            return driver.FindElement(checkbox1).Selected;
        }

        private static bool chkbx2(IWebDriver driver)
        {
            return driver.FindElement(checkbox2).Selected;
        }
    }
}
