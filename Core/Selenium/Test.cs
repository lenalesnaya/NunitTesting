using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.Selenium
{
    public abstract class Test
    {
        protected IWebDriver? Driver { get; set; }

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