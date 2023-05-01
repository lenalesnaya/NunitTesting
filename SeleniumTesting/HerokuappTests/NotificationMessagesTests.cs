using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumTesting.Base;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class NotificationMessagesTests<DriverType> : Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        WebDriverWait wait;

        readonly string? url = TestContext.Parameters["NotificationMessagesUrl"];
        readonly By hrefLocator = By.CssSelector("[href='/notification_message']");
        readonly By flashLocator = By.Id("flash");

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void NotificationMessagesTest()
        {
            driver!.FindElement(hrefLocator).Click();

            var flash = wait.Until(ExpectedConditions.ElementExists(flashLocator));
            Assert.That(flash.Text, Does.StartWith("Action successful"));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}