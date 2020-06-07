using Applitools.Framework;
using Applitools.Selenium;
using Applitools.VisualGrid;
using NUnit.Framework;
using System.Drawing;


namespace Applitools.Tests.Modern
{
    [TestFixture]
    [Category("modern2")]
    public class ModernV2 : ApplitoolsBaseTestClass
    {
        [Test]
        public void Task1()
        {
            VisualGridRunner runner = new VisualGridRunner(10);
            Eyes eyes = new Eyes(runner);

            try
            {
                SetUp(eyes);
                eyes.Open(_driver, "AppliFashion", "Task1", new Size(800, 600));
                eyes.Check(Target.Window().Fully().WithName("Cross-Device Elements Test"));
            }
            catch
            {
                eyes.AbortAsync();
            }
            finally
            {
                TearDown(_driver, runner);
            }
        }

        [Test]
        public void Task2()
        {
            VisualGridRunner runner = new VisualGridRunner(10);
            Eyes eyes = new Eyes(runner);

            try
            {
                SetUp(eyes);
                eyes.Open(_driver, "AppliFashion", "Task2", new Size(800, 600));
                _driver.Click(page.HomePage.ProductGridFilterIcon);
                _driver.SetValue(page.HomePage.SidebarGridFilterOption("Black"), "true");
                _driver.Click(page.HomePage.SidebarGridFilterFilterButton);
                eyes.Check(Target.Region(page.HomePage.ProductGrid).WithName("Filter Results"));
            }
            catch
            {
                eyes.AbortAsync();
            }
            finally
            {
                TearDown(_driver, runner);
            }
        }

        [Test]
        public void Task3()
        {
            VisualGridRunner runner = new VisualGridRunner(10);
            Eyes eyes = new Eyes(runner);

            try
            {
                SetUp(eyes);
                eyes.Open(_driver, "AppliFashion", "Task3", new Size(800, 600));
                _driver.Click(page.HomePage.ProductGridFilterIcon);
                _driver.SetValue(page.HomePage.SidebarGridFilterOption("Black"), "true");
                _driver.Click(page.HomePage.SidebarGridFilterFilterButton);
                _driver.Click(page.HomePage.ProductGridProductCard("Appli Air x Night"));
                Assert.IsTrue(page.ProductPage.IsAt());
                Assert.IsTrue(_driver.Displayed(page.ProductPage.ProductImage));
                eyes.Check(Target.Window().Fully().WithName("Product Details test"));
            }
            catch
            {
                eyes.AbortAsync();
            }
            finally
            {
                TearDown(_driver, runner);
            }

        }
    }
}
