using SharelaneAutomation.Pages;
using SharelaneAutomation.TestSteps.Abstractions;

namespace SharelaneAutomation.TestSteps
{
    internal class LoginSteps : BaseStep
    {
        protected RegistrationSteps RegistrationSteps { get; } = new();

        internal MainPage Login()
        {
            var registrationConfirmationPage = RegistrationSteps.Register();
            var email = registrationConfirmationPage.GetEmailString();
            var password = registrationConfirmationPage.GetPasswordString();

            return registrationConfirmationPage.ClickMainPageLink().Login(email, password);
        }

        internal MainPage TryToLogin(string? wrongEmail = null, string? wrongPassword = null)
        {
            var registrationConfirmationPage = RegistrationSteps.Register();
            var email = registrationConfirmationPage.GetEmailString();
            var password = registrationConfirmationPage.GetPasswordString();

            return registrationConfirmationPage.ClickMainPageLink().Login(
                wrongEmail ?? email,
                wrongPassword ?? password);
        }
    }
}