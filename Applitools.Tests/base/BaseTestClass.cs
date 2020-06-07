using Applitools.Framework;
using Applitools.Framework.Driver;
using Applitools.Framework.Data;
using Applitools.Framework.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Applitools.Tests
{
    public class BaseTestClass
    {
        protected IWebDriver _driver;
        internal PageModelContext page;
        internal static Reporter reporter;
        internal static List<string> reports;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            reports = new List<string>();
            reporter = new Reporter(reports);
        }

        [SetUp]
        public void SetUp()
        {
            var testName = TestContext.CurrentContext.Test.ClassName;
            string url = testName.ToLower().Contains("v1") ? Constants.url_v1 : Constants.url_v2;

            _driver = DriverFactory.getInstance().getDriver();
            _driver.Navigate().GoToUrl(url);
            page = new PageModelContext(_driver);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //Do not write to report if running the modern tests
            var testName = TestContext.CurrentContext.Test.ClassName.ToLower();
            if (testName.Contains("modern"))
                return;

            string reportFile = testName.Contains("v1") ? Constants.reportFile_v1 : Constants.reportFile_v2;

            if (!string.IsNullOrEmpty(reportFile))
            {
                using (StreamWriter fs = new StreamWriter(reportFile, true))
                {
                    foreach (string report in reports)
                        fs.WriteLine(report);
                }
            }
        }

    }
}
