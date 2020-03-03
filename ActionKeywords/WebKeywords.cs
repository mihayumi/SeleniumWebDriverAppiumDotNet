using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.ActionKeywords
{
    public class WebKeyWords : IWebKeyWords
    {
        const int Timeout = 15;
        protected IWebElement Element;

        /// <summary>
        /// Move até um elemento alvo.
        /// </summary>
        /// <param name="targetElement"></param>
        /// <returns></returns>
        public WebKeyWords Hover(IWebElement targetElement)
        {
            try
            {
                Actions action = new Actions(DriverManager.GetDriver<IWebDriver>());
                action.MoveToElement(targetElement)
                      .Build()
                      .Perform();
                return this;
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Get " + e.Message + ", " + targetElement + " is not exists");
            }
        }

        /// <summary>
        /// Espera até que apresente o texto no elemento.
        /// </summary>
        /// <param name="mappingElement"></param>
        public bool WaitHasText(IWebElement element, string text)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(Timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("O Elemento não apresentou a mensagem: " + text + " , " + e.Message + ".");
            }
        }

        /// <summary>
        /// Espera que o título da página contenha o texto especificado.
        /// </summary>
        /// <param name="mappingElement"></param>
        public bool WaitTitleContains(string text)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverManager.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(Timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(text));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("O título da página não contém o texto: " + text + " , " + e.Message + ".");
            }
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
    }
}
