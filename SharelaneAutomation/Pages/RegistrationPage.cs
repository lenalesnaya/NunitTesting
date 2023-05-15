using Core.Selenium;
using OpenQA.Selenium;
using SharelaneAutomation.Models;
using SharelaneAutomation.Pages.Abstractions;

namespace SharelaneAutomation.Pages
{
    internal class RegistrationPage : Page
    {
        private readonly By firstNameInputLocator = By.CssSelector
            (string.Format(textInputLocatorStringTemplate, "first_name"));
        private readonly By lastNameInputLocator = By.CssSelector
            (string.Format(textInputLocatorStringTemplate, "last_name"));
        protected readonly By emailInputLocator =
            By.CssSelector(string.Format(textInputLocatorStringTemplate, "email"));
        protected readonly By passwordInputLocator =
            By.CssSelector(string.Format(textInputLocatorStringTemplate, "password1"));
        private readonly By confirmPasswordInputLocator = By.CssSelector
            (string.Format(textInputLocatorStringTemplate, "password2"));
        private readonly By registerButtonLocator = By.CssSelector
            (string.Format(submitInputLocatorStringTemplate, "Register"));

        public RegistrationPage() : base() { }

        public RegistrationPage TryToRegister(User user, string? confirmPassword = null)
        {
            SetFirstName(user.FirstName!).
            SetLastName(user.LastName!).
            SetEmail(user.Email!).
            SetPassword(user.Password!).
            SetConfirmPassword(confirmPassword ?? user.Password!).
            ClickRegisterButton();

            return this;
        }

        public RegistrationConfirmationPage Register(User user)
        {
            TryToRegister(user);
            return new RegistrationConfirmationPage();
        }

        public RegistrationPage SetFirstName(string firstName)
        {
            Browser.Instance.Driver.FindElement(firstNameInputLocator).SendKeys(firstName);
            return this;
        }

        public RegistrationPage SetLastName(string lastName)
        {
            Browser.Instance.Driver.FindElement(lastNameInputLocator).SendKeys(lastName);
            return this;
        }

        public RegistrationPage SetEmail(string email)
        {
            Browser.Instance.Driver.FindElement(emailInputLocator).SendKeys(email);
            return this;
        }

        public RegistrationPage SetPassword(string password)
        {
            Browser.Instance.Driver.FindElement(passwordInputLocator).SendKeys(password);
            return this;
        }

        public RegistrationPage SetConfirmPassword(string confirmPassword)
        {
            Browser.Instance.Driver.FindElement(confirmPasswordInputLocator).SendKeys(confirmPassword);
            return this;
        }

        public void ClickRegisterButton()
        {
            Browser.Instance.Driver.FindElement(registerButtonLocator).Click();
        }

        public bool CheckFirstNameInputPresented()
        {
            return Browser.Instance.Driver.FindElement(firstNameInputLocator).Displayed;
        }

        public bool CheckErrorMassageIsCorrect()
        {
            return CheckErrorMassageIsCorrect(
                "Oops, error on page. Some of your fields have invalid data or email was previously used");
        }
    }
}