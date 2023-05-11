using Core.Selenium;
using OpenQA.Selenium;
using SharelaneAutomation.Pages.Abstractions;

namespace SharelaneAutomation.Pages
{
    internal class LogoutPage : Page
    {
        private readonly By logoutInscriptionLocator = By.XPath("//b[text()='Log out']");

        public bool CheckLogoutInscriptionPresented()
        {
            return Browser.Instance.Driver.FindElement(logoutInscriptionLocator).Displayed;
        }

        public bool CheckConfirmationMassageIsCorrect()
        {
            return CheckConfirmationMassageIsCorrect("You've been logged out");
        }
    }
}