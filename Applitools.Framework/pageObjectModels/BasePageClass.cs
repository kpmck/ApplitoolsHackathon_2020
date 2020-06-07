using OpenQA.Selenium;

namespace Applitools.Framework.PageObjectModels
{
    public class BasePageClass
    {
        private readonly IWebDriver _driver;
        public PageModelContext page;
        public BasePageClass(IWebDriver driver)
        {
            _driver = driver;
            page = new PageModelContext(_driver);
        }

        #region Methods

        public bool IsAt(string title)
        {
            if (_driver.Title.Contains(title))
                return true;
            return false;
        }

        #endregion Methods
    }
}