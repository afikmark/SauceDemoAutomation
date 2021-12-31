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
        public IWebElement userNameBox => Driver.FindElement(By.CssSelector("#user-name"));
        public IWebElement userPasswordBox => Driver.FindElement(By.CssSelector("#password"));
        public IWebElement loginButton => Driver.FindElement(By.CssSelector("#login-button"));

        public IList<IWebElement> loginErrorContainer => Driver.FindElements(By.CssSelector(".error-message-container"));

        public IList<IWebElement> loginPageTitle => Driver.FindElements(By.CssSelector(".login_logo"));

       
        public void login(string userName, string password)
        {
            FillText(userNameBox, userName);
            FillText(userPasswordBox, password);
            Click(loginButton);
        }

      

        public string GetLoginError()
        {
            var getError = " ";
            for (int i = 0; i < loginErrorContainer.Count; i++)
            {
                getError = loginErrorContainer[i].Text;
            }
            return getError;
        }
    }
}
