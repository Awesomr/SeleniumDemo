using System;
using TechTalk.SpecFlow;

namespace SeleniumWebDriver.Specflow.Features
{
    [Binding]
    public class CraigslistDemoSteps
    {
        [Given(@"I launch the appliction")]
        public void GivenILaunchTheAppliction()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter '(.*)' into the searchbox")]
        public void GivenIEnterIntoTheSearchbox(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I hit '(.*)'")]
        public void GivenIHit(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I click '(.*)'")]
        public void GivenIClick(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter the price")]
        public void GivenIEnterThePrice(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I scroll down")]
        public void GivenIScrollDown()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I click the '(.*)' button")]
        public void GivenIClickTheButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click the top post")]
        public void GivenIClickTheTopPost()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should get the top price and ad information")]
        public void ThenIShouldGetTheTopPriceAndAdInformation()
        {
            ScenarioContext.Current.Pending();
        }
       

        

    }
}
