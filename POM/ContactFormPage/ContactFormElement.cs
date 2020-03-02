using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    class ContactFormElement : BaseWebElements
    {
        public IWebElement ContactFormMenu => MappingElement(By.CssSelector("a[href='https://demoqa.com/html-contact-form/']"));
        public IWebElement FirstNameField => MappingElement(By.CssSelector(".firstname"));
        public IWebElement LastNameField => MappingElement(By.Id("lname"));
        public IWebElement CountrySelect => MappingElement(By.Name("country"));
        public IWebElement SubjectField => MappingElement(By.Id("subject"));
        public IWebElement SubmitButton => MappingElement(By.CssSelector("input[value='Submit']"));
        public IWebElement TextResult => MappingElement(By.CssSelector(".page-title"));
    }
}
