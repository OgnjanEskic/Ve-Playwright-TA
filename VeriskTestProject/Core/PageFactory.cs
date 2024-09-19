using Microsoft.Playwright;
using VeriskTestProject.Core.Interfaces;

namespace VeriskTestProject.Core
{
    /// <summary>
    /// Responsible for creating the instance of the browser context and page objects.
    /// </summary>
    public class PageFactory
    {
        /// <summary>
        /// Gets or sets the browser context.
        /// </summary>
        public IBrowserContext BrowserContext { get; private set; } = null!;

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public IPage Page { get; private set; } = null!;

        private readonly IJsonExtractor _jsonExtractor;

        /// <summary>
        /// PageFactory constructor.
        /// </summary>
        /// <param name="jsonExtractor">Url suffix that will be concatenated with the base Url.</param>
        public PageFactory(IJsonExtractor jsonExtractor)
        {
            _jsonExtractor = jsonExtractor;
        }

        /// <summary>
        /// Initializing Browser Context and Page objects. Navigates to given Url afterwards.
        /// </summary>
        /// <param name="urlSuffix">Extension of the Url. Leave empty string if it is suffice.</param>
        /// <returns>Returns an asynchronous void operation.</returns>
        public async Task InitializeAsync()
        {
            string url = _jsonExtractor.GetSingleJsonValue("BaseUrl");
            long pageTimeout = (long)Convert.ToDouble(_jsonExtractor.GetSingleJsonValue("PageTimeout"));

            BrowserContext = await PlaywrightFactory.GetPlaywrightBrowser().NewContextAsync();

            Page = await BrowserContext.NewPageAsync();
            Page.SetDefaultTimeout(pageTimeout);
            await Page.GotoAsync(url);
        }
    }
}
