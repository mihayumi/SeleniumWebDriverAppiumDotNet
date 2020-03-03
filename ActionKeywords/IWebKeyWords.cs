using OpenQA.Selenium;

namespace SeleniumCoypuAppiumFramework.ActionKeywords
{
    public interface IWebKeyWords
    {
        void GetScreenShot();
        WebKeyWords Hover(IWebElement targetElement);
        bool WaitHasText(IWebElement element, string text);
        bool WaitTitleContains(string text);
    }
}