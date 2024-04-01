using Microsoft.Extensions.Configuration;

namespace GreenCoreS21.Utilities
{
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

        public static string GetSingleJsonValue(string value)
        {
            config ??= GetJsonValues();
            string? jsonValue = config.GetSection(value).Value;

            return jsonValue!;
        }
    }
}
