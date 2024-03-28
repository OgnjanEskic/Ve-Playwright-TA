using Microsoft.Playwright;

namespace GreenCoreS21.Utilities
{
    public class PageFactory
    {
        public IBrowserContext browserContext;
        public IPage page;
        private IBrowser browser;

        public PageFactory(string urlSuffix)
        {
            NavigateToPage(urlSuffix);
        }

        private async Task NavigateToPage(string urlSuffix)
        {
            string url = JsonExtractor.GetJsonValue("BaseUrl");
            //long pageTimeout = (long)Convert.ToDouble(JsonExtractor.GetJsonValue("PageTimeout"));
            browser = PlaywrightFactory.PlaywrightSingleton.GetPlaywrightBrowser();
            browserContext = await browser.NewContextAsync();
            page = await browserContext.NewPageAsync();
            //page.SetDefaultTimeout(pageTimeout);
            await page.GotoAsync(url + urlSuffix);
        }
    }
}
