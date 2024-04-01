using GreenCoreS21.Utilities;

namespace GreenCoreS21.Tests
{
    [TestFixture]
    public sealed class TestClass2
    {
        readonly PageFactory pageFactory = new("");

        [TearDown]
        public async Task Teardown()
        {
            await pageFactory.BrowserContext!.DisposeAsync();
        }

        [Test]
        public async Task TestPage2()
        {
            await pageFactory.Page!.GotoAsync("https://doodles.google/");
            Assert.Pass();
        }
    }
}
