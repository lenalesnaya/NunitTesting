using OpenQA.Selenium;

namespace Core.Selenium
{
    public class Element
    {
        protected static Browser Browser => Browser.Instance;
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
            Browser.Driver.FindElement(Locator).Click();
        }
    }
}