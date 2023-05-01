using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.Base;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class AddRemoveTests<DriverType>: Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        readonly string? url = TestContext.Parameters["AddRemoveUrl"];

        const string buttonLocatorStringTemplate = "//button[text()='{0}']";
        readonly By addButtonLocator = By.XPath(
                string.Format(buttonLocatorStringTemplate, "Add Element"));
        readonly By deleteButtonLocator = By.XPath(
                string.Format(buttonLocatorStringTemplate, "Delete"));

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void AddRemoveTest()
        {
            var addButton = driver!.FindElement(addButtonLocator);
            addButton.Click();
            addButton.Click();

            var deleteButton = driver.FindElement(deleteButtonLocator);
            deleteButton.Click();
            var deleteButtons = driver.FindElement(By.Id("elements")).FindElements(By.TagName("button"));

            Assert.That(deleteButtons, Has.Count.EqualTo(1));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}