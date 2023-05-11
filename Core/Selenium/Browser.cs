using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using Core.Configurations;

namespace Core.Selenium
{
    public class Browser
    {
        private static Browser? instance = null;

        public static Browser Instance
        {
            get
            {
                instance ??= new Browser();
                return instance;
            }
        }

        public IWebDriver Driver { get; }

        private Browser()
        {
            switch (ConfigurationManager.Browser.Type!.ToLower())
            {
                case "chrome":
                    if (ConfigurationManager.Browser.Headless)
                    {
                        ChromeOptions options = new();
                        options.AddArgument("--headless");
                        Driver = new ChromeDriver(options);
                    }
                    else
                    {
                        Driver = new ChromeDriver();
                    }
                    break;
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }

            Driver!.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ContextClickToElement(IWebElement element)
        {
            new Actions(Driver)
              .MoveToElement(element)
              .ContextClick()
              .Build()
              .Perform();
        }

        public void ContextClickToElement(By by)
        {
            var element = Driver.FindElement(by);
            ContextClickToElement(element);
        }

        public void AcceptAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        public object? ExecuteScript(string script)
        {
            try
            {
                return ((IJavaScriptExecutor)Driver).ExecuteScript(script);
            }
            catch
            {
                return null;
            }
        }

        public void SwitchToFirstWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        public void SwitchToLastWindow()
        {
            var windows = Driver.WindowHandles;
            if (windows.Count > 1)
            {
                Driver.SwitchTo().Window(windows[^1]);
            }
        }

        public void CloseTab()
        {
            Driver.Close();
        }

        public void CloseBrowser()
        {
            Driver?.Dispose();
            instance = null;
        }
    }
}