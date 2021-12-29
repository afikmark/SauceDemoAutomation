using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageTests
{
    public class BaseTest
    {
       public IWebDriver driver;
        private const string swagLabsURL = "https://www.saucedemo.com/";
        [OneTimeSetUp]
        public void SetUp()
        {
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
