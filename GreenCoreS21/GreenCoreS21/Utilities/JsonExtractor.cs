﻿using Microsoft.Extensions.Configuration;

namespace GreenCoreS21.Utilities
{
    /// <summary>
    /// A Class responsible for reading and extracting values from Appsettings config based on the given key.
    /// </summary>
    public static class JsonExtractor
    {
        private static IConfiguration config = null!;

        private static IConfigurationRoot GetJsonValues()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        /// <summary>
        /// Extracts the single value from Appsettings based on the submitted key.
        /// </summary>
        /// <param name="value">Appsettings key value.</param>
        /// <returns>The string value of derived key.</returns>
        public static string GetSingleJsonValue(string value)
        {
            config ??= GetJsonValues();
            string? jsonValue = config.GetSection(value).Value;

            return jsonValue!;
        }
    }
}
