using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Applitools.Framework
{
    public static class Extensions
    {

        public static bool Exists(this IWebDriver driver, By by)
        {
            return driver.FindElements(by).Count > 0;
        }

        public static bool Displayed(this IWebDriver driver, By by)
        {
            try
            {
                var element = driver.FindElement(by) ?? null;
                return (element.Displayed && (element.Size.Width > 0 && element.Size.Height > 0));
            }
            catch
            {
                return false;
            }
        }

        public static void WaitForVisible(this IWebDriver driver, By by)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                while (!driver.Displayed(by))
                {
                    stopwatch.Start();
                    if (stopwatch.ElapsedMilliseconds > 2000)
                        break;
                }
                stopwatch.Stop();
            }
            catch { }
        }

        public static void Click(this IWebDriver driver, By by)
        {
            driver.WaitForVisible(by);
            var element = driver.FindElement(by);
            if (driver.Displayed(by))
                element.Click();
        }

        public static void SetValue(this IWebDriver driver, By by, string value)
        {
            driver.WaitForVisible(by);
            var element = driver.FindElement(by);
            //First check that element is able to be interacted with
            if (driver.Displayed(by))
            {
                //Determine if the value to be set is boolean
                if (value.Equals("true") || value.Equals("false"))
                {
                    bool toSelect = bool.Parse(value);
                    //Check if element is selected and shouldn't be, or vice versa, and click if so
                    if ((toSelect & !element.Selected) || (!toSelect & element.Selected))
                        driver.Click(by);
                }
                else
                    element.SendKeys(value);

            }
        }

        //Verify elements retrieved with By locator contains only the strings provided
        public static bool ElementsContainText(this IWebDriver driver, By by, string[] values)
        {
            var elements = driver.FindElements(by);
            List<string> expected = values.ToList();
            List<string> actual = elements.Select(ele => ele.Text).ToList();

            string[] notFound = actual.Except(expected).ToArray();
            if (notFound.Any())
                return false;
            return true;
        }


        //Verify elements retrieved with By locator contains only the value provided
        public static bool ElementAttributeContainsValue(this IWebDriver driver, By by, string attribute, string[] values)
        {
            var elements = driver.FindElements(by);
            List<string> expected = values.ToList();
            List<string> actual = elements.Select(ele => ele.GetAttribute(attribute)).ToList();

            string[] notFound = actual.Except(expected).ToArray();
            if (notFound.Any())
                return false;
            return true;
        }
    }
}