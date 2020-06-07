using Applitools.Framework.pageObjectModels;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Applitools.Framework.PageObjectModels
{

    public class PageModelContext
    {
        private readonly IWebDriver _driver;

        public PageModelContext(IWebDriver driver)
        {
            _driver = driver;
        }

        private T GetPage<T>()
        {
            var page = PageFactory.InitElements<T>(_driver);
            return page;
        }

        public HeaderClass HeaderPage
        {
            get { return GetPage<HeaderClass>(); }
        }

        public FooterPage FooterPage
        {
            get { return GetPage<FooterPage>(); }
        }

        public HomePage HomePage
        {
            get { return GetPage<HomePage>(); }
        }

        public ProductPage ProductPage
        {
            get { return GetPage<ProductPage>(); }
        }

    }
}
