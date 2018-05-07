using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace StudentCommon.Logic
{
    public static class AppGetConfiguration
    {
        private static Configuration GetConfig(Type type)
        {
            var dllLoc = new StringBuilder(
                new Uri(type.Assembly.CodeBase).LocalPath)
                .Append(".config")
                .ToString();

            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = dllLoc
            };

            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        public static string GetConnectionString(Type type)
        {
            return GetConfig(type)
                .ConnectionStrings
                .ConnectionStrings["CoreConnection"]
                .ConnectionString;
        }
    }
}
