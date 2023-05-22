using SharelaneAutomation.Models.Utilities;
using SharelaneAutomation.Models;
using SharelaneAutomation.Pages;
using SharelaneAutomation.TestSteps.Abstractions;

namespace SharelaneAutomation.TestSteps
{
    internal class RegistrationSteps : BaseStep
    {
        internal RegistrationPage ValidateCorrectZipCode() =>
            MainPage.ClickSignUpLink().ValidateZipCode(UserBuilder.StandartUser.ZipCode!);

        internal RegistrationConfirmationPage Register(User? user = null) =>
            ValidateCorrectZipCode().Register(user ?? UserBuilder.StandartUser);

        internal RegistrationPage TryToRegister(User user, string? confirmPassword = null) =>
            ValidateCorrectZipCode().TryToRegister(user, confirmPassword);
    }
}