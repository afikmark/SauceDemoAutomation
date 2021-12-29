using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
    class ProductsPage :BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        public IWebElement title => Driver.FindElement(By.CssSelector(".title")); 

    }
}
