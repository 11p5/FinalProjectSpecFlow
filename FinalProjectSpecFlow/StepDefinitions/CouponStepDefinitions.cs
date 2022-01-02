using FinalProjectSpecFlow.POMPages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FinalProjectSpecFlow.StepDefinitions
{
    [Binding]
    public class CouponStepDefinitions 
    {
        IWebDriver driver;
        public CouponStepDefinitions()
        {
             //
        }
        [Given(@"Tht we are on the the checkout page")]
        public void GivenThtWeAreOnTheTheCheckoutPage()
        {
            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.GoToShop();
            
        }

        [When(@"\[we ass the coupon code into the system")]
        public void WhenWeAssTheCouponCodeIntoTheSystem()
        {
            driver.FindElement(By.Name("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.CssSelector("button[name='apply_coupon']")).Click();
            Thread.Sleep(200);
            throw new PendingStepException();
        }

        [When(@"we click on the copon code we check that that it is (.*)%")]
        public void WhenWeClickOnTheCoponCodeWeCheckThatThatItIs(int p0)
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
            throw new PendingStepException();
        }

        [Then(@"we go to the checkout page")]
        public void ThenWeGoToTheLogoutPage()
        {
            throw new PendingStepException();
        }
    }
}
