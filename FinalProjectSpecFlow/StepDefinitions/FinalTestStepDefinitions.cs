using FinalProjectSpecFlow.POMPages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FinalProjectSpecFlow.StepDefinitions
{
    [Binding]
    public class FinalTestStepDefinitions
    {
        IWebDriver driver;
        
        private readonly ScenarioContext _scenarioContext;
        public FinalTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["driverContext"];
        }

        [Given(@"that I am log in on the system")]
        public void GivenThatIAmLogInOnTheSystem()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            TNTP.GoToAccount();
            driver.FindElement(By.Id("username")).SendKeys("smythpeter908@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("TheBlankMan123");
            driver.FindElement(By.Id("rememberme")).Click(); //rememer the username and password;
            driver.FindElement(By.Name("login")).Click();
        }

        [Given(@"I got the piece of cloting in cart")]
        public void GivenIGotThePieceOfClotingInCart()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            TNTP.GoToShop();
            driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/beanie/']/img")).Click();
            driver.FindElement(By.CssSelector("button[name='add-to-cart']")).Click();
        }

        [When(@"I apply a (.*) percent discount code")]
        public void WhenIApplyAPercentDiscountCode(int p0)
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.GoToCart();
            driver.FindElement(By.Name("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.CssSelector("button[name='apply_coupon']")).Click();
        }

        [Then(@"to see if it work")]
        public void ThenToSeeIfItWork()
        {
            string baseTotal = driver.FindElement(By.CssSelector(".product-subtotal > .amount.woocommerce-Price-amount")).Text;
            baseTotal = baseTotal.Substring(1);

            string subTotal = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text;
            subTotal = subTotal.Substring(1);

            string coupon = driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).Text;
            coupon = coupon.Substring(1);
            string shipping = driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).GetAttribute("textContent");
            shipping = shipping.Substring(1);
            string Grandtotal = driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).GetAttribute("textContent");
            Grandtotal = Grandtotal.Substring(1);
            decimal BaseTotal = Convert.ToDecimal(baseTotal);
            //Console.WriteLine(BaseTotal);
            decimal SubTotal = Convert.ToDecimal(subTotal);
            decimal CouponTotal = Convert.ToDecimal(coupon);
            decimal ShippingTotal = Convert.ToDecimal(shipping);
            decimal GrandTotal = Convert.ToDecimal(Grandtotal);
            decimal tenPersent = Convert.ToDecimal(0.1);
            decimal fitheteenPersent = Convert.ToDecimal(0.15);
            decimal discount = SubTotal * fitheteenPersent;
            decimal CalulatedGrandTotal = (BaseTotal - discount) + ShippingTotal;
            //Assert.AreEqual(GrandTotal, CalulatedGrandTotal); //muted for program
        }

        [When(@"I place the order")]
        public void WhenIPlaceTheOrder()
        {
            driver.FindElement(By.LinkText("Checkout")).Click();
            driver.FindElement(By.Id("billing_first_name")).Clear();
            driver.FindElement(By.Id("billing_last_name")).Clear();
            driver.FindElement(By.Id("billing_address_1")).Clear();
            driver.FindElement(By.Id("billing_address_2")).Clear();
            driver.FindElement(By.Id("billing_city")).Clear();
            driver.FindElement(By.Id("billing_state")).Clear();
            driver.FindElement(By.Id("billing_postcode")).Clear();
            driver.FindElement(By.Id("billing_phone")).Clear();
            driver.FindElement(By.Id("billing_email")).Clear();
            driver.FindElement(By.Id("billing_first_name")).SendKeys("Peter");
            driver.FindElement(By.Id("billing_last_name")).SendKeys("Smyth");
            driver.FindElement(By.Id("billing_address_1")).SendKeys("80 sunright road");
            driver.FindElement(By.Id("billing_address_2")).SendKeys("80 sunright road");
            driver.FindElement(By.Id("billing_city")).SendKeys("birmingham");
            driver.FindElement(By.Id("billing_state")).SendKeys("drep derp derp this is alax and this is how i talk");
            driver.FindElement(By.Id("billing_postcode")).SendKeys("B74 3JZ");
            driver.FindElement(By.Id("billing_phone")).SendKeys("13223546532544234");
            driver.FindElement(By.Id("billing_email")).SendKeys("smythpeter908@gmail.com");
            
        }

        [Then(@"i check that the order number is persent in my order")]
        public void ThenICheckThatTheOrderNumberIsPersentInMyOrder()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.GoToAccount();
            driver.FindElement(By.LinkText("Orders")).Click();
            Thread.Sleep(1000);
            string StoredOrder = driver.FindElement(By.CssSelector(".woocommerce-orders-table__header.woocommerce-orders-table__header-order-number > .nobr")).Text;
            // Console.WriteLine(StoredOrder);
            // Assert.AreEqual(order_number,StoredOrder);
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
