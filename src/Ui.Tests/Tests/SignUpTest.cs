using Ui.Tests.Base;
using Ui.Tests.Pages;
using Ui.Tests.Utilities;

namespace Ui.Tests.Tests
{

    [TestClass]
    public class SignUpTest : BaseTest
    {

        [TestMethod]
        [TestCategory("ui")]
        public  void VerifySignUpAndDeleteFunctionality()
        {
            logger.Info("*******STARTING -  VerifySignUpAndDeleteFunctionality test");
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");

            var (randomName, accountCreateText) = UiActionHelper.RegisterNewUser(driver);
            UiAssertHelpers.AssertAccountCreated(accountCreateText);

            var homePage = new HomePage(driver);
            UiAssertHelpers.AssertLoggedInUser(homePage, randomName);

            var deletionText = UiActionHelper.DeleteAccount(driver);
            UiAssertHelpers.AssertAccountDeleted(deletionText);
        }
    } 
}