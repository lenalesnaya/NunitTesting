using Core.Selenium;
using OpenQA.Selenium;
using SharelaneAutomation.Configurations;
using SharelaneAutomation.Pages.Abstractions;

namespace SharelaneAutomation.Pages
{
    internal class ZipCodePage : Page
    {
        public static string? Url => SharelaneConfigurationManager.Urls.ZipCodePage!;

        private readonly By zipCodeInputLocator = By.CssSelector
            (string.Format(textInputLocatorStringTemplate, "zip_code"));
        private readonly By registerButtonLocator = By.CssSelector
            (string.Format(submitInputLocatorStringTemplate, "Continue"));

        public ZipCodePage() : base() { }

        public ZipCodePage TryToValidateZipCode(string zipCode)
        {
            SetZipCode(zipCode).
            ClickContinueButton();
            return this;
        }

        public RegistrationPage ValidateZipCode(string zipCode)
        {
            TryToValidateZipCode(zipCode);
            return new RegistrationPage();
        }

        public ZipCodePage SetZipCode(string zipCode)
        {
            Browser.Instance.Driver.FindElement(zipCodeInputLocator).SendKeys(zipCode);
            return this;
        }

        public void ClickContinueButton()
        {
            Browser.Instance.Driver.FindElement(registerButtonLocator).Click();
        }

        public bool CheckZipCodeInputPresented()
        {
            return Browser.Instance.Driver.FindElement(zipCodeInputLocator).Displayed;
        }

        public bool CheckErrorMassageIsCorrect()
        {
            return CheckErrorMassageIsCorrect("Oops, error on page. ZIP code should have 5 digits");
        }
    }
}