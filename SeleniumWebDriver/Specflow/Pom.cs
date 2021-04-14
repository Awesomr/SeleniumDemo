using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Specflow
{
    public class Pom // Page Object Model (Demo. I know there is more than one page in here.)
    {
        public IWebDriver WebDriver { get; private set; }

        public Pom(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public IWebElement searchBox => WebDriver.FindElement(By.Id("query"));
        public IWebElement hasPic => WebDriver.FindElement(By.Name("hasPic"));
        public IWebElement minPrice => WebDriver.FindElement(By.Name("min_price"));
        public IWebElement maxPrice => WebDriver.FindElement(By.Name("max_price"));
        public IWebElement allPageDown => WebDriver.FindElement(By.Id("all-purveyor"));
        public IWebElement updateSearch => WebDriver.FindElement(By.CssSelector(
                "#searchform > div.search-options-container > div.search-options > div.searchgroup.resetsearch > button"));
        public IWebElement topSearchResult => WebDriver.FindElement(By.ClassName("result-title"));
        public IWebElement listingPrice => WebDriver.FindElement(By.ClassName("price"));
        public IWebElement listingAdContent => WebDriver.FindElement(By.Id("postingbody"));


    }
}
