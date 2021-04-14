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

        public IWebElement SearchBox => WebDriver.FindElement(By.Id("query"));
        public IWebElement HasPic => WebDriver.FindElement(By.Name("hasPic"));
        public IWebElement MinPrice => WebDriver.FindElement(By.Name("min_price"));
        public IWebElement MaxPrice => WebDriver.FindElement(By.Name("max_price"));
        public IWebElement AllPageDown => WebDriver.FindElement(By.Id("all-purveyor"));
        public IWebElement UpdateSearch => WebDriver.FindElement(By.CssSelector(
                "#searchform > div.search-options-container > div.search-options > div.searchgroup.resetsearch > button"));
        public IWebElement TopSearchResult => WebDriver.FindElement(By.ClassName("result-title"));
        public IWebElement ListingPrice => WebDriver.FindElement(By.ClassName("price"));
        public IWebElement ListingAdContent => WebDriver.FindElement(By.Id("postingbody"));
        

        public void EnterSearchTerm(string searchTerm)
        {
            SearchBox.SendKeys(searchTerm + Keys.Enter);
        }

        public void ClickHasImage() => HasPic.Click();

        public void EnterPriceRange(decimal minSearchPrice, decimal maxSearchPrice)
        {
            MinPrice.SendKeys(minSearchPrice.ToString());
            MaxPrice.SendKeys(maxSearchPrice.ToString());
        }

        public void SearchFormPageDown() => AllPageDown.SendKeys(Keys.PageDown + Keys.PageDown);

        public void ClickUpdateSearch() => UpdateSearch.Click();

        public void ClickTopPostOfUpdatedSearch() => TopSearchResult.Click();

        public string GetListingPrice() => ListingPrice.Text;

        public string GetAdContent() => ListingAdContent.Text;
    }
}
