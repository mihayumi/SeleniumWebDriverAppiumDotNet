using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.Base.PageObjectModel.PageElement
{
    public class BaseWebElements 
    {
        public IList<IWebElement> FindAsyncElements(By mappingElements)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(15));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(mappingElements));
                return DriverManager.GetDriver<IWebDriver>().FindElements(mappingElements);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Não foi possível mapear os elementos: " + mappingElements + " , " + e.Message + ".");
            }
        }

        public IWebElement FindAsyncElement(By mappingElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(15));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(mappingElement));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(mappingElement));
                IWebElement Element = DriverManager.GetDriver<IWebDriver>().FindElement(mappingElement);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Element));
                return DriverManager.GetDriver<IWebDriver>().FindElement(mappingElement);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Não foi possível mapear o elemento: " + mappingElement + " , " + e.Message + ".");
            }
        }
    }
}

