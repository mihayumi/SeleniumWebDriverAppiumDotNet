using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumCoypuAppiumFramework.Base.Driver.Core;

namespace SeleniumCoypuAppiumFramework.ActionKeywords
{
    public class MobileKeywords
    {
        public static MobileKeywords Instance { get; } = new MobileKeywords();

        public AppiumWebElement FindElementByAndroidUIAutomator(string value)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            return _AndroidDriver.FindElementByAndroidUIAutomator(value);
        }

        public string GetTextToast()
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            return _AndroidDriver.FindElementByXPath($"//android.widget.Toast[1]").Text;
        }

        public bool ShouldSeeText(string resultExpected)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            return _AndroidDriver.FindElementByXPath($"//*[contains(@text,'{resultExpected}')]").Equals(resultExpected);
        }

        public void PressTab(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
                _AndroidDriver.PressKeyCode(AndroidKeyCode.Keycode_TAB);
            }
        }

        public void PressBack(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
                _AndroidDriver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            }
        }

        public void PressEnter(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
                _AndroidDriver.PressKeyCode(AndroidKeyCode.Keycode_ENTER);
            }
        }

        public void PressAppSwitch()
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            _AndroidDriver.PressKeyCode(AndroidKeyCode.Keycode_APP_SWITCH);
        }

        public bool VerifyElementByIdExists(string elementid)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            return _AndroidDriver.FindElementsById(elementid).Count > 0;
        }

        public void ScrollIntoViewTextContainsAndClick(string visibleText)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            String text = visibleText;
            _AndroidDriver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + text + "\").instance(0))").Click();
        }

        public void ScrollIndoViewTextMachesAndClick(string visibleText)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            String text = visibleText;
            _AndroidDriver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textMatches(\"" + text + "\").instance(0))").Click();
        }

        public void ClickElementByText(string text)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            _AndroidDriver.FindElementByXPath($"//*[contains(@text,'{text}')]").Click();
        }

        public void PrintMobileErro(string nomePrint)
        {
            var _AndroidDriver = DriverManager.GetDriver<AndroidDriver<AppiumWebElement>>();
            ITakesScreenshot camera = _AndroidDriver as ITakesScreenshot;
            Screenshot print = camera.GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string path = path1 + $"Report\\{nomePrint}.png";
            print.SaveAsFile(path);
        }
    }
}
