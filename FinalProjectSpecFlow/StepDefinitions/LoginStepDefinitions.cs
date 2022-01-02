using FinalProjectSpecFlow.POMPages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FinalProjectSpecFlow.StepDefinitions
{
   
    [Binding]
    public class LoginStepDefinitions 
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["driverContext"];
        }
        //public IWebDriver driver;
        [Given(@"That we are on the login page")]
        public void GivenThatWeAreOnTheLoginPage()
        {
            
            TopNavToPages TNTP = new TopNavToPages(driver);
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
           
            TNTP.GoToAccount();
            
        }

        [When(@"That the ""([^""]*)"" and ""([^""]*)""")]
        public void WhenThatTheAnd(string username, string password)
        {
            Thread.Sleep(200);
            username = "username";
            password = "password";
            driver.FindElement(By.Id(username)).SendKeys("smythpeter908@gmail.com");
            Thread.Sleep(200);
            driver.FindElement(By.Id(password)).SendKeys("TheBlankMan123");
            Thread.Sleep(200);
            driver.FindElement(By.Id("rememberme")).Click();
        }

        [When(@"The submit button is pressed")]
        public void WhenTheSubmitButtonIsPressed()
        {
            driver.FindElement(By.Name("login")).Click();
        }

        [Then(@"The page is logged in")]
        public void ThenThePageIsLoggedIn()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.GoToAccount();

            String name = "your name";
            _scenarioContext["name"] = name;
        }
    }
}
