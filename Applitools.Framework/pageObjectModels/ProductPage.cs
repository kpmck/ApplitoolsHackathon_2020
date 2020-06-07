using Applitools.Framework.PageObjectModels;
using OpenQA.Selenium;

namespace Applitools.Framework.pageObjectModels
{
    public class ProductPage : BasePageClass
    {
        internal readonly IWebDriver _driver;
        public ProductPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public By ProductName = By.Id("shoe_name");

        public By ProductImage = By.Id("shoe_img");

        public By ProductRating = By.CssSelector(".rating");

        public By ProductReview = By.Id("P____83");

        public By ProductSku = By.Id("SMALL____84");

        public By ProductSizeLabel = By.Id("STRONG____90");

        public By ProductSizeDropdown = By.CssSelector(".nice-select.wide");

        public By ProductSizeValue = By.CssSelector(".current");

        public By ProductQuantityLabel = By.Id("STRONG____100");

        public By ProductQuantity = By.CssSelector(".numbers-row");

        public By ProductQuantityValue = By.Id("quantity_1");

        public By AddToBagButton = By.Id("A__btn__114");

        public By OldPrice = By.Id("old_price");

        public By NewPrice = By.Id("new_price");

        public By DiscountTag = By.Id("discount");

        public bool IsAt()
        {
            return IsAt("Applitools UltraFastGrid | Cross Browser Testing Demo App");
        }
    }
}
