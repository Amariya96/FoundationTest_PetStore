using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.PageObjects
{
    internal class ProductSelectAndAddToCart
    {
        IWebDriver driver;
        public ProductSelectAndAddToCart(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//img[@src='../images/dogs_icon.gif']")]
        private IWebElement? DogsBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='K9-DL-01']")] 
        private IWebElement? ProductIds { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='EST-9']")]
        private IWebElement? ItemId { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='Button']")]
        private IWebElement? AddToCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Proceed to Checkout']")]
        private IWebElement? CheckOut { get; set; }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/form[1]/p[2]/input[1]")]
        private IWebElement? UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement? Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='signon']")]
        private IWebElement? SignIn { get; set; }
       
        public void ProductSelect(string un, string pd)
        {
            DogsBtn?.Click();
            ProductIds?.Click();
            ItemId?.Click();
            AddToCart?.Click();
            CheckOut?.Click();
            UserName?.SendKeys(un);
            Password?.SendKeys(pd);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SignIn?.Click();         
        }
    }
}
