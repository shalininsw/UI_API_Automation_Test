using OpenQA.Selenium;
using Ui.Tests.Pages;

namespace Ui.Tests.Utilities
{
    public static class UiActionHelper
    {
        public static (string name, string accountCreateText) RegisterNewUser(IWebDriver driver)
        {
            var homePage = new HomePage(driver);
            homePage.ClickLogin();

            var loginPage = new LoginPage(driver);
            var randomName = loginPage.EnterSignUpName();
            loginPage.EnterSignUpEmail();
            loginPage.ClickSignUpButton();

            var signUpPage = new SignUpPage(driver);
            signUpPage.EnterPassword();
            signUpPage.EnterFirstName();
            signUpPage.EnterLastName();
            signUpPage.EnterAddress();
            signUpPage.EnterState();
            signUpPage.EnterCity();
            signUpPage.EnterZipCode();
            signUpPage.EnterMobile();
            signUpPage.ClickSubmit();

            var createdText = signUpPage.GetAccountCreateText();
            signUpPage.ClickContinueButton();

            return (randomName, createdText);
        }

        public static string DeleteAccount(IWebDriver driver)
        {
            var homePage = new HomePage(driver);
            homePage.ClickDeleteAccount();
            var signUpPage = new SignUpPage(driver);
            return signUpPage.GetAccountDeletionText();
        }

        public static HomePage Login(IWebDriver driver)
        {
            var homePage = new HomePage(driver);
            homePage.ClickLogin();

            var loginPage = new LoginPage(driver);
            loginPage.EnterEmailAddress();
            loginPage.EnterPassword();
            loginPage.ClickLogin();

            return homePage;
        }

        public static ProductsPage SearchProducts(IWebDriver driver, string productName)
        {
            var homePage = new HomePage(driver);
            homePage.ClickProducts();
            var productsPage = new ProductsPage(driver);
            productsPage.EnterProductName(productName);
            productsPage.ClickSearchButton();
            return productsPage;
        }
    }
}
