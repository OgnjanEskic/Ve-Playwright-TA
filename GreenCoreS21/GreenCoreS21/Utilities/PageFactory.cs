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

        public PageFactory(string urlSuffix)
        {
            NavigateToPage(urlSuffix).Wait();
        }

        private async Task NavigateToPage(string urlSuffix)
        {
            string url = JsonExtractor.GetJsonValue("BaseUrl");
            long pageTimeout = (long)Convert.ToDouble(JsonExtractor.GetJsonValue("PageTimeout"));
            browserContext = await PlaywrightFactory.GetPlaywrightBrowser().NewContextAsync();
            page = await browserContext.NewPageAsync();
            page.SetDefaultTimeout(pageTimeout);
            await page.GotoAsync(url + urlSuffix);
        }
    }
}
