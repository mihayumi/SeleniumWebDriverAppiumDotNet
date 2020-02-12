using System.Configuration;
using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageAction;
using SeleniumCoypuAppiumFramework.Models;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    class ContactFormPage : BasePageWeb<ContactFormPage, ContactFormElement, ContactFormValidate>
    {
        public ContactFormPage AcessPageContractForm()
        {
            WebKeywords.Instance.Navigate("https://demoqa.com");
            Element.AcessPageContactForm.Click();
            return this;
        }

        public ContactFormPage FillinFields(ContactFormModel contactForm)
        {
            Element.FistNameField.SendKeys(contactForm.FirstName);
            Element.LastNameField.SendKeys(contactForm.LastName);
            Element.CountrySelect.SendKeys(contactForm.Country);
            Element.SubjectField.SendKeys(contactForm.Subject);
            return this;
        }

        public ContactFormPage ClickSubmit()
        {
            Element.SubmitButton.Click();
            return this;
        }
    }
}
