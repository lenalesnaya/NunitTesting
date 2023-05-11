using Core.Configurations.Abstractions;

namespace SharelaneAutomation.Configurations
{
    internal class UrlsConfiguration : IConfiguration
    {
        public string SectionName => "SharelaneUrls";
        public string? MainPage { get; set; }
        public string? ZipCodePage { get; set; }
    }
}