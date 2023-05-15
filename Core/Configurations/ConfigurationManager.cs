using Microsoft.Extensions.Configuration;
using IConfiguration = Core.Configurations.Abstractions.IConfiguration;

namespace Core.Configurations
{
    public class ConfigurationManager
    {
        public static BrowserConfiguration Browser => BindConfiguration<BrowserConfiguration>();
        public static string CurrentDirectory => Directory.GetCurrentDirectory();

        public static string GetValue(string key)
        {
            return ConfigurationRoot[key]!;
        }

        public static string GetDirectory(string key)
        {
            string directoryRelativePath = GetValue(key).Replace("/", Path.DirectorySeparatorChar.ToString());

            return GetRootPath(directoryRelativePath);
        }

        public static string GetRootPath(params string[] fileOrDirectoryNames)
        {
            List<string> paths = new() { AppDomain.CurrentDomain.BaseDirectory };
            paths.AddRange(fileOrDirectoryNames);
            string rootPath = Path.Combine(paths.ToArray());

            return rootPath;
        }

        public static IConfigurationRoot ConfigurationRoot =>
             new ConfigurationBuilder()
            .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.custom.json", true, true)
                .Build();

        protected static T BindConfiguration<T>(IConfigurationRoot configurationRoot = null!)
            where T : IConfiguration
        {
            var config = Activator.CreateInstance<T>();
            (configurationRoot ?? ConfigurationRoot).GetSection(config.SectionName).Bind(config);

            return config;
        }
    }
}