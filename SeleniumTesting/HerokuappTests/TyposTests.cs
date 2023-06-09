﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.Base;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class TyposTests<DriverType> : Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        readonly string? url = TestContext.Parameters["TyposUrl"];
        IList<IWebElement> paragraphs;

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
            paragraphs = driver!.FindElements(By.TagName("p"));
        }

        [Test]
        public void TyposTest()
        {
            var typosParagraph = paragraphs[1];
            Assert.That(
                typosParagraph.Text, Is.EqualTo(
                    "Sometimes you'll see a typo, other times you won't."));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}