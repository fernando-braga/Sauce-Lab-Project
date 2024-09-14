using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoFramework.Utils;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoFramework.StepDefinitions
{
    [Binding]
    public class ProductPageStepDefinitions
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

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            Common.EnterCredentials(driver);
            Common.ClickLoginButton(driver);
        }

        [When(@"I click on Add To Cart for a product")]
        public void WhenIClickOnAddForAProduct()
        {
            Common.AddProductToCart(driver);
        }

        [Then(@"the product should be added to my cart and the cart icon must display a number in red")]
        public void ThenTheCartMustDisplayProductAndNumber()
        {
            Common.VerifyCartIconDisplayOneItem(driver);
            driver.Quit();
        }

        [Given(@"I have a product added in my cart")]
        public void AndIHaveAProducAdded()
        {
            Common.AddProductToCart(driver);
        }

        [When(@"I click on Remove button")]
        public void WhenClickRemoveButton()
        {
            Common.RemoveProductFromCart(driver);
        }

        [Then(@"the red number displayed on the cart icon must be subtracted")]
        public void ThenNumberIsSubtracted()
        {
            Common.VerifyItemIsRemovedFromCart(driver);
        }

        [When(@"I add more than one product product to cart")]
        public void WhenMoreThanOneProductIsAdded()
        {
            Common.AddMoreThanOneProductToCart(driver);
        }

        [Then(@"the red number displayed is equal to the number of products I added")]
        public void ThenCartDisplaysItensAmount()
        {
            Common.VerifyCartIconDisplayMoreThanOneItem(driver);
        }

        [When(@"I click on the cart icon")]
        public void WhenClickOnCart()
        {
           Common.GoToCart(driver);
        }

        [Then(@"I must be able to proceed to Checkout page, Continue Shopping and Remove product")]
        public void ThenCheckProductOptions()
        {
            Common.GoToCart(driver);
            Common.GoToCheckoutPage(driver);
            Common.GoToCart(driver);
            Common.ContinueShopping(driver);
            Common.GoToCart(driver);
            Common.RemoveProductFromCart(driver);
        }

        [When(@"I click on the checkout button")]
        public void WhenClickOnCheckout()
        {
            Common.GoToCheckoutPage(driver);
        }
        
        [When(@"I enter valid checkout information")]
        public void WhenEnterValidCheckoutInfo()
        {          
            Common.EnterDataToPurchase(driver);
            Common.ContinuePurchase(driver);
        }

        [Then(@"I should be able to complete the purchase")]
        public void ThenCompletePurchase()
        {
            Common.ProceedPurchase(driver);
            Common.VerifyTotalPrice(driver);

            Common.FinishPurchase(driver);
            Common.PurchaseConfirmationPage(driver);
        }
        
        [Given(@"I click on a product from the list")]
        public void GivenIClickOnAProductFromTheList()
        {
            Common.ClickOnAProductFromList(driver);
        }

        [Given(@"I add the product to cart")]
        public void GivenIAddTheProductToCart()
        {
            Common.AddProducToCartFromSpecificProductPage(driver);

        }





        
    }
}
