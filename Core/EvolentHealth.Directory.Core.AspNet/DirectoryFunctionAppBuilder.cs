using System;
using Microsoft.Extensions.Configuration;

namespace EvolentHealth.Directory.Core.AspNet
{
    public class DirectoryFunctionAppBuilder
    {
        public static IConfigurationRoot CreatFunctionAppConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();
            return configuration;
        }
    }
}