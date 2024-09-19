using Microsoft.Playwright;
using VeriskTestProject.Core;
using VeriskTestProject.Core.Entities;

namespace VeriskTestProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public sealed class ContactPageTests : BaseTest
    {
        private List<string> _mandatoryList;

        [OneTimeSetUp]
        public async Task UrlSetupAsync()
        {
            await Page.GotoAsync(BaseUrl + "/contact/");

            MandatoryContactItems mandatoryItems = new();
            _mandatoryList =
            [
                mandatoryItems.FullName,
                mandatoryItems.WorkEmail,
                mandatoryItems.Message,
                mandatoryItems.EnquiryType
            ];
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
        public async Task ClickSubmitWithEmptyInputFields_DefaultValidationMessageCheck()
        {
            //Act
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var allItemsPresent = ValidationErrorOnMandatoryItemsAsync(Page).Result;

            //Assert
            Assert.That(allItemsPresent, Is.True, "Not all mandatory items have validation.");
        }

        [Test]
        public async Task EnterInvalidEmail_EmailValidationMessageCheck()
        {
            //Arrange
            string email = "invalidEmail";
            string inputName = "input[name='00ae2855-e87d-40b8-fbaa-a8ae183c7350']";
            string emailValidationMessage = "Please provide a valid email address";

            //Act
            await Page.WaitForSelectorAsync(inputName);
            await Page.Locator(inputName).ClickAsync();
            await Page.Locator(inputName).FillAsync(email);
            await Page.WaitForSelectorAsync($"span:has-text('{emailValidationMessage}')");

            //var emailValidationMessage = await Page.GetByLabel("Please provide a valid email address");

            //Assert
            //Assert.That(emailValidationMessage, "sda");
        }

        private async Task<bool> AreAllItemsMandatoryAsync(IPage page)
        {
            foreach (var item in _mandatoryList)
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

        private async Task<bool> ValidationErrorOnMandatoryItemsAsync(IPage page)
        {
            foreach (var item in _mandatoryList)
            {
                await Page.WaitForSelectorAsync($"label:has-text('{item}'):has(span:text('*'))");
                var labelElement = page.Locator($"label:has-text('{item}'):has(span:text('*'))").First;
                var validationSpan = await labelElement.Locator($"~ div:has(span:text('Please provide a value for {item}'))").First.IsVisibleAsync();

                if (!validationSpan)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
