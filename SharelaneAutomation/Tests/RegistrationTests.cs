using SharelaneAutomation.Models;
using SharelaneAutomation.Models.Utilities;
using SharelaneAutomation.Pages;
using SharelaneAutomation.Tests.Abstractions;
using SharelaneAutomation.Tests.TestValues;

namespace SharelaneAutomation.Tests
{
    [TestFixture]
    internal class RegistrationTests : SharelaneTests
    {
        [Test, Category("Positive"), Description("Sign up link check.")]
        public void Register_ClickSignUpLink()
        {
            var zipCodePage = MainPage.ClickSignUpLink();
            Assert.Multiple(() =>
            {
                Assert.That(Driver!.Url, Is.EqualTo(ZipCodePage.Url));
                Assert.That(zipCodePage.CheckZipCodeInputPresented());
            });
        }

        [Test, Category("Positive"), Description("Correct zip code validation check.")]
        public void Register_ValidateCorrectZipCode()
        {
            var registrationPage = ValidateCorrectZipCode();
            Assert.That(registrationPage.CheckFirstNameInputPresented());
        }

        [Test, Category("Positive"), Description("Registration with valid credentials check.")]
        public void Register_WithValidCredentials()
        {
            var registrationConfirmationPage = Register();
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Test, Category("Positive"), Description("Registration with random user credentials check.")]
        public void Register_WithRandomUserCredentials()
        {
            var registrationConfirmationPage = Register(UserBuilder.GetRandomUser());
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Test, Category("Positive"), Description
            ("Registration with valid credentials check (empty last name field)")]
        public void Register_WithValidCredentials_EmptyLastNameField()
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                "",
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Category("LimitValues"), Description("Registration with first name limit values check")]
        [TestCase(RegistrationValues.FirstAndLastNameMinLimitValue)]
        [TestCase(RegistrationValues.FirstAndLastNameMaxLimitValue)]
        public void Register_WithFirstNameLimitValues(string firstName)
        {
            var user = UserBuilder.CreateUser(
                firstName,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Category("LimitValues"), Description("Registration with last name limit values check")]
        [TestCase(RegistrationValues.FirstAndLastNameMinLimitValue)]
        [TestCase(RegistrationValues.FirstAndLastNameMaxLimitValue)]
        public void Register_WithLastNameLimitValues(string lastName)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                lastName,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Category("LimitAndOtherPositive"), Description
            ("Registration with email limit and positive variations values check")]
        [TestCase(RegistrationValues.EmailMaxLimitValue)]
        [TestCase(RegistrationValues.EmailAlphaNumericValue)]
        [TestCase(RegistrationValues.EmailLowAlphabeticValue)]
        public void Register_WithEmailLimitAndOtherPositiveValues(string email)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                email,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Category("LimitValues"), Description("Registration with password limit values check")]
        [TestCase(RegistrationValues.PasswordMinLimitValue)]
        [TestCase(RegistrationValues.PasswordMaxLimitValue)]
        public void Register_WithPasswordLimitValues(string password)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                password);

            var registrationConfirmationPage = Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Incorrect zip code validation check.")]
        [TestCase(RegistrationValues.ZipCodeUnderlimitValue)]
        [TestCase(RegistrationValues.EmptyStringValue)]
        [TestCase(RegistrationValues.ZipCodeOverlimitValue)]
        [TestCase(RegistrationValues.ZipCodeIncorrectSymbolsValue)]
        public void Register_ValidateIncorrectZipCode_CheckErrorMessage(string zipCode)
        {
            var zipCodePage = MainPage.ClickSignUpLink().TryToValidateZipCode(zipCode);
            Assert.Multiple(() =>
            {
                Assert.That(zipCodePage.CheckErrorMassagePresented());
                Assert.That(zipCodePage.CheckErrorMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Registration with invalid first name check")]
        [TestCase(RegistrationValues.EmptyStringValue)]
        [TestCase(RegistrationValues.CyrillicValue)]
        [TestCase(RegistrationValues.AlphaNumericValue)]
        [TestCase(RegistrationValues.AlphabeticSpaceValue)]
        [TestCase(RegistrationValues.AlphaSpecialSymbolsValue)]
        [TestCase(RegistrationValues.FirstAndLastNameOverlimitValue)]
        public void Register_WithInvalidFirstName_CheckErrorMessage(string firstName)
        {
            var user = UserBuilder.CreateUser(
                firstName,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationPage = TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Registration with invalid last name check")]
        [TestCase(RegistrationValues.CyrillicValue)]
        [TestCase(RegistrationValues.AlphaNumericValue)]
        [TestCase(RegistrationValues.AlphabeticSpaceValue)]
        [TestCase(RegistrationValues.AlphaSpecialSymbolsValue)]
        [TestCase(RegistrationValues.FirstAndLastNameOverlimitValue)]
        public void Register_WithInvalidLastName_CheckErrorMessage(string lastName)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                lastName,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationPage = TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        [Test, Category("Negative"), Description("Registration with non-unique email check")]
        public void Register_WithNonUniqueEmail_CheckErrorMessage()
        {
            var registrationConfirmationPage = Register();
            var email = registrationConfirmationPage.GetEmailString();
            var user = UserBuilder.CreateUser("Sasha", "Koryavyj", email, "поле1234oOo&*");

            var registrationPage = TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Registration with invalid email check")]
        [TestCase(RegistrationValues.EmailCyrillicValue)]
        [TestCase(RegistrationValues.EmailUpAlphabeticValue)]
        [TestCase(RegistrationValues.EmailWithoutDotValue)]
        [TestCase(RegistrationValues.EmailWithoutDoggyValue)]
        [TestCase(RegistrationValues.EmailWithTwoDoggyValue)]
        [TestCase(RegistrationValues.EmailWithSpaceValue)]
        [TestCase(RegistrationValues.EmailDoggyAndDotValue)]
        [TestCase(RegistrationValues.EmptyStringValue)]
        [TestCase(RegistrationValues.EmailOverlimitValue)]
        public void Register_WithInvalidEmail_CheckErrorMessage(string email)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                email,
                UserBuilder.StandartUser.Password!);

            var registrationPage = TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Registration with invalid password check")]
        [TestCase(RegistrationValues.EmptyStringValue)]
        [TestCase(RegistrationValues.PasswordUnderLimitValue)]
        [TestCase(RegistrationValues.PasswordWithSpaceValue)]
        [TestCase(RegistrationValues.PasswordOverlimitValue)]
        public void Register_WithInvalidPassword_CheckErrorMessage(string password)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                password);

            var registrationPage = TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Registration with invalid password confirmation check")]
        [TestCase(RegistrationValues.EmptyStringValue, UserBuilder.StandartUser.Password)]
        [TestCase(UserBuilder.StandartUser.Password, RegistrationValues.EmptyStringValue)]
        [TestCase(UserBuilder.StandartUser.Password, UserBuilder.StandartUser.Password)]
        public void Register_WithInvalidPasswordConfirmation_CheckErrorMessage(
            string password,
            string confirmPassword)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                password);

            var registrationPage = TryToRegister(user, confirmPassword);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        private RegistrationPage ValidateCorrectZipCode()
        {
            return MainPage.ClickSignUpLink().ValidateZipCode(UserBuilder.StandartUser.ZipCode!);
        }

        private RegistrationConfirmationPage Register(User? user = null)
        {
            return ValidateCorrectZipCode().Register(user ?? UserBuilder.StandartUser);
        }

        private RegistrationPage TryToRegister(User user, string? confirmPassword = null)
        {
            return ValidateCorrectZipCode().TryToRegister(user, confirmPassword);
        }
    }
}