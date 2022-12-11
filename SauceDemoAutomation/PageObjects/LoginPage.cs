using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
    [Property("Owner", "Afik")]
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public IWebElement UserNameBox => Driver.FindElement(By.CssSelector("#user-name"));
        public IWebElement UserPasswordBox => Driver.FindElement(By.CssSelector("#password"));
        public IWebElement LoginButton => Driver.FindElement(By.CssSelector("#login-button"));

        public IWebElement LoginErrorContainer => Driver.FindElement(By.CssSelector(".error-message-container>h3"));

        public IList<IWebElement> LoginPageTitle => Driver.FindElements(By.CssSelector(".login_logo"));

        public void login(string userName, string password)
        {
            FillText(UserNameBox, userName);
            FillText(UserPasswordBox, password);
            Click(LoginButton);
        }



        public string GetLoginError()
        {
            var getError = LoginErrorContainer;
            return getError.Text;
        }
    }
}
