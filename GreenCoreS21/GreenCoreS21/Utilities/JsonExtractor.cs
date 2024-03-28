using Microsoft.Extensions.Configuration;

namespace GreenCoreS21.Utilities
{
    public static class JsonExtractor
    {
        public static string GetJsonValue(string value)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            string? jsonValue = config.GetSection(value).Value;

            return jsonValue!;
        }
    }
}
