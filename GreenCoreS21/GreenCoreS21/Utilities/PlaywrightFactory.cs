using Microsoft.Playwright;

namespace GreenCoreS21.Utilities
{
    /// <summary>
    /// A PlaywrightFactory class is responsible to create Singleton instance of the Playwright and the Browser
    /// throughout Assembly.
    /// </summary>
    public sealed class PlaywrightFactory
    {
        private static PlaywrightFactory? instance;
        private static readonly Lazy<IPlaywright> playwright = new(() => Playwright.CreateAsync().Result);
        private static IBrowser? browser;

        /// <summary>
        /// PlaywrightFactory private constructor.
        /// </summary>
        private PlaywrightFactory()
        {
        }

        /// <summary>
        /// Gets the PlaywrightSingleton by calling PlaywrightFactory() private constructor
        /// who populate static instance field of the PlaywrightFactory.
        /// </summary>
        public static PlaywrightFactory PlaywrightSingleton
        {
            get
            {
                instance ??= new PlaywrightFactory();
                return instance;
            }
        }

        /// <summary>
        /// Chooses the browser type by reading appsettings file where preferred browser type is written into.
        /// </summary>
        /// <returns>An instance of the browser.</returns>
        private static IBrowser PlaywrightBrowserType()
        {
            string browserName = JsonExtractor.GetJsonValue("Browser");
            browser = browserName switch
            {
                BrowserType.Firefox => playwright.Value.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                }).Result,
                BrowserType.Chromium => playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                }).Result,
                BrowserType.Webkit => playwright.Value.Webkit.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                }).Result,
                _ => playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                }).Result,
            };
            return browser;
        }

        /// <summary>
        /// Instantiate the browser if the browser is missing.
        /// </summary>
        /// <returns>An instance of the browser.</returns>
        public static IBrowser GetPlaywrightBrowser()
        {
            browser ??= PlaywrightBrowserType();
            return browser;
        }
    }
}
