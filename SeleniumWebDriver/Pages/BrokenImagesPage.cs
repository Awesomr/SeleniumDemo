using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    class BrokenImagesPage
    {
        public static void BrokenImagesTest(IWebDriver driver)
        {           
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
    }
}
