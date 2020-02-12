using SeleniumCoypuAppiumFramework.ActionKeywords;
using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageValidation;

namespace SeleniumCoypuAppiumFramework.POM.ContactFormPage
{
    class ContactFormValidate : BaseWebValidation<ContactFormElement>
    {
        public ContactFormValidate ShouldBeHaveTitle()
        {
            WebKeywords.Instance.WaitTitleContains("HTML contact form", 5);
            return this;
        }

        public ContactFormValidate ShouldBeHaveMessage()
        {
            WebKeywords.Instance.WaitTitleContains("Page not found – ToolsQA – Demo Website to Practice Automation", 5);
            return this;
        }
    }
}
