using OpenQA.Selenium;

namespace Core.Selenium
{
    public class Element
    {
        protected By Locator { get; }

        public Element(By locator)
        {
            Locator = locator;
        }

        public Element(string locator)
        {
            Locator = By.XPath(locator);
        }

        public void Click()
        {
            Browser.Instance.Driver.FindElement(Locator).Click();
        }

        public bool IsDisplayed()
        {
            return Browser.Instance.Driver.FindElement(Locator).Displayed;
        }

        public bool IsEnabled()
        {
            return Browser.Instance.Driver.FindElement(Locator).Enabled;
        }
    }
}