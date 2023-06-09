﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.Base;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class CheckboxesTests<DriverType> : Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        readonly string? url = TestContext.Parameters["CheckboxesUrl"];
        IList<IWebElement> checkboxes;

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
            checkboxes = driver!.FindElements(By.CssSelector("[type = checkbox]"));
        }

        [Test]
        public void CheckboxesTest()
        {
            var firstCheckbox = checkboxes[0];
            var secondCheckbox = checkboxes[1];

            Assert.Multiple(() =>
            {
                Assert.That(firstCheckbox.Selected, Is.False);
                firstCheckbox.Click();
                Assert.That(firstCheckbox.Selected);

                Assert.That(secondCheckbox.Selected);
                secondCheckbox.Click();
                Assert.That(secondCheckbox.Selected, Is.False);
            });
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}