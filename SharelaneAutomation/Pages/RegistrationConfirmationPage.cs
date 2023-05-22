using Core.Selenium;
using OpenQA.Selenium;
using SharelaneAutomation.Pages.Abstractions;

namespace SharelaneAutomation.Pages
{
    internal class RegistrationConfirmationPage : Page
    {
        readonly By hrefToMainPageLocator = By.CssSelector(HrefToMainPageLocatorString);
        readonly By emailStringLocator = By.XPath("//td[text()='Email']/following::td/b");
        readonly By passwordStringLocator = By.XPath("//td[text()='Password']/following::td");

        public RegistrationConfirmationPage() : base() { }

        public MainPage ClickMainPageLink()
        {
            Browser.Instance.Driver.FindElement(hrefToMainPageLocator).Click();
            return new MainPage();
        }

        public string GetEmailString() =>
            Browser.Instance.Driver.FindElement(emailStringLocator).Text;

        public string GetPasswordString() =>
            Browser.Instance.Driver.FindElement(passwordStringLocator).Text;

        public bool CheckConfirmationMassageIsCorrect() =>
            CheckConfirmationMassageIsCorrect("Account is created!");
    }
}