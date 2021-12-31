using NUnit.Framework;
using SauceDemoAutomation.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

   
        [TestCase("standard_user", "locked_out_user", "problem_user", "performance_glitch_user")]
        public void TC01_LoginAllUsers(string standardUser,string lockedOutUser, string problemUser, string performenceGlitchUser)
        {
            LoginPage loginPage = new LoginPage(driver);
            //login with standard user
            loginPage.login(standardUser, globalPassword);
          
            ProductsPage prodPage = new ProductsPage(driver);
            var titleString = prodPage.title.Text;
            Assume.That(titleString, Is.EqualTo(expectedTitle).IgnoreCase);
            //Logout and test title is the same as expected 
            prodPage.logOut();
            var loginPageTitleText = driver.Title;
            Assume.That(loginPageTitleText, Is.EqualTo(loginTitleExpected));


            //login with locked out user- test error 
            loginPage.login(lockedOutUser, globalPassword);
            var loginError = loginPage.GetLoginError();
            var expectedError = "Epic sadface: Sorry, this user has been locked out.";
            Assume.That(loginError, Is.EqualTo(expectedError));

            loginPage.login(problemUser, globalPassword);
            var isFirstItemCorrect = prodPage.ComparePictures();
            Assume.That(isFirstItemCorrect != true);

            prodPage.logOut();
            Assume.That(loginPageTitleText, Is.EqualTo(loginTitleExpected));

            //Login on average takes up to 5 seconds
            loginPage.login(performenceGlitchUser, globalPassword);
            loginPage.implictWait(5000);
            Assume.That(prodPage.title.Text, Is.EqualTo(expectedTitle).IgnoreCase);
            prodPage.logOut();
            Assume.That(loginPageTitleText, Is.EqualTo(loginTitleExpected));

        }
    }
}
