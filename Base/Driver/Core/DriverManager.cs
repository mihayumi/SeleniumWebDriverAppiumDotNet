using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using SeleniumCoypuAppiumFramework.Base.Exception;

namespace SeleniumCoypuAppiumFramework.Base.Driver.Core
{
    public static class DriverManager
    {
        private static ThreadLocal<object> _driverStored = new ThreadLocal<object>();
        /// <summary>
        /// This method return driver base on generic TypeofDriver
        /// Ex: GetDriver<IWebDriver> will return IWebDriver
        /// GetDriver<PhantomJSDriver> will return PhantomJSDriver
        /// </summary>        
        public static DriverType GetDriver<DriverType>()
        {
            return (DriverType)DriverStored;
        }
        /// <summary>
        /// This is use for stored driver 
        /// when running in paralell in single machine
        /// </summary>
        private static object DriverStored
        {
            get
            {
                if (_driverStored == null || _driverStored.Value == null)
                    throw new StepErrorException("Please call method 'StartDriver' before can get Driver");
                return _driverStored.Value;
            }
            set
            {
                _driverStored.Value = value;
            }
        }
        /// <summary>
        /// This method is use for instance driver
        /// </summary>
        /// <param name="factoryType"></param>
        /// <param name="type"></param>
        /// <param name="configuaration"></param>     
        public static void StartDriverAndroid()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("deviceName", "Android");
            options.AddAdditionalCapability("deviceName", "Android");
            options.AddAdditionalCapability("appPackage", "hbsis.wms.ambev.launcher");
            options.AddAdditionalCapability("appActivity", "hbsis.wms.ambev.launcher.login.LoginActivity");
            options.AddAdditionalCapability("autoGrantPermissions", "true");
            options.AddAdditionalCapability("unicodeKeyboard", "false");
            options.AddAdditionalCapability("resetKeyboard", "true");
            options.AddAdditionalCapability("platformName", "Android");
            options.AddAdditionalCapability("noReset", "true");
            options.AddAdditionalCapability("ignoreUnimportantViews", "true");
            options.AddAdditionalCapability("disableAndroidWatchers", "true");
            options.AddAdditionalCapability("skipDeviceInitialization", "true");
            options.AddAdditionalCapability("skipDeviceInitialization", "true");
            options.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiAutomator2");
            options.AddAdditionalCapability(MobileCapabilityType.FullReset, false);
            options.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            options.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, "4000");

            AndroidDriver<AppiumWebElement> driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            DriverStored = driver;
        }

        public static void StartDriverChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.LeaveBrowserRunning = true;
            options.AddArgument("--test-type");
            options.AddArgument("--headless");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-notifications");
            options.AddArgument("disable-gpu");
            ////chromeOptions.AddAdditionalCapability(CapabilityType.Platform, "Linux");
            ////chromeOptions.AddAdditionalCapability(CapabilityType.Version, "78.0.3904.70");
            options.AddUserProfilePreference("intl.accept_languages", "pt");
            options.AddUserProfilePreference("disable-popup-blocking", "true");

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            DriverStored = driver;
        }
        /// <summary>
        /// This method is use for close and destroy driver
        /// </summary>
        public static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)DriverStored;
            driver.Quit();
            driver.Dispose();
            if (DriverStored != null)
                DriverStored = null;
        }
    }
}
