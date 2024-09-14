using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Bogus;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoFramework.Utils
{
    internal class Common
    {
        private static IWebDriver? _driver;
        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return _driver;
        }
        public static void GoToHomePage()
        {
            string baseUrl = GetBaseUrl();
            GetDriver().Navigate().GoToUrl(baseUrl);
        }
        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
        private static string GetBaseUrl()
        {
            return "https://www.saucedemo.com/";
        }
        public static void EnterCredentials(IWebDriver driver)
        {
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        }

        public static void ClickLoginButton(IWebDriver driver)
        {
            driver.FindElement(By.Id("login-button")).Click();
        }

        public static void AddProductToCart(IWebDriver driver)
        {
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
        }

        public static void AddMoreThanOneProductToCart(IWebDriver driver)
        {
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();
        }

        public static void RemoveProductFromCart(IWebDriver driver)
        {
            driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();
        }

        public static void VerifyCartIconDisplayOneItem(IWebDriver driver)
        {
            IWebElement cartBadge = driver.FindElement(By.CssSelector("[data-test='shopping-cart-badge']"));
            string cartItemCount = cartBadge.Text;

            Assert.That(cartItemCount, Is.EqualTo("1"));
        }

        public static void VerifyCartIconDisplayMoreThanOneItem(IWebDriver driver)
        {
            IWebElement cartBadge = driver.FindElement(By.CssSelector("[data-test='shopping-cart-badge']"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", cartBadge);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => cartBadge.Displayed);

            string cartItemCount = cartBadge.Text;
            Assert.That(cartItemCount, Is.EqualTo("3"));
        }

        public static void GoToCart(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("[data-test='shopping-cart-link'")).Click();
        }

        public static void GoToCheckoutPage(IWebDriver driver)
        {
            driver.FindElement(By.Id("checkout")).Click();
        }

        public static void EnterDataToPurchase(IWebDriver driver)
        {
            var faker = new Faker();
            string firstName = faker.Name.FirstName();
            string lastName = faker.Name.LastName();
            string zipCode = faker.Address.ZipCode();

           
            var firstNameField = driver.FindElement(By.Id("first-name")); 
            firstNameField.SendKeys(firstName);

            var lastNameField = driver.FindElement(By.Id("last-name")); 
            lastNameField.SendKeys(lastName);

            var zipCodeField = driver.FindElement(By.Id("postal-code")); 
            zipCodeField.SendKeys(zipCode);
        }

        public static void ContinuePurchase(IWebDriver driver)
        {
            driver.FindElement(By.Id("continue")).Click();
        }

        public static void ContinueShopping(IWebDriver driver)
        {
            driver.FindElement(By.Id("continue-shopping")).Click();
        }

        public static void ProceedPurchase(IWebDriver driver)
        {   
            // Assert Info Titles
            var paymentInfoLabel = driver.FindElement(By.CssSelector("[data-test='payment-info-label']"));
            string paymentTitle = paymentInfoLabel.Text;
            Assert.That(paymentTitle, Is.EqualTo("Payment Information:"));

            var shipInfoLabel = driver.FindElement(By.CssSelector("[data-test='shipping-info-label']"));
            string shipTitle = shipInfoLabel.Text;
            Assert.That(shipTitle, Is.EqualTo("Shipping Information:"));

            var priceLabel = driver.FindElement(By.CssSelector("[data-test='total-info-label']"));
            string priceTitle = priceLabel.Text;
            Assert.That(priceTitle, Is.EqualTo("Price Total"));
        }

        public static void VerifyTotalPrice(IWebDriver driver)
        {
            
            var productPriceElement = driver.FindElement(By.CssSelector("[data-test='subtotal-label']"));
            double productPrice = ExtractNumberFromText(productPriceElement.Text);

            var shippingCostElement = driver.FindElement(By.CssSelector("[data-test='tax-label']"));
            double shippingCost = ExtractNumberFromText(shippingCostElement.Text);

            double expectedTotalPrice = productPrice + shippingCost;

            var totalPriceElement = driver.FindElement(By.CssSelector("[data-test='total-label']"));
            double displayedTotalPrice = ExtractNumberFromText(totalPriceElement.Text);

            Assert.AreEqual(expectedTotalPrice, displayedTotalPrice, 0.01, "O preço total exibido não corresponde ao esperado.");
        }
        private static double ExtractNumberFromText(string text)
        {
            string cleanedText = new string(text.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());

            cleanedText = cleanedText.Replace(",", ".");
                       
            return double.Parse(cleanedText, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static void FinishPurchase(IWebDriver driver)
        {
            driver.FindElement(By.Id("finish")).Click();
        }

        public static void PurchaseConfirmationPage(IWebDriver driver)
        {
           var purchaseConfirmation = driver.FindElement(By.CssSelector("[data-test='complete-header']"));
            Assert.That(purchaseConfirmation.Text, Is.EqualTo("Thank you for your order!"));
        }

        public static void ClickOnAProductFromList(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("[data-test='inventory-item-name']")).Click();
        }

        public static void AddProducToCartFromSpecificProductPage(IWebDriver driver)
        {
            driver.FindElement(By.Id("add-to-cart")).Click();
        }

        public static void VerifyItemIsRemovedFromCart(IWebDriver driver)
        {
            var cartBadge = driver.FindElements(By.CssSelector("[data-test='shopping-cart-badge']"));

            if (cartBadge.Count == 0)
            {     
                return;
            }
        }
        public static void ClickOnLeftMenu(IWebDriver driver)
        {
            IWebElement leftMenu = driver.FindElement(By.CssSelector(".bm-burger-button > button#react-burger-menu-btn"));
            leftMenu.Click();

        }

        public static void ClickLogOutOption(IWebDriver driver)
        {
            driver.FindElement(By.Id("logout_sidebar_link")).Click();
        }


    }
}


