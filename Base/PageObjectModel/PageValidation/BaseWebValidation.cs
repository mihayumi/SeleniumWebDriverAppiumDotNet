using SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement;

namespace SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageValidation
/// <summary>
/// This class will crate Page Object-initinal element for any validation method 
/// extend from this class
/// </summary>
/// <typeparam name="WebElement"></typeparam>
{
    public class BaseWebValidation<WebElement>
        where WebElement : BaseWebElements, new()
    {
        protected WebElement Element
        {
            get
            {
                return new WebElement();
            }
        }
    }
}