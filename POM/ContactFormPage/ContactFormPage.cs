using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Models;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    class ContactFormPage : ContactFormElement
    {
        public static ContactFormPage Instance { get; } = new ContactFormPage();

        public ContactFormPage AcessPageContractForm()
        {
            ContactFormMenu.Click();
            WebKeyWords.Instance.WaitTitleContains("HTML contact form");
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
