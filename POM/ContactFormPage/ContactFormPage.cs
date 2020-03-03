using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Models;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    class ContactFormPage : ContactFormElement, IContactFormPage
    {
        private readonly IWebKeyWords _webKeyWords;
        public ContactFormPage(IWebKeyWords webKeyWords)
        {
            _webKeyWords = webKeyWords;
        }

        public ContactFormPage AcessPageContractForm()
        {
            ContactFormMenu.Click();
            _webKeyWords.WaitTitleContains("HTML contact form");
            return this;
        }

        public ContactFormPage FillinFields(ContactFormModel contactForm)
        {
            FirstNameField.SendKeys(contactForm.FirstName);
            LastNameField.SendKeys(contactForm.LastName);
            CountrySelect.SendKeys(contactForm.Country);
            SubjectField.SendKeys(contactForm.Subject);
            return this;
        }

        public ContactFormPage ClickSubmit()
        {
            SubmitButton.Click();
            return this;
        }

        public string GetTextResult()
        {
            return TextResult.Text;
        }
    }
}
