using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    class ContactFormElement : BaseWebElements
    {
        public IWebElement ContactFormMenu => FindAsyncElement(By.CssSelector("a[href='https://demoqa.com/html-contact-form/']"));
        public IWebElement FirstNameField => FindAsyncElement(By.CssSelector(".firstname"));
        public IWebElement LastNameField => FindAsyncElement(By.Id("lname"));
        public IWebElement CountrySelect => FindAsyncElement(By.Name("country"));
        public IWebElement SubjectField => FindAsyncElement(By.Id("subject"));
        public IWebElement SubmitButton => FindAsyncElement(By.CssSelector("input[value='Submit']"));
        public IWebElement TextResult => FindAsyncElement(By.CssSelector(".page-title"));
    }
}
