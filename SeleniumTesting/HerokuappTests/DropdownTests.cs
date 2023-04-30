using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.Base;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class DropdownTests<DriverType> : Tests
        where DriverType : IWebDriver, new()
    {
        IWebDriver driver;
        readonly string? url = TestContext.Parameters["DropdownUrl"];
        SelectElement dropdown;

        [SetUp]
        public void Setup()
        {
            driver = ConfigureDriver(new DriverType(), url);
            dropdown = new SelectElement(driver!.FindElement(By.Id("dropdown")));
        }

        [Test]
        public void DropdownTest()
        {
            var option1 = dropdown.Options.FirstOrDefault(o => o.Text == "Option 1");
            var option2 = dropdown.Options.FirstOrDefault(o => o.Text == "Option 2");

            Assert.Multiple(() =>
            {
                Assert.That(option1?.Displayed, Is.True);
                Assert.That(option2?.Displayed, Is.True);

                option1?.Click();
                Assert.That(option1!.Selected);
                option2?.Click();
                Assert.That(option2!.Selected);
            });
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}