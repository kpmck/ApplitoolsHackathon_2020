using Applitools.Framework.Driver;
using Applitools.Framework;
using NUnit.Framework;

namespace Applitools.Tests.Traditional
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(Browser.Chrome, Device.Desktop)]
    [TestFixture(Browser.Firefox, Device.Desktop)]
    [TestFixture(Browser.Edge, Device.Desktop)]
    [Category("traditional1")]
    public class Traditional_Desktop_V1 : BaseTestClass
    {
        private readonly Browser _browser;
        private readonly Device _device;
        private string resolution = "1200x700";
        public Traditional_Desktop_V1(Browser browser, Device device)
        {
            _browser = browser;
            _device = device;
            DriverFactory.SetBrowser(browser, device);
        }

        [Test]
        public void Task1()
        {
            Assert.Multiple(() =>
            {
                //Verify Main Header 
                Assert.IsTrue(page.HomePage.IsAt());
                Assert.IsTrue(reporter.Report(1, "Logo is Visible", page.HeaderPage.Logo, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.Logo)));
                Assert.IsTrue(reporter.Report(1, "Correct Logo Image is Shown", page.HeaderPage.Logo, _browser.ToString(), resolution, _device.ToString(), _driver.ElementAttributeContainsValue(page.HeaderPage.Logo, "src", new string[] { "https://demo.applitools.com/grid/img/logo.svg" })));
                Assert.IsTrue(reporter.Report(1, "Account Icon is Visible", page.HeaderPage.AccountIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.AccountIcon)));
                Assert.IsTrue(reporter.Report(1, "Favorites Icon is Visible", page.HeaderPage.FavoritesIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.FavoritesIcon)));
                Assert.IsTrue(reporter.Report(1, "Bag Icon is Visible", page.HeaderPage.BagIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.BagIcon)));
                Assert.IsTrue(reporter.Report(1, "Bag Count is Visible", page.HeaderPage.BagCount, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.BagCount)));
                Assert.IsTrue(reporter.Report(1, "Main Menu is Visible", page.HeaderPage.MainMenu, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.MainMenu)));

                //Verify Search Bar
                Assert.IsTrue(reporter.Report(1, "Search Field is Visible", page.HeaderPage.SearchField, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.SearchField)));
                Assert.IsTrue(reporter.Report(1, "Search Field Placeholder Contains Text 'Search over 10,000 shoes!'", page.HeaderPage.SearchField, _browser.ToString(), resolution, _device.ToString(), _driver.ElementAttributeContainsValue(page.HeaderPage.SearchField, "placeholder", new string[] { "Search over 10,000 shoes!" })));
                Assert.IsTrue(reporter.Report(1, "Search Icon Desktop is Visible", page.HeaderPage.SearchIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.SearchIcon)));
                Assert.IsTrue(reporter.Report(1, "Search Icon Mobile is NOT Visible", page.HeaderPage.SearchIconMobile, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HeaderPage.SearchIconMobile)));

                //Verify Grid Filter
                Assert.IsTrue(reporter.Report(1, "Left Grid Filter Section is Visible", page.HomePage.SidebarGridFilter, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HomePage.SidebarGridFilter)));

                //Verify Product Grid
                Assert.IsTrue(reporter.Report(1, "Product Grid is Visible", page.HomePage.ProductGrid, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HomePage.ProductGrid)));
                Assert.IsTrue(reporter.Report(1, "Product Grid Filter Icon is NOT Visible", page.HomePage.ProductGridFilterIcon, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HomePage.ProductGridFilterIcon)));
                Assert.IsTrue(reporter.Report(1, "Product Grid Filter Label is NOT Visible", page.HomePage.ProductGridFilterLabel, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HomePage.ProductGridFilterLabel)));
                Assert.IsTrue(reporter.Report(1, "Product Grid Filter>Grid View Icon is Visible", page.HomePage.ProductGridFilterGridViewIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HomePage.ProductGridFilterGridViewIcon)));
                Assert.IsTrue(reporter.Report(1, "Product Grid Filter>List View Icon is Visible", page.HomePage.ProductGridFilterListViewIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HomePage.ProductGridFilterListViewIcon)));

                //Verify Product Grid Card
                Assert.IsTrue(reporter.Report(1, "Product Grid Product Card is Visible", page.HomePage.ProductGridProductCards, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HomePage.ProductGridProductCards)));
                Assert.IsTrue(reporter.Report(1, "Product Grid Product Card Image is Visible", page.HomePage.ProductGridCardImage, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HomePage.ProductGridCardImage)));
                Assert.IsTrue(reporter.Report(1, "Product Card Favorite Icon is NOT Visible", page.HomePage.ProductCardFavoriteIcon, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HomePage.ProductCardFavoriteIcon)));
                Assert.IsTrue(reporter.Report(1, "Product Card Shuffle Icon is NOT Visible", page.HomePage.ProductCardShuffleIcon, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HomePage.ProductCardShuffleIcon)));
                Assert.IsTrue(reporter.Report(1, "Product Card Shopping Cart Icon is NOT Visible", page.HomePage.ProductCardShoppingCartIcon, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HomePage.ProductCardShoppingCartIcon)));

                //Verify Footer
                Assert.IsTrue(reporter.Report(1, "Footer is Visible", page.FooterPage.Footer, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.Footer)));
                Assert.IsTrue(reporter.Report(1, "Footer Quick Links Section is Visible", page.FooterPage.FooterQuickLinksSection, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.FooterQuickLinksSection)));
                Assert.IsTrue(reporter.Report(1, "Footer Contacts Section is Visible", page.FooterPage.FooterContactsSection, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.FooterContactsSection)));
                Assert.IsTrue(reporter.Report(1, "Footer Keep In Touch Section is Visible", page.FooterPage.FooterKeepInTouchSection, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.FooterKeepInTouchSection)));
            });
        }

        [Test]
        public void Task2()
        {
          Assert.Multiple(() =>
          {
            Assert.IsTrue(page.HomePage.IsAt());
            _driver.Click(page.HomePage.ProductGridFilterIcon);
            _driver.SetValue(page.HomePage.SidebarGridFilterOption("Black"), "true");
            _driver.Click(page.HomePage.SidebarGridFilterFilterButton);
            Assert.IsTrue(reporter.Report(2, "Filter for Black Items", page.HomePage.ProductGridProductCardName, _browser.ToString(), resolution, _device.ToString(), _driver.ElementsContainText(page.HomePage.ProductGridProductCardName, new string[] { "Appli Air x Night", "Appli Air 720" })));
            Assert.IsTrue(reporter.Report(2, "Product Grid Product Card Images Are Displayed", page.HomePage.ProductGridCardImage, _browser.ToString(), resolution, _device.ToString(), _driver.ElementAttributeContainsValue(page.HomePage.ProductGridCardImage, "src", new string[] { "https://demo.applitools.com/grid/img/products/shoes/1.jpg", "https://demo.applitools.com/grid/img/products/shoes/8.jpg" })));
          });
        }

        [Test]
        public void Task3()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(page.HomePage.IsAt());
                _driver.Click(page.HomePage.ProductGridFilterIcon);
                _driver.SetValue(page.HomePage.SidebarGridFilterOption("Black"), "true");
                _driver.Click(page.HomePage.SidebarGridFilterFilterButton);
                _driver.Click(page.HomePage.ProductGridProductCard("Appli Air x Night"));
                Assert.IsTrue(page.ProductPage.IsAt());

                //Verify Main Header 
                Assert.IsTrue(reporter.Report(3, "Account Icon is Visible", page.HeaderPage.AccountIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.AccountIcon)));
                Assert.IsTrue(reporter.Report(3, "Favorites Icon is Visible", page.HeaderPage.FavoritesIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.FavoritesIcon)));
                Assert.IsTrue(reporter.Report(3, "Bag Icon is Visible", page.HeaderPage.BagIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.BagIcon)));
                Assert.IsTrue(reporter.Report(3, "Bag Count is Visible", page.HeaderPage.BagCount, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.BagCount)));
                Assert.IsTrue(reporter.Report(3, "Main Menu is Visible", page.HeaderPage.MainMenu, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.MainMenu)));

                //Verify Search Bar
                Assert.IsTrue(reporter.Report(3, "Search Field is Visible", page.HeaderPage.SearchField, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.SearchField)));
                Assert.IsTrue(reporter.Report(3, "Search Field Placeholder Contains Text 'Search over 10,000 shoes!'", page.HeaderPage.SearchField, _browser.ToString(), resolution, _device.ToString(), _driver.ElementAttributeContainsValue(page.HeaderPage.SearchField, "placeholder", new string[] { "Search over 10,000 shoes!" })));
                Assert.IsTrue(reporter.Report(3, "Search Icon Desktop is Visible", page.HeaderPage.SearchIcon, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.HeaderPage.SearchIcon)));
                Assert.IsTrue(reporter.Report(3, "Search Icon Mobile is NOT Visible", page.HeaderPage.SearchIconMobile, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HeaderPage.SearchIconMobile)));

                //Verify Grid Filter Not Shown
                Assert.IsTrue(reporter.Report(3, "Left Grid Filter Section is NOT Visible", page.HomePage.SidebarGridFilter, _browser.ToString(), resolution, _device.ToString(), !_driver.Displayed(page.HomePage.SidebarGridFilter)));

                //Verify Product Page
                Assert.IsTrue(reporter.Report(3, "Add to Bag Button is Visible", page.ProductPage.AddToBagButton, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.AddToBagButton)));
                Assert.IsTrue(reporter.Report(3, "Discount Tag is Visible", page.ProductPage.DiscountTag, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.DiscountTag)));
                Assert.IsTrue(reporter.Report(3, "New Price is Visible", page.ProductPage.NewPrice, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.NewPrice)));
                Assert.IsTrue(reporter.Report(3, "Old Price is Visible", page.ProductPage.OldPrice, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.OldPrice)));
                Assert.IsTrue(reporter.Report(3, "Product Image is Visible", page.ProductPage.ProductImage, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductImage)));
                Assert.IsTrue(reporter.Report(3, "Product Image Source is Correct", page.ProductPage.ProductImage, _browser.ToString(), resolution, _device.ToString(), _driver.ElementAttributeContainsValue(page.ProductPage.ProductImage, "style", new string[] { "background-image: url(\"grid/img/products/shoes/1.jpg\");" })));
                Assert.IsTrue(reporter.Report(3, "Product Name is Visible", page.ProductPage.ProductName, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductName)));
                Assert.IsTrue(reporter.Report(3, "Product Quantity is Visible", page.ProductPage.ProductQuantity, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductQuantity)));
                Assert.IsTrue(reporter.Report(3, "Product Quantity Label is Visible", page.ProductPage.ProductQuantityLabel, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductQuantityLabel)));
                Assert.IsTrue(reporter.Report(3, "Product Quantity Default Value is 1", page.ProductPage.ProductQuantityValue, _browser.ToString(), resolution, _device.ToString(), _driver.ElementAttributeContainsValue(page.ProductPage.ProductQuantityValue, "value", new string[] { "1" })));
                Assert.IsTrue(reporter.Report(3, "Product Rating is Visible", page.ProductPage.ProductRating, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductRating)));
                Assert.IsTrue(reporter.Report(3, "Product Review is Visible", page.ProductPage.ProductReview, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductReview)));
                Assert.IsTrue(reporter.Report(3, "Product Size Dropdown is Visible", page.ProductPage.ProductSizeDropdown, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductSizeDropdown)));
                Assert.IsTrue(reporter.Report(3, "Product Size Label is Visible", page.ProductPage.ProductSizeLabel, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductSizeLabel)));
                Assert.IsTrue(reporter.Report(3, "Product Default Value is 'Small (S)'", page.ProductPage.ProductSizeValue, _browser.ToString(), resolution, _device.ToString(), _driver.ElementsContainText(page.ProductPage.ProductSizeValue, new string[] { "Small (S)" })));
                Assert.IsTrue(reporter.Report(3, "Product Sku is Visible", page.ProductPage.ProductSku, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.ProductPage.ProductSku)));

                //Verify Footer
                Assert.IsTrue(reporter.Report(3, "Footer is Visible", page.FooterPage.Footer, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.Footer)));
                Assert.IsTrue(reporter.Report(3, "Footer Quick Links Section is Visible", page.FooterPage.FooterQuickLinksSection, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.FooterQuickLinksSection)));
                Assert.IsTrue(reporter.Report(3, "Footer Contacts Section is Visible", page.FooterPage.FooterContactsSection, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.FooterContactsSection)));
                Assert.IsTrue(reporter.Report(3, "Footer Keep In Touch Section is Visible", page.FooterPage.FooterKeepInTouchSection, _browser.ToString(), resolution, _device.ToString(), _driver.Displayed(page.FooterPage.FooterKeepInTouchSection)));
            });
        }
    }
}