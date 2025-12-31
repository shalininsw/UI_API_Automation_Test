using Ui.Tests.Base;
using Ui.Tests.Pages;
using Ui.Tests.Utilities;

namespace Ui.Tests.Tests
{

    [TestClass]
    public class ProductsTest : BaseTest
    {

        [TestMethod]
        [TestCategory("ui")]
        public void VerifySearchProductsFunctionality()
        {
            logger.Info("*******STARTING -  VerifySearchProductsFunctionality test");
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");

            var productsPage = UiActionHelper.SearchProducts(driver, "jeans");
            UiAssertHelpers.AssertSearchedProductsTitle(productsPage.GetSearchedProductTitle());
            UiAssertHelpers.AssertProductsRelevant(productsPage, "jeans");
        }

    } 
}