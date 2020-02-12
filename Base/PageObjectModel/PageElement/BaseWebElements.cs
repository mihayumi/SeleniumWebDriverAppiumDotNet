using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement
{
    /// <summary>
    ///  This class will create WebDriver for any class extend from it
    ///  WebDriver use for findElement/findElements
    /// </summary>
    public class BaseWebElements
    {
        protected IWebDriver WebDriver;
        public BaseWebElements()
        {
            this.WebDriver = DriverManager.GetDriver<IWebDriver>();
        }
    }
}