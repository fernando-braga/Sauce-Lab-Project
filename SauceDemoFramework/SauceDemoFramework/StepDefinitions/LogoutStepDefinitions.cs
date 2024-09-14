using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoFramework.Utils;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoFramework.StepDefinitions
{

    [Binding]
    public class LogoutStepDefinitions
    {
        public IWebDriver driver = null!;

        [BeforeScenario]
        public void Setup()
        {
            
            driver = Common.GetDriver();
            Common.GoToHomePage();
        }

        [AfterScenario]
        public void TearDown()
        {
            Common.QuitDriver();
        }

        [Given(@"I am logged on the products page")]
        public void GivenIAmLoggedOnTheProductsPage()
        {           
            Common.EnterCredentials(driver);
            Common.ClickLoginButton(driver);
        }


        [Given(@"I click on the left hamburger menu")]
        public void GivenIClickOnTheLeftHamburgerMenu()
        {
            Common.ClickOnLeftMenu(driver);
        }

        [When(@"I click on Logout option")]
        public void WhenIClickOnLogoutOption()
        {
            Common.ClickLogOutOption(driver);
        }

        [Then(@"I am logget out")]
        public void ThenIAmLoggetOut()
        {
            Common.GoToHomePage();
        }

        [Given(@"I click on Add To Cart for a product")]
        public void GivenIClickOnAddToCartForAProduct()
        {
            Common.AddProductToCart(driver);
        }

        [Given(@"I click on Logout option")]
        public void GivenIClickOnLogoutOption()
        {
            Common.ClickLogOutOption(driver);
        }

        [When(@"I log on application again")]
        public void WhenILogOnApplicationAgain()
        {
            Common.GoToHomePage();
            Common.EnterCredentials(driver);
            Common.ClickLoginButton(driver);
        }

        [Then(@"the product is still on the cart")]
        public void ThenTheProductIsStillOnTheCart()
        {
            Common.VerifyCartIconDisplayOneItem(driver);
        }
    }
}
