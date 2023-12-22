using NUnit.Framework;
using OpenQA.Selenium;
using PetStoreBDD.Hooks;
using PetStoreBDD.Utilities;
using System;
using TechTalk.SpecFlow;

namespace PetStoreBDD.StepDefinitions
{
    [Binding]
    public class PetStoreSteps :CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;
        [When(@"User click on the Petname Dogs")]
        public void WhenUserClickOnThePetnameDogs()
        {
            AllHooks.test = AllHooks.extent.CreateTest("Pet details test");
            IWebElement petName = driver.FindElement(By.XPath("//img[@src='../images/dogs_icon.gif']"));
            petName.Click();
        }

        [Then(@"The page will be loaded")]
        public void ThenThePageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("actions"));
                LogTestResult("Pet Details Page Test ", "Pet Details Page success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Pet Details Page Test",
                  "Pet Details Page  failed", ex.Message);
            }
        }

        [When(@"User click on the ProductIds")]
        public void WhenUserClickOnTheProductIds()
        {
            AllHooks.test = AllHooks.extent.CreateTest("ProductId details test");
            IWebElement pId = driver.FindElement(By.XPath("//a[normalize-space()='K9-DL-01']"));
            pId.Click();
        }

        [Then(@"The pet details will be loaded")]
        public void ThenThePetDetailsWillBeLoaded()
        {

            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("actions"));
                LogTestResult("ProductId Details Page Test ", "ProductId Details Page success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("ProductId Details Page Test",
                  "ProductId Details Page  failed", ex.Message);
            }
        }

        [When(@"User click on the ItemIds")]
        public void WhenUserClickOnTheItemIds()
        {
            AllHooks.test = AllHooks.extent.CreateTest("ItemId details test");
            IWebElement itemId = driver.FindElement(By.XPath("//a[text()='EST-9']"));
            itemId.Click();
        }

        [Then(@"The item page will be loaded")]
        public void ThenTheItemPageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("actions"));
                LogTestResult("ItemId Details Page Test ", "ItemId Details Page success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("ItemId Details Page Test",
                  "ItemId Details Page  failed", ex.Message);
            }
        }

        [When(@"The user click on the AddToCart")]
        public void WhenTheUserClickOnTheAddToCart()
        {
            AllHooks.test = AllHooks.extent.CreateTest("AddToCart details test");
            IWebElement addToCart = driver.FindElement(By.XPath("//a[@class='Button']"));
            addToCart.Click();
        }

        [Then(@"The carted page is loaded")]
        public void ThenTheCartedPageIsLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("actions"));
                LogTestResult("AddToCart Details Page Test ", "AddToCart Details Page success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("AddToCart Details Page Test",
                  "AddToCart Details Page  failed", ex.Message);
            }
        }

        [When(@"user click on the ProceedToCheckout")]
        public void WhenUserClickOnTheProceedToCheckout()
        {
            AllHooks.test = AllHooks.extent.CreateTest("CheckOut details test");
            IWebElement checkout = driver.FindElement(By.XPath("//a[normalize-space()='Proceed to Checkout']"));
            checkout.Click();
        }

        [When(@"Page will be loaded")]
        public void WhenPageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("actions"));
                LogTestResult("Checkout Details Page Test ", "Checkout Details Page success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Checkout Details Page Test",
                  "Checkout Details Page  failed", ex.Message);
            }
        }

        [When(@"user will enter the '([^']*)', '([^']*)'")]
        public void WhenUserWillEnterThe(string kavi, string p1)
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/form[1]/p[2]/input[1]")).SendKeys(kavi);
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(p1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        [When(@"User will click on the login button")]
        public void WhenUserWillClickOnTheLoginButton()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("actions"));
                LogTestResult("Login Page Test ", "Login Page success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Login Page Test",
                  "Login Page  failed", ex.Message);
            }
        }
    }
}
