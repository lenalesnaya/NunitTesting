using Core.Models;
using Core.Utilities;
using SharelaneAutomation.Pages;
using SharelaneAutomation.Tests.Abstractions;

namespace SharelaneAutomation.Tests
{
    [TestFixture]
    internal class RegistrationTests : SharelaneTests
    {
        private const string firstAndLastNameMinLimitValue = "j";
        private const string MaxLimitValue =
            "ghjdfghsdfgbndfgbnsdvbndfgnmdfghjdfcvgbnmdfcvgbndfgvbhndfgvbhfvgbhghjdfghsd" +
            "fgbndfgbnsdvbndfgnmdfghjdfcvgbnmdfcvgbndfgvbhndfgvbhfvgbhghjdfghsdfgbndfgb" +
            "nsdvbndfgnmdfghjdfcvgbnmdfcvgbndfgvbhndfgvbhfvgbhghjdfghsdfgbndfgbnsdvbnd" +
            "fgnmdfghjdfcvgbnmdfcvgbndfgvbhndLL";
        private const string OverlimitValue =
            "ghjdfghsdfgbndfgbnsdvbndfgnmdfghjdfcvgbnmdfcvgbndfgvbhndfgvbhfvgbhghjdfghsd" +
            "fgbndfgbnsdvbndfgnmdfghjdfcvgbnmdfcvgbndfgvbhndfgvbhfvgbhghjdfghsdfgbndfgb" +
            "nsdvbndfgnmdfghjdfcvgbnmdfcvgbndfgvbhndfgvbhfvgbhghjdfghsdfgbndfgbnsdvbnd" +
            "fgnmdfghjdfcvgbnmdfcvgbndfgvbhndLLL";
        private const string emailMaxLimitValue =
            "lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123len" +
            "ka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka" +
            "_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_" +
            "123lenka_123lenka_123lenka@mail.ru";
        private const string emailOverlimitValue =
            "lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123len" +
            "ka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka" +
            "_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_123lenka_" +
            "123lenka_123lenka_123lenkaa@mail.ru";

        [Test, Category("Positive"), Description("Sign up link check.")]
        public void Register_ClickSignUpLink()
        {
            var zipCodePage = MainPage.ClickSignUpLink();
            Assert.Multiple(() =>
            {
                Assert.That(Driver.Url, Is.EqualTo(ZipCodePage.Url));
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
        [TestCase(firstAndLastNameMinLimitValue)]
        [TestCase(MaxLimitValue)]
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
        [TestCase(firstAndLastNameMinLimitValue)]
        [TestCase(MaxLimitValue)]
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
        [TestCase(emailMaxLimitValue)]
        [TestCase("123lenka@mail.ru")]
        [TestCase("lenka@mail.ru")]
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
        [TestCase("10Mu")]
        [TestCase(MaxLimitValue)]
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
        [TestCase("1234")]
        [TestCase("")]
        [TestCase("123456")]
        [TestCase("bb)0%")]
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
        [TestCase("")]
        [TestCase("Елена")]
        [TestCase("Elena123")]
        [TestCase("El ena")]
        [TestCase("Elena!@#")]
        [TestCase(OverlimitValue)]
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
        [TestCase("Лесная")]
        [TestCase("Lesnaya123")]
        [TestCase("Les naya")]
        [TestCase("Lesnaya!@#")]
        [TestCase(OverlimitValue)]
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
        [TestCase("123ленка@mail.ru")]
        [TestCase("123LenkA@mail.ru")]
        [TestCase("123lenka@mailru")]
        [TestCase("123lenkamail.ru")]
        [TestCase("123lenka@@mail.ru")]
        [TestCase("123lenka @mail.ru")]
        [TestCase("@.")]
        [TestCase("")]
        [TestCase(emailOverlimitValue)]
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
        [TestCase("")]
        [TestCase("b1*")]
        [TestCase("b1 *")]
        [TestCase(OverlimitValue)]
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
        [TestCase("", "лес123oBlako&*")]
        [TestCase("лес123oBlako&*", "")]
        [TestCase("лес123oBlako&*", "123oBlako&*лес")]
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