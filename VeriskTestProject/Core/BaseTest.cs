using Microsoft.Playwright;
using Serilog;
using VeriskTestProject.Utilities;

namespace VeriskTestProject.Core
{
    /// <summary>
    /// A base test class from which the initialization of all needed test objects is called.
    /// Responsible for closing the BrowserContext.
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// Gets or sets the Page object.
        /// </summary>
        public IPage Page { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Base URL.
        /// </summary>
        public static string BaseUrl { get; set; } = null!;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            await TestStartup.InitializeAsync();
            Page = TestStartup.PageFactory.Page;
            Uri uri = new(Page.Url);
            BaseUrl ??= uri.GetLeftPart(UriPartial.Path);
        }

        [SetUp]
        public void Setup()
        {
            LogConfiguration.Logger.Information($"Started {TestContext.CurrentContext.Test.Name} test.");
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDownAsync()
        {
            await TestStartup.PageFactory.BrowserContext.CloseAsync();
            LogConfiguration.Logger.Information("All tests finished.");
            Log.CloseAndFlush();
        }
    }
}
