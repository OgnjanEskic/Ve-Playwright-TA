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
        private static Lazy<IPlaywright> playwright = new Lazy<IPlaywright>(() => Playwright.CreateAsync().Result);
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
                if (instance == null)
                {
                    instance = new PlaywrightFactory();
                }
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
            switch (browserName)
            {
                case BrowserType.Firefox:
                    browser = playwright.Value.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false,
                    }).Result;
                    break;

                case BrowserType.Chromium:
                    browser = playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false,
                    }).Result;
                    break;

                case BrowserType.Webkit:
                    browser = playwright.Value.Webkit.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false,
                    }).Result;
                    break;

                default:
                    browser = playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                    {
                        Headless = false,
                    }).Result;
                    break;
            }

            return browser;
        }

        /// <summary>
        /// Instantiate the browser if the browser is missing.
        /// </summary>
        /// <returns>An instance of the browser.</returns>
        public static IBrowser GetPlaywrightBrowser()
        {
            if (browser == null)
            {
                browser = PlaywrightBrowserType();
            }
            return browser;
        }
    }
}
