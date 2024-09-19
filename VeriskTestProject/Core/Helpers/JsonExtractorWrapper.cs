using VeriskTestProject.Core.Interfaces;
using VeriskTestProject.Utilities;

namespace VeriskTestProject.Core.Helpers
{
    /// <summary>
    /// Wrap class responsible for allowing dependency injection
    /// to static JsonExtractor class.
    /// </summary>
    public class JsonExtractorWrapper : IJsonExtractor
    {
        /// <summary>
        /// Extracts the single value from Appsettings based on the submitted key.
        /// </summary>
        /// <param name="key">Appsettings key value.</param>
        /// <returns>The string value of derived key.</returns>
        public string GetSingleJsonValue(string key)
        {
            return JsonExtractor.GetSingleJsonValue(key);
        }
    }
}
