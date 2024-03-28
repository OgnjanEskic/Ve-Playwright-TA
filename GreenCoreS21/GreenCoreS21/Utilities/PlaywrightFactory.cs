using Microsoft.Playwright;

namespace GreenCoreS21.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PlaywrightFactory
    {
        private static PlaywrightFactory? instance;
        private static Lazy<IPlaywright> playwright = new Lazy<IPlaywright>(() => Playwright.CreateAsync().Result);
        private static IBrowser? browser;
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

        private PlaywrightFactory()
        {

        }

        //public static async Task<IBrowser> PlaywrightBrowserType()
        //{
        //    string browserName = JsonExtractor.GetJsonValue("Browser");
        //    switch (browserName)
        //    {
        //        case BrowserType.Firefox:
        //            browser = await playwright.Value.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
        //            {
        //                Headless = false,
        //            });
        //            break;

        //        case BrowserType.Chromium:
        //            browser = await playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        //            {
        //                Headless = false,
        //            });
        //            break;

        //        case BrowserType.Webkit:
        //            browser = await playwright.Value.Webkit.LaunchAsync(new BrowserTypeLaunchOptions()
        //            {
        //                Headless = false,
        //            });
        //            break;

        //        default:
        //            browser = await playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        //            {
        //                Headless = false,
        //            }).Result;
        //            break;
        //    }

        //    return browser;
        //}

        public IBrowser GetPlaywrightBrowser()
        {
            if (browser == null)
            {
                browser = playwright.Value.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                }).Result;
            }
            return browser;
        }
    }
}
