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
            var registrationPage = RegistrationSteps.ValidateCorrectZipCode();
            Assert.That(registrationPage.CheckFirstNameInputPresented());
        }

        [Test, Category("Positive"), Description("Registration with valid credentials check.")]
        public void Register_WithValidCredentials()
        {
            var registrationConfirmationPage = RegistrationSteps.Register();
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Test, Category("Positive"), Description("Registration with random user credentials check.")]
        public void Register_WithRandomUserCredentials()
        {
            var registrationConfirmationPage = RegistrationSteps.Register(UserBuilder.GetRandomUser());
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Test, Category("Positive"), Description
            ("Registration with valid credentials check (empty last name field)")]
        public void Register_WithValidCredentials_EmptyLastNameField() =>
            CheckCorrectLastNameValidation(string.Empty);

        [Test, Category("Positive"), Description("Registration with email alphanumeric value check")]
        public void Register_WithEmailAlphaNumericValue() =>
            CheckCorrectEmailValidation(RegistrationValues.EmailAlphaNumericValue);

        [Test, Category("Positive"), Description("Registration with email alphabetic value check")]
        public void Register_WithEmailAlphabeticValue() =>
            CheckCorrectEmailValidation(RegistrationValues.EmailLowAlphabeticValue);

        [Test, Category("LimitValues"), Description("Registration with first name min limit value check")]
        public void Register_WithFirstNameMinLimitValue() =>
            CheckCorrectFirstNameValidation(RegistrationValues.FirstAndLastNameMinLimitValue);

        [Test, Category("LimitValues"), Description("Registration with first name max limit value check")]
        public void Register_WithFirstNameMaxLimitValue() =>
            CheckCorrectFirstNameValidation(RegistrationValues.FirstAndLastNameMaxLimitValue);

        [Test, Category("LimitValues"), Description("Registration with last name min limit value check")]
        public void Register_WithLastNameMinLimitValue() =>
            CheckCorrectLastNameValidation(RegistrationValues.FirstAndLastNameMinLimitValue);

        [Test, Category("LimitValues"), Description("Registration with last name max limit value check")]
        public void Register_WithLastNameMaxLimitValues() =>
            CheckCorrectLastNameValidation(RegistrationValues.FirstAndLastNameMaxLimitValue);

        [Test, Category("LimitValues"), Description("Registration with email max limit value check")]
        public void Register_WithEmailMaxLimitValue() =>
            CheckCorrectEmailValidation(RegistrationValues.EmailMaxLimitValue);

        [Test, Category("LimitValues"), Description("Registration with password min limit value check")]
        public void Register_WithPasswordMinLimitValue() =>
            CheckCorrectPasswordValidation(RegistrationValues.PasswordMinLimitValue);

        [Test, Category("LimitValues"), Description("Registration with password max limit value check")]
        public void Register_WithPasswordMaxLimitValue() =>
            CheckCorrectPasswordValidation(RegistrationValues.PasswordMaxLimitValue);

        [Test, Category("Negative"), Description("Incorrect zip code validation check (underlimit value).")]
        public void Register_ValidateUnderlimitValueZipCode_CheckErrorMessage() =>
            CheckIncorrectZipCodeValidation(RegistrationValues.ZipCodeUnderlimitValue);

        [Test, Category("Negative"), Description("Incorrect zip code validation check (empty string value).")]
        public void Register_ValidateEmptyStringValueZipCode_CheckErrorMessage() =>
            CheckIncorrectZipCodeValidation(RegistrationValues.EmptyStringValue);

        [Test, Category("Negative"), Description("Incorrect zip code validation check (overlimit value).")]
        public void Register_ValidateOverlimitValueZipCode_CheckErrorMessage() =>
            CheckIncorrectZipCodeValidation(RegistrationValues.ZipCodeOverlimitValue);

        [Test, Category("Negative"), Description("Incorrect zip code validation check (incorrect symbols).")]
        public void Register_ValidateIncorrectSymbolsValueZipCode_CheckErrorMessage() =>
            CheckIncorrectZipCodeValidation(RegistrationValues.ZipCodeIncorrectSymbolsValue);

        [Test, Category("Negative"), Description("Registration with invalid first name check (empty string value).")]
        public void Register_WithEmptyStringValueFirstName_CheckErrorMessage() =>
            CheckIncorrectFirstNameValidation(RegistrationValues.EmptyStringValue);

        [Test, Category("Negative"), Description("Registration with invalid first name check (cyrillic value).")]
        public void Register_WithCyrillicValueFirstName_CheckErrorMessage() =>
            CheckIncorrectFirstNameValidation(RegistrationValues.CyrillicValue);

        [Test, Category("Negative"), Description("Registration with invalid first name check (alphanumeric value).")]
        public void Register_WithAlphaNumericValueFirstName_CheckErrorMessage() =>
            CheckIncorrectFirstNameValidation(RegistrationValues.AlphaNumericValue);

        [Test, Category("Negative"), Description("Registration with invalid first name check (containing a space value).")]
        public void Register_WithContainingSpaceValueFirstName_CheckErrorMessage() =>
            CheckIncorrectFirstNameValidation(RegistrationValues.AlphabeticSpaceValue);

        [Test, Category("Negative"), Description("Registration with invalid first name check (alphabitic with special symbols value).")]
        public void Register_WithContainingSpecialSymbolsValueFirstName_CheckErrorMessage() =>
            CheckIncorrectFirstNameValidation(RegistrationValues.AlphaSpecialSymbolsValue);

        [Test, Category("Negative"), Description("Registration with invalid first name check (overlimit value).")]
        public void Register_WithOverlimitValueFirstName_CheckErrorMessage() =>
            CheckIncorrectFirstNameValidation(RegistrationValues.FirstAndLastNameOverlimitValue);

        [Test, Category("Negative"), Description("Registration with invalid last name check (cyrillic value).")]
        public void Register_WithCyrillicValueLastName_CheckErrorMessage() =>
            CheckIncorrectLastNameValidation(RegistrationValues.CyrillicValue);

        [Test, Category("Negative"), Description("Registration with invalid last name check (alphanumeric value).")]
        public void Register_WithAlphaNumericValueLastName_CheckErrorMessage() =>
            CheckIncorrectLastNameValidation(RegistrationValues.AlphaNumericValue);

        [Test, Category("Negative"), Description("Registration with invalid last name check (containing a space value).")]
        public void Register_WithContainingSpaceValueLastName_CheckErrorMessage() =>
            CheckIncorrectLastNameValidation(RegistrationValues.AlphabeticSpaceValue);

        [Test, Category("Negative"), Description("Registration with invalid last name check (containing spacial symbols value).")]
        public void Register_WithContainingSpecialSymbolsValueLastName_CheckErrorMessage() =>
            CheckIncorrectLastNameValidation(RegistrationValues.AlphaSpecialSymbolsValue);

        [Test, Category("Negative"), Description("Registration with invalid last name check (overlimit value).")]
        public void Register_WithOverlimitValueLastName_CheckErrorMessage() =>
            CheckIncorrectLastNameValidation(RegistrationValues.FirstAndLastNameOverlimitValue);

        [Test, Category("Negative"), Description("Registration with non-unique email check")]
        public void Register_WithNonUniqueEmail_CheckErrorMessage()
        {
            var registrationConfirmationPage = RegistrationSteps.Register();
            var email = registrationConfirmationPage.GetEmailString();
            registrationConfirmationPage.ClickMainPageLink();

            var user = UserBuilder.CreateUser("Sasha", "Koryavyj", email, "поле1234oOo&*");

            var registrationPage = RegistrationSteps.TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        [Test, Category("Negative"), Description("Registration with invalid email check (cyrillic value).")]
        public void Register_WithCyrillicValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailCyrillicValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (upper alphabetic value).")]
        public void Register_WithUpperAlphabeticValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailUpAlphabeticValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (value without dot).")]
        public void Register_WithValueWithoutDotEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailWithoutDotValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (without doggy value)")]
        public void Register_WithValueWithoutDoggyEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailWithoutDoggyValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (with two doggy value)")]
        public void Register_WithTwoDoggyValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailWithTwoDoggyValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (value with space).")]
        public void Register_WithContainingSpaceValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailWithSpaceValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (just doggy and dot value).")]
        public void Register_WithDoggyAndDotValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailDoggyAndDotValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (empty string value).")]
        public void Register_WithEmptyStringValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmptyStringValue);

        [Test, Category("Negative"), Description("Registration with invalid email check (overlimit value).")]
        public void Register_WithOverlimitValueEmail_CheckErrorMessage() =>
            CheckIncorrectEmailValidation(RegistrationValues.EmailOverlimitValue);

        [Test, Category("Negative"), Description("Registration with invalid password check (empty string value).")]
        public void Register_WithEmptyStringValuePassword_CheckErrorMessage() =>
            CheckIncorrectPasswordValidation(RegistrationValues.EmptyStringValue);

        [Test, Category("Negative"), Description("Registration with invalid password check (underlimit value).")]
        public void Register_WithUnderLimitValuePassword_CheckErrorMessage() =>
            CheckIncorrectPasswordValidation(RegistrationValues.PasswordUnderLimitValue);

        [Test, Category("Negative"), Description("Registration with invalid password check (value with space).")]
        public void Register_WithContainingSpaceValuePassword_CheckErrorMessage() =>
            CheckIncorrectPasswordValidation(RegistrationValues.PasswordWithSpaceValue);

        [Test, Category("Negative"), Description("Registration with invalid password check (overlimit value).")]
        public void Register_WithOverlimitValuePassword_CheckErrorMessage() =>
            CheckIncorrectPasswordValidation(RegistrationValues.PasswordOverlimitValue);

        [Test, Category("Negative"), Description(
            "Registration with invalid password confirmation check (password is empty, password confirmation is filled).")]
        public void Register_WithEmptyPasswordAndFilledPasswordConfirmation_CheckErrorMessage() =>
            CheckIncorrectPasswordConfirmationValidation(
            RegistrationValues.EmptyStringValue,
            UserBuilder.StandartUser.Password!);

        [Test, Category("Negative"), Description(
            "Registration with invalid password confirmation check (password is filled, password confirmation is empty).")]
        public void Register_WithFilledPasswordAndEmptyPasswordConfirmation_CheckErrorMessage() =>
            CheckIncorrectPasswordConfirmationValidation(
            UserBuilder.StandartUser.Password!,
            RegistrationValues.EmptyStringValue);

        [Test, Category("Negative"), Description(
            "Registration with invalid password confirmation check (password and password confirmation is different).")]
        public void Register_WithDifferentPasswordAndConfirmation_CheckErrorMessage() =>
            CheckIncorrectPasswordConfirmationValidation(
            UserBuilder.StandartUser.Password!,
            RegistrationValues.PasswordConfirmationRandomValue);

        private void CheckCorrectFirstNameValidation(string firstName)
        {
            var user = UserBuilder.CreateUser(
                firstName,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = RegistrationSteps.Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        private void CheckCorrectLastNameValidation(string lastName)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                lastName,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = RegistrationSteps.Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        private void CheckCorrectEmailValidation(string email)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                email,
                UserBuilder.StandartUser.Password!);

            var registrationConfirmationPage = RegistrationSteps.Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        public void CheckCorrectPasswordValidation(string password)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                password);

            var registrationConfirmationPage = RegistrationSteps.Register(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationConfirmationPage.CheckConfirmationMessagePresented());
                Assert.That(registrationConfirmationPage.CheckConfirmationMassageIsCorrect());
            });
        }

        private void CheckIncorrectZipCodeValidation(string zipCode)
        {
            var zipCodePage = MainPage.ClickSignUpLink().TryToValidateZipCode(zipCode);
            Assert.Multiple(() =>
            {
                Assert.That(zipCodePage.CheckErrorMassagePresented());
                Assert.That(zipCodePage.CheckErrorMassageIsCorrect());
            });
        }

        private void CheckIncorrectFirstNameValidation(string firstName)
        {
            var user = UserBuilder.CreateUser(
                firstName,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationPage = RegistrationSteps.TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        private void CheckIncorrectLastNameValidation(string lastName)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                lastName,
                UserBuilder.StandartUser.Email!,
                UserBuilder.StandartUser.Password!);

            var registrationPage = RegistrationSteps.TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        private void CheckIncorrectEmailValidation(string email)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                email,
                UserBuilder.StandartUser.Password!);

            var registrationPage = RegistrationSteps.TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        private void CheckIncorrectPasswordValidation(string password)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                password);

            var registrationPage = RegistrationSteps.TryToRegister(user);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }

        private void CheckIncorrectPasswordConfirmationValidation(
            string password,
            string confirmPassword)
        {
            var user = UserBuilder.CreateUser(
                UserBuilder.StandartUser.FirstName!,
                UserBuilder.StandartUser.LastName!,
                UserBuilder.StandartUser.Email!,
                password);

            var registrationPage = RegistrationSteps.TryToRegister(user, confirmPassword);
            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.CheckErrorMassagePresented());
                Assert.That(registrationPage.CheckErrorMassageIsCorrect());
            });
        }
    }
}