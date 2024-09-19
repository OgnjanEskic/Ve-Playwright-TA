using VeriskTestProject.Core.Helpers;
using VeriskTestProject.Core.Interfaces;
using VeriskTestProject.Utilities;

namespace VeriskTestProject.Core
{
    /// <summary>
    /// A startup class for various initialization.
    /// </summary>
    public static class TestStartup
    {
        /// <summary>
        /// Gets or sets the Browser Context and Page objects.
        /// </summary>
        public static PageFactory PageFactory { get; private set; } = null!;

        /// <summary>
        /// Initializing various objects in a single method that will be used throughout tests.
        /// </summary>
        /// <returns>An asynchronous void operation.</returns>
        public static async Task InitializeAsync()
        {
            IJsonExtractor jsonExtractor = new JsonExtractorWrapper();

            LogConfiguration.InitializeLogger();
            LogConfiguration.Logger.Information("Test initialization started...");

            PageFactory = new PageFactory(jsonExtractor);
            await PageFactory.InitializeAsync();

            LogConfiguration.Logger.Information("Test initialization completed.");
        }
    }
}
