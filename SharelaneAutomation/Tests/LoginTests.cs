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
            var mainPage = LoginSteps.Login();
            Assert.Multiple(() =>
            {
                Assert.That(mainPage.CheckHelloUserPresented);
                Assert.That(mainPage.CheckLogoutHrefPresented);
            });
        }

        [Test, Category("Positive"), Description("Logout check.")]
        public void Logout()
        {
            var mainPage = LoginSteps.Login();
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
            LoginSteps.TryToLogin(wrongPassword: "");
            Assert.Multiple(() =>
            {
                Assert.That(MainPage.CheckErrorMassagePresented());
                Assert.That(MainPage.CheckErrorMassageIsCorrect());
            });
        }
    }
}