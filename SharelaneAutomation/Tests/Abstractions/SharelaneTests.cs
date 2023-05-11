using SharelaneAutomation.Pages;

namespace SharelaneAutomation.Tests.Abstractions
{
    internal abstract class SharelaneTests : Tests
    {
        protected MainPage MainPage { get; set; }

        [SetUp]
        public void SetUpMainPage()
        {
            MainPage = new();
            MainPage.OpenPage();
        }
    }
}