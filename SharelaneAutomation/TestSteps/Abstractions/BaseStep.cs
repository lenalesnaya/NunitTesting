using SharelaneAutomation.Pages;

namespace SharelaneAutomation.TestSteps.Abstractions
{
    internal class BaseStep
    {
        protected MainPage MainPage { get; } = new MainPage();
    }
}