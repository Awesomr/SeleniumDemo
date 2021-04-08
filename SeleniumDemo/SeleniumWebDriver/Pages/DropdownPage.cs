using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    [TestFixture]
    class DropdownPage
    {
        
        private static By dropdownList = By.Id("dropdown");

        public static void DropdownTest(IWebDriver driver)
        {
            driver.FindElement(dropdownList).Click();

            var list = driver.FindElement(dropdownList);
            var selectElement = new SelectElement(list);
            Thread.Sleep(500);

            // Select by value:
            selectElement.SelectByValue("1");
            var text = selectElement.SelectedOption.Text;
            Assert.IsTrue(text == "Option 1", "Option 1 not selected");
            Thread.Sleep(500);

            // Select by text
            selectElement.SelectByText("Option 2");
            text = selectElement.SelectedOption.Text;
            Assert.IsTrue(text == "Option 2", "Option 2 not selected");
            Thread.Sleep(500);
        }
    }
}
