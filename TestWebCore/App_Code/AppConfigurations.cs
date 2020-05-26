using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebCore.App_Code
{
    public class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> _configurationCache;

        static AppConfigurations()
        {
            _configurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var cacheKey = path + "#" + environmentName + "#" + addUserSecrets;
            return _configurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName, addUserSecrets)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace( environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();
            return builder.Build();
        }
    }
    public static class ConfigHelper
    {
        private static IConfigurationRoot _appConfiguration = AppConfigurations.Get(System.Environment.CurrentDirectory);

        //用法1(有嵌套)：GetAppSetting("Authentication", "JwtBearer:SecurityKey")
        //用法2：GetAppSetting("App", "ServerRootAddress")
        public static string GetAppSetting(string section, string key)
        {

            return _appConfiguration.GetSection(section)[key];
        }

        public static string GetConnectionString(string key)
        {
            return _appConfiguration.GetConnectionString(key);
        }

        //public static T GetValue<T>(string key)
        //{
        //    return _appConfiguration.Get<T>(key);
        //}
    }
}
