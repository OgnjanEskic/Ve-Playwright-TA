using GreenCoreS21.Utilities;
using Microsoft.Playwright;

namespace GreenCoreS21.Tests
{
    [TestFixture]
    public class TestClass
    {
        //PageFactory pageFactory = new PageFactory("");
        private IBrowser browser;
        private IBrowserContext context;

        [SetUp]
        public async Task PageSetup()
        {
            browser = PlaywrightFactory.PlaywrightSingleton.GetPlaywrightBrowser();
            context = await browser.NewContextAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            context.DisposeAsync();
        }

        [Test]
        public async Task TestPage()
        {
            IPage page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.google.com/");
            //pageFactory.page.GotoAsync("https://doodles.google/");
            Assert.Pass();
        }
    }
}
