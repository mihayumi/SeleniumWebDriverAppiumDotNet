using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    public class ContactFormElement : BaseWebElements
    {
        public IWebElement AcessPageContactForm
        {
            get
            {
                return WebDriver.FindElement(By.CssSelector("a[href='https://demoqa.com/html-contact-form/']"));
            }
        }
        public IWebElement FistNameField
        {
            get
            {
                return WebDriver.FindElement(By.CssSelector(".firstname"));
            }
        }
        public IWebElement LastNameField
        {
            get
            {
                return WebDriver.FindElement(By.Id("lname"));
            }
        }
        public IWebElement CountrySelect
        {
            get
            {
                return WebDriver.FindElement(By.Name("country"));
            }
        }
        public IWebElement SubjectField
        {
            get
            {
                return WebDriver.FindElement(By.Id("subject"));
            }
        }
        public IWebElement SubmitButton
        {
            get
            {
                return WebDriver.FindElement(By.CssSelector("input[value='Submit']"));
            }
        }
    }
}
