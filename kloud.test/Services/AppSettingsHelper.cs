using kloud.web.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace kloud.test.Services
{
    static class AppSettingsHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static AppSettings GetApplicationConfiguration(string outputPath)
        {
            var configuration = new AppSettings();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("ApplicationSettings")
                .Bind(configuration);

            return configuration;
        }
    }
}
