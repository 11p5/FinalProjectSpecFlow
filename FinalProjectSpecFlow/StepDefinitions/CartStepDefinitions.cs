using FinalProjectSpecFlow.POMPages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FinalProjectSpecFlow.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions 

    {
        IWebDriver driver;
        public CartStepDefinitions()
        {

        }

       

        [Given(@"That we are going to the product page")]
        public void GivenThatWeAreGoingToTheProductPage()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.GoToShop();
            
        }

        [When(@"we click on the beniee to goes to beenie page")]
        public void WhenWeClickOnTheBenieeToGoesToBeeniePage()
        {
            driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/beanie/']/img")).Click();
            Thread.Sleep(1000);
            
        }

        [Then(@"we go to the cart page")]
        public void ThenWeGoToTheCartPage()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.GoToShop();
           
        }
    }
}
