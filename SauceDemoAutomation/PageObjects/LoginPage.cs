using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
     class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public IWebElement userNameBox => Driver.FindElement(By.CssSelector("#user-name"));
        public IWebElement userPasswordBox => Driver.FindElement(By.CssSelector("#password"));
        public IWebElement loginButton => Driver.FindElement(By.CssSelector("#login-button"));

        public void login(string userName, string password)
        {
            FillText(userNameBox, userName);
            FillText(userPasswordBox, password);
            Click(loginButton);
        }
    }
}
