using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.Base;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class InputsTests<DriverType> : Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        readonly string? url = TestContext.Parameters["InputsUrl"];
        IWebElement input;

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
            input = driver!.FindElement(By.TagName("input"));
        }

        [Test]
        public void ArrowUpDownTest()
        {
            input.Click();
            input.SendKeys(Keys.ArrowUp);

            Assert.Multiple(() =>
            {
                Assert.That(input.GetAttribute("value"), Is.EqualTo("1"));
                input.SendKeys(Keys.ArrowDown + Keys.ArrowDown);
                Assert.That(input.GetAttribute("value"), Is.EqualTo("-1"));

                input.Clear();
                input.SendKeys("bbvvb");
                Assert.That(input.GetAttribute("value"), Is.EqualTo(""));
            });
        }

        [Test]
        public void InsertDigitsTest()
        {
            input.Click();
            input.SendKeys("123456");

            Assert.Multiple(() =>
            {
                Assert.That(input.GetAttribute("value"), Is.EqualTo("123456"));
                input.SendKeys(Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowDown);
                Assert.That(input.GetAttribute("value"), Is.EqualTo("123458"));
            });
        }

        [Test]
        public void InsertLettersTest()
        {
            input.Click();
            input.SendKeys("bbvvb");
            Assert.That(input.GetAttribute("value"), Is.EqualTo(""));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}