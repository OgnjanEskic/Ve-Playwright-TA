using Microsoft.Playwright;
using VeriskTestProject.Core;
using VeriskTestProject.Core.Entities;

namespace VeriskTestProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public sealed class ContactPageTests : BaseTest
    {
        [OneTimeSetUp]
        public async Task UrlSetupAsync()
        {
            await Page.GotoAsync(BaseUrl + "/contact/");
        }

        [Test]
        public void ContactElements_AreMandatory()
        {
            //Act
            var allItemsPresent = AreAllItemsMandatoryAsync(Page).Result;

            //Assert
            Assert.That(allItemsPresent, Is.True, "Not all items are mandatory.");
        }

        [Test]
        public async Task ClickSubmitWithEmptyInputFields_ValidationMessageCheck()
        {
            //Act
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var allItemsPresent = AreAllItemsMandatoryAsync(Page).Result;

            //Assert
            Assert.That(allItemsPresent, Is.True, "Not all items are mandatory.");
        }

        private async Task<bool> AreAllItemsMandatoryAsync(IPage page)
        {
            MandatoryContactItems mandatoryItems = new();
            var mandatoryList = new List<string>()
            {
                mandatoryItems.FullName,
                mandatoryItems.WorkEmail,
                mandatoryItems.Message,
                mandatoryItems.EnquiryType
            };

            foreach (var item in mandatoryList)
            {
                await Page.WaitForSelectorAsync($"label:has-text('{item}'):has(span:text('*'))");
                var isElementPresent = await page.Locator($"label:has-text('{item}'):has(span:text('*'))").First.IsVisibleAsync();

                if (!isElementPresent)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
