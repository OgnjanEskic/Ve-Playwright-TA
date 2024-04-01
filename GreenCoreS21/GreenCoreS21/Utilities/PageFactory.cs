using Microsoft.Playwright;

namespace GreenCoreS21.Utilities
{
    /// <summary>
    /// Responsible for creating the instance of the browser context and page objects.
    /// </summary>
    public class PageFactory
    {
        /// <summary>
        /// Gets or sets the browser context.
        /// </summary>
        public IBrowserContext? BrowserContext { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public IPage? Page { get; set; }

        /// <summary>
        /// PageFactory constructor.
        /// </summary>
        /// <param name="urlSuffix"></param>
        public PageFactory(string urlSuffix)
        {
            NavigateToPage(urlSuffix).Wait();
        }

        private async Task NavigateToPage(string urlSuffix)
        {
            string url = JsonExtractor.GetSingleJsonValue("BaseUrl");
            long pageTimeout = (long)Convert.ToDouble(JsonExtractor.GetSingleJsonValue("PageTimeout"));
            BrowserContext = await PlaywrightFactory.GetPlaywrightBrowser().NewContextAsync();
            Page = await BrowserContext.NewPageAsync();
            Page.SetDefaultTimeout(pageTimeout);
            await Page.GotoAsync(url + urlSuffix);
        }
    }
}
