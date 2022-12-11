using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SauceDemoAutomation.PageTests
{
    [Property("Owner", "Afik")]

    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            var swagLabsURL = "https://www.saucedemo.com/";
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = swagLabsURL;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}
