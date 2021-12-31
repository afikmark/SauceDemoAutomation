using NUnit.Framework;
using SauceDemoAutomation.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageTests
{
    [Property("Owner", "Afik")]
    class UITests : BaseTest
    {
        [SetUp]
        public void Login()
        {
            LoginPage loginPage = new LoginPage(driver);
            LoginTests loginTests = new LoginTests();
            loginPage.login("standard_user", "secret_sauce");
        }
        [Test]
        public void ProductErros()
        {
            List<string> blackListedWords = new List<string>();
            blackListedWords.Add("Test");
            blackListedWords.Add("Automation");
            blackListedWords.Add("Automate");
            blackListedWords.Add("Devlopment");
            ProductsPage productsPage = new ProductsPage(driver);
            var blackListStringsFound =productsPage.FindDescriptionErrors(blackListedWords);
            Assert.That(!blackListStringsFound);
        }
    }
}
