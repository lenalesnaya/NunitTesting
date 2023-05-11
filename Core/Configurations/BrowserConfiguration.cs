using Core.Configurations.Abstractions;

namespace Core.Configurations
{
    public class BrowserConfiguration : IConfiguration
    {
        public string SectionName => "Browser";
        public bool Headless { get; set; }
        public string? Type { get; set; }
    }
}