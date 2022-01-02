using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecFlow.Utilites
{
    [Binding]
    public class TestBaseClass
    {
        private readonly ScenarioContext _scenarioContext;
        public IWebDriver driver;
        public TestBaseClass(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Before]
        public void setup()
        {
            driver = new ChromeDriver();
            _scenarioContext["driverContext"] = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [After]
        public void teardown()
        {
            driver.Quit();
        }
    }
}
