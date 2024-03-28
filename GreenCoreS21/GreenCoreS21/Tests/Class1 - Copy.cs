using GreenCoreS21.Utilities;

namespace GreenCoreS21.Tests
{
    [TestFixture]
    public class TestClass2
    {
        PageFactory pageFactory = new PageFactory("");
        //private IBrowser browser;
        //private IBrowserContext context;

        [SetUp]
        public async Task PageSetup()
        {
            //browser = PlaywrightFactory.PlaywrightSingleton.GetPlaywrightBrowser();
            //context = await browser.NewContextAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await pageFactory.browserContext.DisposeAsync();
            //context.DisposeAsync();
        }

        [Test]
        public async Task TestPage2()
        {
            //IPage page = await browser.NewPageAsync();
            //await page.GotoAsync("https://www.google.com/");
            await pageFactory.page.GotoAsync("https://doodles.google/");
            Assert.Pass();
        }
    }
}
