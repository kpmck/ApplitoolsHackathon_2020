using Applitools.Framework.PageObjectModels;
using OpenQA.Selenium;

namespace Applitools.Framework.pageObjectModels
{
    public class HeaderClass : BasePageClass
    {
        private readonly IWebDriver _driver;
        public HeaderClass(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Top Menu Items

        public By AccountIcon = By.CssSelector(".dropdown.dropdown-access");

        public By FavoritesIcon = By.CssSelector(".wishlist");

        public By BagIcon = By.CssSelector(".dropdown.dropdown-cart");

        public By BagCount = By.Id("STRONG____50");

        public By MainMenu = By.CssSelector(".main-menu");

        public IWebElement MenuCategory(string category)
        {
            return _driver.FindElement(MainMenu).FindElement(By.PartialLinkText(category));
        }

        #endregion Top Menu Items

        #region Search Items

        public By SearchField = By.Id("INPUTtext____42");

        public By SearchIcon = By.CssSelector(".header-icon_search_custom");

        public By SearchIconMobile = By.CssSelector(".btn_search_mob");

        public By Logo = By.Id("IMG____9");

        #endregion Search Items

    }
}

