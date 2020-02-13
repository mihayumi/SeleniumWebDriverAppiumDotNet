using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Models;

namespace SeleniumCoypuAppiumFramework.POM
{
    class ContactFormPage
    {
        public static ContactFormPage Instance { get; } = new ContactFormPage();

        #region
        By ContactFormMenu = By.CssSelector("a[href='https://demoqa.com/html-contact-form/']");
        By FirstNameField = By.CssSelector(".firstname");
        By LastNameField = By.Id("lname");
        By CountrySelect = By.Name("country");
        By SubjectField = By.Id("subject");
        By SubmitButton = By.CssSelector("input[value='Submit']");
        By TextResult = By.CssSelector(".page-title");
        #endregion

        public ContactFormPage AcessPageContractForm()
        {
            WebKeywords.Instance.Navigate("https://demoqa.com")
                                .Click(ContactFormMenu)
                                .WaitTitleContains("HTML contact form");
            return this;
        }

        public ContactFormPage FillinFields(ContactFormModel contactForm)
        {
            WebKeywords.Instance.SendKeys(contactForm.FirstName, FirstNameField)
                                .SendKeys(contactForm.LastName, LastNameField)
                                .SendKeys(contactForm.Country, CountrySelect)
                                .SendKeys(contactForm.Subject, SubjectField);
            return this;
        }

        public ContactFormPage ClickSubmit()
        {
            WebKeywords.Instance.Click(SubmitButton);
            return this;
        }

        public string GetTextResult()
        {
            var result = WebKeywords.Instance.GetText(TextResult);
            return result;
        }
    }
}
