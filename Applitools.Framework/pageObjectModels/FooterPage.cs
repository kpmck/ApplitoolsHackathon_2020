using Applitools.Framework.PageObjectModels;
using OpenQA.Selenium;

namespace Applitools.Framework.pageObjectModels
{
    public class FooterPage : BasePageClass
    {
        private readonly IWebDriver _driver;
        public FooterPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        #region Footer
        public By Footer = By.XPath("//footer");
        public By FooterQuickLinksSection = By.Id("collapse_1");
        public By FooterContactsSection = By.Id("collapse_3");
        public By FooterKeepInTouchSection = By.Id("collapse_4");

        #endregion Footer

    }
}
