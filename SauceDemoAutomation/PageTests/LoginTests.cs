using NUnit.Framework;
using SauceDemoAutomation.PageObjects;


namespace SauceDemoAutomation.PageTests
{
    [Property("Owner","Afik")]
    class LoginTests : BaseTest
    {
        private const string globalPassword = "secret_sauce";
        private const string expectedTitle = "Products";
        private const string loginTitleExpected = "Swag Labs";
       
        public string Getstandard_User { get; }
        public string GetGlobalPassword { get; }

        [TestCase("standard_user")]

        public void TC01_LoginStandardUser(string standardUser)
        {
            LoginPage loginPage = new(driver);
            loginPage.login(standardUser, globalPassword);
            ProductsPage prodPage = new(driver);
            var titleString = prodPage.title.Text;
            Assert.That(titleString, Is.EqualTo(expectedTitle).IgnoreCase);
        }

        [TestCase("locked_out_user")]
        public void TC02_LoginLockedUser(string lockedOutUser)
        {
            LoginPage loginPage = new(driver);
            loginPage.login(lockedOutUser, globalPassword);
            var loginError = loginPage.GetLoginError();
            var expectedError = "Epic sadface: Sorry, this user has been locked out.";
            Assert.That(loginError, Is.EqualTo(expectedError));
        }

        [TestCase("standard_user", "problem_user")]
        
        public void TC03_LoginProblemUser(string standardUser,string problemUser)
        {
            LoginPage loginPage = new(driver);
            loginPage.login(standardUser, globalPassword);
            ProductsPage prodPage = new(driver);
            var expectedFirstItemPicture = prodPage.GetFirstPicture();
            prodPage.logOut();
            loginPage.login(problemUser, globalPassword);
            var actualFirstItemPicture = prodPage.GetFirstPicture();
            var isFirstItemCorrect = true &&actualFirstItemPicture == expectedFirstItemPicture;
            Assert.That(isFirstItemCorrect, Is.True, "first item in shopping list does not match expected.");
        }

        [TestCase("performance_glitch_user")]

        public void TC04_LoginPerformenceGlitchUser(string performenceGlitchUser)
        {
            LoginPage loginPage = new(driver);
            loginPage.login(performenceGlitchUser, globalPassword);
            ProductsPage prodPage = new(driver);
            Assert.That(prodPage.title.Text, Is.EqualTo(expectedTitle).IgnoreCase);
        }

    }
}
