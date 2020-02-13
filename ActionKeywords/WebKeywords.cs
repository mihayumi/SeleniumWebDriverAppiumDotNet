using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.ActionKeywords
{
    public class WebKeywords
    {
        public static WebKeywords Instance { get; } = new WebKeywords();
        const int Timeout = 5;

        /// <summary>
        /// Navega em uma url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public WebKeywords Navigate(string url)
        {
            DriverManager.GetDriver<IWebDriver>().Navigate().GoToUrl(url);
            return this;
        }

        /// <summary>
        /// Clica no elemento.
        /// </summary>
        /// <param name="mappingElement"></param>
        /// <returns></returns>
        public WebKeywords Click(By mappingElement)
        {
            try
            {
                MappedElement(mappingElement).Click();
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Get " + e.Message + ", " + mappingElement + " is not exists");
            }
            return this;
        }

        /// <summary>
        /// Digita um valor em um elemento.
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="mappingElement"></param>
        /// <returns></returns>
        public WebKeywords SendKeys(string valor, By mappingElement)
        {
            try
            {
                MappedElement(mappingElement).SendKeys(valor);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Get " + e.Message + ", " + mappingElement + " is not exists");
            }
            return this;
        }

        /// <summary>
        /// Limpa e digita um valor no elemento.
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="mappingElement"></param>
        /// <returns></returns>
        public WebKeywords ClearAndSendKeys(string valor, By mappingElement)
        {
            try
            {
                MappedElement(mappingElement).Clear();
                MappedElement(mappingElement).SendKeys(valor);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Element " + mappingElement + " is not enable for set text " + e.Message + ".");
            }
            return this;
        }

        /// <summary>
        /// Retorna o texto do elemento.
        /// </summary>
        /// <param name="mappingElement"></param>
        /// <returns></returns>
        public WebKeywords GetText(By mappingElement)
        {
            try
            {
                var result = MappedElement(mappingElement).Text;
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Element " + mappingElement + " is not enable for get text " + e.Message + ".");
            }
            return this;
        }

        /// <summary>
        /// This method is use for
        /// select option from dropdown list or combobox
        /// </summary>
        /// <param name="element"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        public void Select(IWebElement element, SelectType type, string options)
        {
            SelectElement select = new SelectElement(element);
            switch (type)
            {
                case SelectType.SelectByIndex:
                    try
                    {
                        select.SelectByIndex(Int32.Parse(options));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetBaseException().ToString());
                        throw new ArgumentException("Please input numberic on selectOption for SelectType.SelectByIndex");
                    }
                    break;
                case SelectType.SelectByText:
                    select.SelectByText(options);
                    break;
                case SelectType.SelectByValue:
                    select.SelectByValue(options);
                    break;
                default:
                    throw new Exception("Get error in using Selected");
            }
        }

        /// <summary>
        /// Espera até que o elemento fique visível e mapeia.
        /// </summary>
        /// <param name="mappingElement"></param>
        public IWebElement MappedElement(By mappingElement)
        {
            WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(mappingElement));
            return DriverManager.GetDriver<IWebDriver>().FindElement(mappingElement);
        }

        /// <summary>
        /// This method use for 
        /// wait title of page contain string user want
        /// </summary>
        /// <param name="title"></param>
        /// <param name="timeOut"></param>
        public void WaitTitleContains(string title)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(Timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Get " + e.Message + ", [" + title + "] is not displayed in WebPage title [" + DriverManager.GetDriver<IWebDriver>().Title + "]");
            }
        }

        /// <summary>
        /// This method use for 
        /// get attribute of element in DOM
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public string GetAttribute(IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }

        /// <summary>
        /// This method use for Driver title of page
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return DriverManager.GetDriver<IWebDriver>().Title;
        }

        /// <summary>
        /// This method is use for
        /// return value of css
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetCssValue(IWebElement element, string value)
        {
            return element.GetCssValue(value);
        }

        /// <summary>
        /// Limpa o elemento.
        /// </summary>
        /// <param name="element"></param>
        public WebKeywords Clear(By mappingElement)
        {
            MappedElement(mappingElement).Clear();
            return this;
        }

        /// <summary>
        /// Tira um print e salva na pasta Report.
        /// </summary>
        public void GetScreenShot()
        {
            ITakesScreenshot camera = DriverManager.GetDriver<IWebDriver>() as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();

            var resultId = TestContext.CurrentContext.Test.ID;

            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string artifactDirectory = path + "Report\\";
            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);

            foto.SaveAsFile(artifactDirectory + resultId + ".png", ScreenshotImageFormat.Png);

            TestContext.AddTestAttachment(artifactDirectory + resultId + ".png");
        }

        /// <summary>
        /// This method is use for
        /// return source code of current page
        /// </summary>
        /// <returns></returns>
        public string GetPageSource()
        {
            return DriverManager.GetDriver<IWebDriver>().PageSource;
        }

        /// <summary>
        /// This method use for 
        /// wait page load completed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="time"></param>
        public void WaitForPageToLoad(int time)
        {
            TimeSpan timeout = new TimeSpan(0, 0, time);
            WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), timeout);
            IJavaScriptExecutor javascript = DriverManager.GetDriver<IWebDriver>() as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");
            wait.Until((d) =>
            {
                try
                {
                    return javascript.ExecuteScript("return document.readyState").Equals("complete");
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to Driver browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        /// <summary>
        /// This method use for
        /// set attribute of element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        public void SetAttribute(IWebElement element, string attributeName, string value)
        {
            IWrapsDriver wrappedElement = element as IWrapsDriver;
            if (wrappedElement == null)
                throw new ArgumentException("element", "Element must wrap a web driver");

            IWebDriver driver = wrappedElement.WrappedDriver;
            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
            javascript.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, attributeName, value);
        }
    }
}
/// <summary>
/// This is enum for select option in keywords select
/// </summary>
public enum SelectType
{
    SelectByIndex,
    SelectByText,
    SelectByValue,
}

