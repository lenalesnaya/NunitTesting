using OpenQA.Selenium;

namespace SeleniumTesting.Base
{
    public abstract class Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = ConfigureDriver(new DriverType());
        }

        protected static IWebDriver ConfigureDriver(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            return driver;
        }
    }
}