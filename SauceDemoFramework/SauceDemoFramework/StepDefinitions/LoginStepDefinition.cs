using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SauceDemoFramework.Utils;
using NUnit.Framework; 

namespace SauceDemoFramework.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinition
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

        [Test]
        
        [Given(@"I enter valid credentials on home page")]
        public void WhenEnterValidCredentials()
        {
            Common.EnterCredentials(driver);
        }

        [Then(@"I can login successfully and proceed to products page")]
        public void ThenLoginSuccessfully()
        {
            Common.ClickLoginButton(driver);

            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
           
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
