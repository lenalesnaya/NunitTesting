using Core.Selenium;
using OpenQA.Selenium;
using SharelaneAutomation.Configurations;
using SharelaneAutomation.Pages.Abstractions;

namespace SharelaneAutomation.Pages
{
    internal class MainPage : Page
    {
        public static string Url => SharelaneConfigurationManager.Urls.MainPage!;

        private readonly By hrefLogoLocator = By.CssSelector(HrefToMainPageLocatorString);
        private readonly By hrefBookLocator = By.XPath("//a[contains(@href,'book')]");
        private readonly By helloUserLocator = By.CssSelector("span.user");
        protected readonly By emailInputLocator =
            By.CssSelector(string.Format(textInputLocatorStringTemplate, "email"));
        protected readonly By passwordInputLocator =
            By.CssSelector(string.Format(textInputLocatorStringTemplate, "password"));
        private readonly By loginButtonLocator =
            By.CssSelector(string.Format(submitInputLocatorStringTemplate, "Login"));
        private readonly By hrefSignUpLocator = By.CssSelector
           (string.Format(hrefLocatorStringTemplate, "./register.py"));
        private readonly By hrefLogoutLocator = By.CssSelector
           (string.Format(hrefLocatorStringTemplate, "./log_out.py"));

        public MainPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(Url);
            Assert.That(CheckBookHrefPresented(), Is.True);

            return this;
        }

        public bool CheckBookHrefPresented()
        {
            return Browser.Instance.Driver.FindElement(hrefBookLocator).Displayed;
        }

        public bool CheckLogoutHrefPresented()
        {
            return Browser.Instance.Driver.FindElement(hrefLogoutLocator).Displayed;
        }

        public bool CheckHelloUserPresented()
        {
            return Browser.Instance.Driver.FindElement(helloUserLocator).Displayed;
        }

        public bool CheckErrorMassageIsCorrect()
        {
            return CheckErrorMassageIsCorrect(
                "Oops, error. Email and/or password don't match our records");
        }

        public MainPage TryToLogin(string email, string password)
        {
            SetEmail(email).
            SetPassword(password).
            ClickLoginButton();

            return this;
        }

        public MainPage Login(string email, string password)
        {
            TryToLogin(email, password);
            return new MainPage();
        }

        public MainPage SetEmail(string email)
        {
            Browser.Instance.Driver.FindElement(emailInputLocator).SendKeys(email);
            return this;
        }

        public MainPage SetPassword(string password)
        {
            Browser.Instance.Driver.FindElement(passwordInputLocator).SendKeys(password);
            return this;
        }

        public void ClickLoginButton()
        {
            Browser.Instance.Driver.FindElement(loginButtonLocator).Click();
        }

        public MainPage ClickLogo()
        {
            Browser.Instance.Driver.FindElement(hrefLogoLocator).Click();
            return new MainPage();
        }

        public ZipCodePage ClickSignUpLink()
        {
            Browser.Instance.Driver.FindElement(hrefSignUpLocator).Click();
            return new ZipCodePage();
        }

        public LogoutPage ClickLogoutLink()
        {
            Browser.Instance.Driver.FindElement(hrefLogoutLocator).Click();
            return new LogoutPage();
        }
    }
}