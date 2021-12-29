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
    class LoginTests : BaseTest
    {
        private const string standard_User = "standard_user";
        private const string globalPassword = "secret_sauce";
        [Test]
        public void LoginValidUser()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.login(standard_User, globalPassword);
            ProductsPage productsPage = new ProductsPage(driver);
            var titleString =productsPage.title.Text;
            var expectedTitle = "Products";
            Assert.That(titleString, Is.EqualTo(expectedTitle).IgnoreCase);
            
        }
    }
}
