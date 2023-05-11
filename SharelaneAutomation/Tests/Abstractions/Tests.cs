using Core.Selenium;
using OpenQA.Selenium;

namespace SharelaneAutomation.Tests.Abstractions
{
    internal abstract class Tests
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = Browser.Instance.Driver;
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}