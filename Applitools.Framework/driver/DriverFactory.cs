using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Firefox;
using System;
using System.Drawing;
using System.IO;

namespace Applitools.Framework.Driver
{
    public class DriverFactory
    {

    //private static string driversPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
      private static string driversPath = String.Concat(Environment.CurrentDirectory, "\\drivers");

        [ThreadStatic]
        private static Browser _browser;

        [ThreadStatic]
        private static Device _device;

        private DriverFactory()
        {
        }

        public static void SetBrowser(Browser browser, Device device = Device.Desktop)
        {
            _browser = browser;
            _device = device;
        }

        private static DriverFactory instance = new DriverFactory();

        public static DriverFactory getInstance()
        {
            return instance;
        }


        public IWebDriver getDriver()
        {
            return WebDriver(_browser, _device);
        }

        public static IWebDriver WebDriver(Browser type, Device device)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case Browser.Edge:
                    driver = EdgeDriver(device);
                    break;
                case Browser.Firefox:
                    driver = FirefoxDriver(device);
                    break;
                case Browser.Chrome:
                    driver = ChromeDriver(device);
                    break;
                case Browser.Phone:
                    driver = PhoneDriver();
                    break;
            }
            return driver;
        }

        private static IWebDriver PhoneDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.EnableMobileEmulation("iPhone X");
            return new ChromeDriver(driversPath, options);
        }

        private static ChromeDriver ChromeDriver(Device device)
        {
            ChromeOptions options = new ChromeOptions();
            switch (device)
            {
                case Device.Desktop:
                    options.AddArgument("--window-size=1200,700");
                    break;
                case Device.Tablet:
                    options.EnableMobileEmulation("iPad");
                    options.AddArgument("--window-size=768,700");
                    break;
            }
            return new ChromeDriver(driversPath, options);
        }

        private static FirefoxDriver FirefoxDriver(Device device)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driversPath, "geckodriver.exe");
            FirefoxOptions options = new FirefoxOptions();
            switch (device)
            {
                case Device.Desktop:
                    options.AddArgument("--width=1200");
                    options.AddArgument("--height=700");
                    break;
                case Device.Tablet:
                    options.AddArgument("--width=768");
                    options.AddArgument("--height=700");
                    break;
            }
            return new FirefoxDriver(service, options);
        }


        private static EdgeDriver EdgeDriver(Device device)
        {
            EdgeDriverService service = EdgeDriverService.CreateDefaultService(driversPath, "msedgedriver.exe");
            EdgeOptions options = new EdgeOptions();
            EdgeDriver _driver = null;
            switch (device)
            {
                case Device.Desktop:
                    _driver = new EdgeDriver(service);
                    _driver.Manage().Window.Size = new Size(1200, 700);
                    break;
                case Device.Tablet:
                    options.UseChromium = true;
                    options.EnableMobileEmulation("iPad");
                    options.AddArgument("--window-size=768,700");
                    _driver = new EdgeDriver(driversPath, options);
                    break;
            }
            return _driver;
        }
    }
}
