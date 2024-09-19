using Microsoft.Playwright;
using VeriskTestProject.Core;
using VeriskTestProject.Core.Entities;

namespace VeriskTestProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public sealed class HomePageTests : BaseTest
    {
        [Test]
        public async Task HomePage_Click_NavigatesToHomePage()
        {
            //Act
            await Page.GetByLabel("home").ClickAsync();

            //Assert
            Assert.That(Page.Url, Is.SamePath("https://www.verisksequel.com/"));
        }

        [Test]
        public async Task VeriskLogo_Check_IsVisible()
        {
            //Arrange
            string svgStringId = "svg#Layer_1";

            //Act
            await Page.WaitForSelectorAsync(svgStringId);
            var svgElement = Page.Locator(svgStringId).First;

            //Assert
            Assert.That(svgElement, Is.Not.Null, "SVG image does not exist on the page.");
        }

        [Test]
        public void BarMenuElements_Exist()
        {
            //Act
            var allItemsPresent = AreAllMenuItemsPresentAsync(Page).Result;

            //Assert
            Assert.That(allItemsPresent, Is.True, "Not all menu items are present.");
        }

        private async Task<bool> AreAllMenuItemsPresentAsync(IPage page)
        {
            MenuBarItems menuBarItems = new();
            var menuBarList = new List<string>()
            {
                menuBarItems.Solutions,
                menuBarItems.Products,
                menuBarItems.News,
                menuBarItems.Company,
                menuBarItems.Careers,
                menuBarItems.Contact
            };

            foreach (var item in menuBarList)
            {
                await page.WaitForSelectorAsync($"li:has(a span:text('{item}'))");
                var isElementPresent = await page.Locator($"li:has(a span:text('{item}'))").IsVisibleAsync();

                if (!isElementPresent)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
