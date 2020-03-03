using SeleniumCoypuAppiumFramework.Models;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    interface IContactFormPage
    {
        ContactFormPage AcessPageContractForm();
        ContactFormPage FillinFields(ContactFormModel contactForm);
        ContactFormPage ClickSubmit();
        string GetTextResult();
    }
}
