using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
    class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        public IWebElement title => Driver.FindElement(By.CssSelector(".title"));
        public IList<IWebElement> itemsList => Driver.FindElements(By.CssSelector(".inventory_item"));

        public bool FindDescriptionErrors(IList<string> blackList)
        {
            var isWordFound = false;
            foreach (WebElement item in itemsList)
            {
                foreach (string blackListString in blackList)
                {
                    var itemText = item.Text;
                    var blackListStringLower = blackListString.ToLower();
                    if (itemText.Contains(blackListStringLower))
                    {
                        Console.WriteLine("A black listed word was found" + ":" + blackListString);
                        var profileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        var screenShotsFolder = profileFolderPath + @"\source\repos\afikmark\SauceDemoAutomation\resources\";
                        var counter = 0;
                        var fileName = blackListString + counter++;
                        TakeElementScreenShot(item, screenShotsFolder, fileName);
                    }
                }
            }
            return isWordFound;
        }



    }
}
