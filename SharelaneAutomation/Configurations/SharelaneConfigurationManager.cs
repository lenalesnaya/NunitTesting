using Core.Configurations;

namespace SharelaneAutomation.Configurations
{
    internal class SharelaneConfigurationManager : ConfigurationManager
    {
        public static UrlsConfiguration Urls => BindConfiguration<UrlsConfiguration>();
    }
}