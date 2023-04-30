using OpenQA.Selenium;

namespace SeleniumTesting.Base
{
    public abstract class Tests
    {
        protected static IWebDriver ConfigureDriver(IWebDriver driver, string? url)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(url);

            return driver;
        }
    }
}