using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageTests
{
    [Property("Owner", "Afik")]
    public class BaseTest
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            var swagLabsURL = "https://www.saucedemo.com/";
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
