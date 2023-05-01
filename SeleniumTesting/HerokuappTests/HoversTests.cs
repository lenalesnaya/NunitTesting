using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTesting.Base;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class HoversTests<DriverType> : Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        WebDriverWait wait;
        Actions action;

        readonly string? url = TestContext.Parameters["HoversUrl"];
        readonly By notFoundLocator = By.TagName("h1");
        readonly By imageLocator = By.ClassName("figure");
        readonly string nameLocatorStringTemplate = "//h5[text()='name: {0}']";
        readonly string hrefLocatorStringTemplate = "a[href='{0}']";

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
            action = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [Test]
        public void HoversTest()
        {
            var images = driver!.FindElements(imageLocator);

            Assert.Multiple(() =>
            {
                CheckHover(images[0], "user1", "/users/1");
                Assert.That(!Check404Appear(), "Not Found");

                driver!.Navigate().Back();
                CheckHover(images[1], "user2", "/users/2");
                Assert.That(!Check404Appear(), "Not Found");

                driver!.Navigate().Back();
                CheckHover(images[2], "user3", "/users/3");
                Assert.That(!Check404Appear(), "Not Found");
            });
        }

        private void CheckHover(IWebElement hover, string userName, string href)
        {
            By nameLocator = By.XPath(string.Format(nameLocatorStringTemplate, userName));
            By hrefLocator = By.CssSelector(string.Format(hrefLocatorStringTemplate, href));

            action.MoveToElement(hover).
                MoveToElement(wait.Until(ExpectedConditions.ElementExists(nameLocator))).
                MoveToElement(wait.Until(ExpectedConditions.ElementExists(hrefLocator))).
                Click().Build().Perform();
        }

        private bool Check404Appear()
        {
            var header = wait.Until(ExpectedConditions.ElementExists(notFoundLocator));
            return header.Text.Equals("Not Found");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}