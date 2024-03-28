﻿using GreenCoreS21.Utilities;

namespace GreenCoreS21.Tests
{
    [TestFixture]
    public class TestClass
    {
        PageFactory pageFactory = new("");

        [TearDown]
        public async Task Teardown()
        {
            await pageFactory.browserContext!.DisposeAsync();
        }

        [Test]
        public async Task TestPage()
        {
            await pageFactory.page!.GotoAsync("https://doodles.google/");
            Assert.Pass();
        }
    }
}
