using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSpecFlow.POMPages
{
   
        public class TopNavToPages
    {
        private IWebDriver _driver;

        public TopNavToPages(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement account_page => _driver.FindElement(By.LinkText("My account"));
        private IWebElement Shop => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement cart => _driver.FindElement(By.LinkText("Cart"));

        public void GoToAccount()
        {
            account_page.Click();

        }
        public void GoToShop()
        {
            Shop.Click();
        }
        public void GoToCart()
        {
            cart.Click();
        }
    }
}
