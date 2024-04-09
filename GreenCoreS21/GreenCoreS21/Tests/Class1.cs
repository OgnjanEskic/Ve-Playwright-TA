using GreenCoreS21.Utilities;

namespace GreenCoreS21.Tests
{
    [TestFixture]
    public sealed class TestClass
    {
        readonly PageFactory pageFactory = new("");

        [TearDown]
        public async Task Teardown()
        {
            await pageFactory.BrowserContext!.DisposeAsync();
        }

        [Test]
        public async Task TestPage()
        {
            Assert.That(await pageFactory.Page!.Locator("#APjFqb").IsVisibleAsync(), Is.True);
            await pageFactory.Page.GotoAsync("https://doodles.google/");
            Assert.That(await pageFactory.Page!.Locator(".glue-header__link").First.IsVisibleAsync(), Is.True);
        }
    }
}
