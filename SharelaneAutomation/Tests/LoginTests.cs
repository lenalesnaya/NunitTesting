using Core.Utilities;
using SharelaneAutomation.Pages;
using SharelaneAutomation.Tests.Abstractions;

namespace SharelaneAutomation.Tests
{
    [TestFixture]
    internal class LoginTests : SharelaneTests
    {
        [Test, Category("Positive"), Description("Login with valid credentials check.")]
        public void Login_WithValidCredentials()
        {
            var mainPage = Login();
            Assert.Multiple(() =>
            {
                Assert.That(mainPage.CheckHelloUserPresented);
                Assert.That(mainPage.CheckLogoutHrefPresented);
            });
        }

        [Test, Category("Positive"), Description("Logout check.")]
        public void Logout()
        {
            var mainPage = Login();
            var logoutPage = mainPage.ClickLogoutLink();

            Assert.Multiple(() =>
            {
                Assert.That(logoutPage.CheckLogoutInscriptionPresented());
                Assert.That(logoutPage.CheckConfirmationMessagePresented());
                Assert.That(logoutPage.CheckConfirmationMassageIsCorrect());
            });
        }

        [Category("Negative"), Description("Login with invalid credentials check")]
        [TestCase("lenkapenka@gmail.com", "иГН64%$ШИ")]
        public void Login_WithInvalidCredentials_CheckErrorMessage(string email, string password)
        {
            var mainPage = MainPage.TryToLogin(email, password);
            Assert.Multiple(() =>
            {
                Assert.That(mainPage.CheckErrorMassagePresented());
                Assert.That(mainPage.CheckErrorMassageIsCorrect());
            });
        }

        [Test, Category("Negative"), Description("Login with invalid password check")]
        public void Login_WithInvalidPassword_CheckErrorMessage()
        {
            var registrationConfirmationPage = Register();
            var email = registrationConfirmationPage.GetEmailString();
            var mainPage = registrationConfirmationPage.ClickMainPageLink().Login(email, "");

            Assert.Multiple(() =>
            {
                Assert.That(mainPage.CheckErrorMassagePresented());
                Assert.That(mainPage.CheckErrorMassageIsCorrect());
            });
        }

        private MainPage Login()
        {
            var registrationConfirmationPage = Register();
            var email = registrationConfirmationPage.GetEmailString();
            var password = registrationConfirmationPage.GetPasswordString();

            return registrationConfirmationPage.ClickMainPageLink().Login(email, password);
        }

        private RegistrationConfirmationPage Register()
        {
            return MainPage.
                ClickSignUpLink().
                ValidateZipCode(UserBuilder.StandartUser.ZipCode!).
                Register(UserBuilder.StandartUser);
        }
    }
}