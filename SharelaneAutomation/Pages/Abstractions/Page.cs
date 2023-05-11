using Core.Selenium;
using OpenQA.Selenium;

namespace SharelaneAutomation.Pages.Abstractions
{
    internal abstract class Page
    {
        protected const string HrefToMainPageLocatorString = "a[href='./main.py']";
        protected const string hrefLocatorStringTemplate = "a[href='{0}']";
        protected const string textInputLocatorStringTemplate = "input[name='{0}']";
        protected const string submitInputLocatorStringTemplate = "input[value='{0}']";

        public readonly By confirmationMessageLocator = By.ClassName("confirmation_message");
        public readonly By errorMessageLocator = By.ClassName("error_message");

        public bool CheckErrorMassagePresented()
        {
            return Browser.Instance.Driver.FindElement(errorMessageLocator).Displayed;
        }

        public bool CheckConfirmationMessagePresented()
        {
            return Browser.Instance.Driver.FindElement(confirmationMessageLocator).Displayed;
        }

        public bool CheckErrorMassageIsCorrect(string message)
        {
            return Browser.Instance.Driver.FindElement(errorMessageLocator).Text.Equals(message);
        }

        public bool CheckConfirmationMassageIsCorrect(string message)
        {
            return Browser.Instance.Driver.FindElement(confirmationMessageLocator).Text.Equals(message);
        }
    }
}