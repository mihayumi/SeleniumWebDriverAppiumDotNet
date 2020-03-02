using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumCoypuAppiumFramework.ActionKeywords;

namespace SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement
{
    public class BaseWebElements
    {
        public IWebElement MappingElement(By element)
        {
            return WebKeyWords.Instance.MappedElement(element);
        }

        public IList<IWebElement> MappingElements(By element)
        {
            return WebKeyWords.Instance.MappedElements(element);
        }
    }
}

