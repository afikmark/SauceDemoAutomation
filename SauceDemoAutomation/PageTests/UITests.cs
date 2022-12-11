using NUnit.Framework;
using SauceDemoAutomation.PageObjects;
using System.Collections.Generic;


namespace SauceDemoAutomation.PageTests
{
    [Property("Owner", "Afik")]
    [TestFixture]
    class UITests : BaseTest
    {
        [SetUp]
        public void Login()
        {
            LoginPage loginPage = new(driver);
            loginPage.login("standard_user", "secret_sauce");
        }
        [Test]
        public void TestProductErros()
        {
            List<string> blackListedWords = new List<string>
            {
                "Test",
                "Automation",
                "Automate",
                "Devlopment"
            };
            ProductsPage productsPage = new(driver);
            var blackListStringsFound = productsPage.FindDescriptionErrors(blackListedWords);
            var isBlackListedWordsFound = blackListStringsFound.Item1;
            var blackListedWordsList = blackListStringsFound.Item2;
            Assert.That(isBlackListedWordsFound, Is.False, $"black listed words found! {blackListedWordsList}");
        }
    }
}
