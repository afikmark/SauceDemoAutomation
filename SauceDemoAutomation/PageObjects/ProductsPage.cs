using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
    [Property("Owner", "Afik")]
    class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        public IWebElement title => Driver.FindElement(By.CssSelector(".title"));
        public IList<IWebElement> itemsImgList => Driver.FindElements(By.CssSelector(".inventory_item img"));
        public IList<IWebElement> itemsList => Driver.FindElements(By.CssSelector(".inventory_item"));

        public IWebElement burgerBtn => Driver.FindElement(By.CssSelector("#react-burger-menu-btn"));

        public IList<IWebElement> burgerMenuItemList => Driver.FindElements(By.CssSelector("bm-item-list"));

        public IWebElement logoutBtn => Driver.FindElement(By.CssSelector("#logout_sidebar_link"));

      



        public void logOut()
        {
            Click(burgerBtn);
            implictWait(1000);
            Click(logoutBtn);
        }

        public Tuple<bool,IList> FindDescriptionErrors(IList<string> blackList)
        {
            var isWordFound = false;
            List<string> blackListedWordsFound = new List<string>();
            foreach (WebElement item in itemsList)
            {
                foreach (string blackListString in blackList)
                {
                    var itemText = item.Text;
                    var blackListStringLower = blackListString.ToLower();
                    if (itemText.Contains(blackListStringLower))
                    {
                        Console.WriteLine("A black listed word was found" + ":" + blackListString);
                        isWordFound = true;    
                        blackListedWordsFound.Add(blackListString);
                
                    }
                }
            }
            return new Tuple<bool, IList>(isWordFound, blackListedWordsFound);
        }
        public string GetFirstPicture()
        {
            WebElement firstItem = (WebElement)itemsImgList.ElementAt(0);
            string firstItemStr = firstItem.GetAttribute("src");
            return firstItemStr;
        }

        



    }
}
