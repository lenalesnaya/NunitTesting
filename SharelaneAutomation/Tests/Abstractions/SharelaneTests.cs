using Core.Selenium;
using SharelaneAutomation.Pages;
using SharelaneAutomation.TestSteps;

namespace SharelaneAutomation.Tests.Abstractions
{
    internal abstract class SharelaneTests : Test
    {
        protected MainPage MainPage { get; } = new();
        protected RegistrationSteps RegistrationSteps { get; } = new();
        protected LoginSteps LoginSteps { get; } = new();

        [SetUp]
        public void SetUpMainPage()
        {
            MainPage.OpenPage();
        }
    }
}