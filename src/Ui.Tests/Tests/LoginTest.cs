using Ui.Tests.Base;
using Ui.Tests.Pages;
using Ui.Tests.Utilities;

namespace Ui.Tests.Tests
{

    [TestClass]
    public class LoginTests : BaseTest
    {

        [TestMethod]
        [TestCategory("ui")]
        public void VerifyLoginFunctionality()
        {
            logger.Info("*******STARTING - VerifyLoginFunctionality test");
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");

            var homePage = UiActionHelper.Login(driver);
            UiAssertHelpers.AssertLoggedInUser(homePage, "automationtestuser1");
        }
    } 
}