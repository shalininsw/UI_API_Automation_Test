using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ui.Tests.Pages;

namespace Ui.Tests.Utilities
{
    public static class UiAssertHelpers
    {
        public static void AssertAccountCreated(string actual)
        {
            Assert.AreEqual("ACCOUNT CREATED!", actual);
        }

        public static void AssertLoggedInUser(HomePage homePage, string expectedName)
        {
            Assert.AreEqual("Logged in as " + expectedName, homePage.GetLoggedInUserName(), "Logged in user name does not match");
        }

        public static void AssertAccountDeleted(string actual)
        {
            Assert.AreEqual("ACCOUNT DELETED!", actual, "Account deletion text does not match");
        }

        public static void AssertSearchedProductsTitle(string actual)
        {
            Assert.AreEqual("SEARCHED PRODUCTS", actual, "Searched Products title does not match");
        }

        public static void AssertProductsRelevant(ProductsPage productsPage, string keyword)
        {
            Assert.IsTrue(productsPage.IsSearchedProductsRelevant(keyword), "Some searched products are not relevant");
        }
    }
}
