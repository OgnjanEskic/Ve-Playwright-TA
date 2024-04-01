using Microsoft.Playwright;

namespace GreenCoreS21.Utilities
{
    /// <summary>
    /// Responsible for creating the instance of the browser context and page objects.
    /// </summary>
    public class PageFactory
    {
        public IBrowserContext? browserContext;
        public IPage? page;

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
            browserContext = await PlaywrightFactory.GetPlaywrightBrowser().NewContextAsync();
            page = await browserContext.NewPageAsync();
            page.SetDefaultTimeout(pageTimeout);
            await page.GotoAsync(url + urlSuffix);
        }
    }
}
