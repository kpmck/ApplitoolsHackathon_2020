using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Applitools.Framework
{
    [TestFixture()]
    public class Reporter
    {

        IList<string> _reports;
        public Reporter(IList<string> reports)
        {
            _reports = reports;
        }

        public bool Report(int task, string testName, By by, string browser, string viewPort, string device, bool result)
        {
            string testResult = result ? "Pass" : "Fail";
            string domId = by.ToString().Replace("By.", string.Empty);

            string ReportContent = string.Format("Task: {0}, Test Name: {1}, Locator {2}, Browser: {3}, Viewport: {4}, " +
       "Device: {5}, Status: {6}", task, testName, domId, browser, viewPort, device, testResult);

            _reports.Add(ReportContent);
            return result;
        }
    }
}
