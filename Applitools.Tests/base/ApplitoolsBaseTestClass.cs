using Applitools.Selenium;
using Applitools.VisualGrid;
using OpenQA.Selenium;
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;

namespace Applitools.Tests.Modern
{
    public class ApplitoolsBaseTestClass : BaseTestClass
    {
        internal void SetUp(Eyes eyes)
        {
            Selenium.Configuration config = new Selenium.Configuration();

            //Uncomment and add your Applitools key here if you prefer 
            //to hard-code it vs adding it to your environment variables.
            //config.SetApiKey("");

            config.SetBatch(new BatchInfo("UFG Hackathon"));

            config.AddBrowser(1200, 700, BrowserType.CHROME);
            config.AddBrowser(1200, 700, BrowserType.FIREFOX);
            config.AddBrowser(1200, 700, BrowserType.EDGE_CHROMIUM);
            config.AddBrowser(768, 700, BrowserType.CHROME);
            config.AddBrowser(768, 700, BrowserType.FIREFOX);
            config.AddBrowser(768, 700, BrowserType.EDGE_CHROMIUM);
            config.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);

            // Set the configuration object to eyes
            eyes.SetConfiguration(config);
        }

        internal void TearDown(IWebDriver webDriver, VisualGridRunner runner)
        {
            TestResultsSummary allTestResults = runner.GetAllTestResults();
        }
    }
}