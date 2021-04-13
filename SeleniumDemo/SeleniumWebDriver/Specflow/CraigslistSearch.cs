using OpenQA.Selenium;

namespace SeleniumWebDriver.Specflow
{
    public class CraigslistSearch 
    {
        public IWebDriver WebDriver { get; private set; }

        public CraigslistSearch(IWebDriver driver)
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

        public void EnterSearchTerm(string searchTerm)
        {
            searchBox.SendKeys(searchTerm + Keys.Enter);
        }

        public void ClickHasImage() => hasPic.Click();

        public void EnterPriceRange(decimal minSearchPrice, decimal maxSearchPrice)
        {
            minPrice.SendKeys(minSearchPrice.ToString());
            maxPrice.SendKeys(maxSearchPrice.ToString());
        }

        public void SearchFormPageDown() => allPageDown.SendKeys(Keys.PageDown + Keys.PageDown);

        public void ClickUpdateSearch() => updateSearch.Click();

        public void ClickTopPostOfUpdatedSearch() => topSearchResult.Click();

        public string GetListingPrice() => listingPrice.Text;

        public string GetAdContent() => listingAdContent.Text;
    }
}
