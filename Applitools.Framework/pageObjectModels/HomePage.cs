using OpenQA.Selenium;

namespace Applitools.Framework.PageObjectModels
{
    public class HomePage : BasePageClass
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Sidebar Filter Items

        public By SidebarGridFilter = By.Id("sidebar_filters");

        public By SidebarGridFilterFilterButton = By.Id("filterBtn");

        public By SidebarGridFilterResetButton = By.Id("resetBtn");

        public By SidebarGridFilterOption(string option)
        {
            return By.XPath($"//*[@id='sidebar_filters']//*[contains(text(),'{option}')]//span");
        }

        #endregion Sidebar Filter Items

        #region Product Grid

        public By ProductGrid = By.Id("product_grid");

        public By ProductGridFilterIcon = By.Id("ti-filter");

        public By ProductGridFilterLabel = By.XPath("//span[text()='Filters']");

        public By ProductGridFilterGridViewIcon = By.CssSelector(".ti-view-grid");

        public By ProductGridFilterListViewIcon = By.CssSelector(".ti-view-list");

        public By ProductCardFavoriteIcon = By.CssSelector(".ti-heart");

        public By ProductCardShuffleIcon = By.CssSelector(".ti-control-shuffle");

        public By ProductCardShoppingCartIcon = By.CssSelector(".ti-shopping-cart");

        public By ProductGridProductCards = By.CssSelector(".grid_item");

        public By ProductGridProductCard(string productName) => By.XPath($"//h3[contains(text(),'{productName}')]");

        public By ProductGridProductCardName = By.CssSelector(".grid_item h3");

        public By ProductGridCardImage = By.CssSelector(".img-fluid ");

        #endregion Product Grid

        public bool IsAt()
        {
            return IsAt("Applitools UltraFastGrid | Cross Browser Testing Demo App");
        }
    }
}
