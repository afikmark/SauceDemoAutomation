using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        public IList<IWebElement> itemsList => Driver.FindElements(By.CssSelector(".inventory_item"));

        public IWebElement burgerBtn => Driver.FindElement(By.CssSelector("#react-burger-menu-btn"));

        public IList<IWebElement> burgerMenuItemList => Driver.FindElements(By.CssSelector("bm-item-list"));

        public IWebElement logoutBtn => Driver.FindElement(By.CssSelector("#logout_sidebar_link"));

        private string profileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);



        public void logOut()
        {
            Click(burgerBtn);
            implictWait(1000);
            Click(logoutBtn);
        }

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
                        var screenShotsFolder = profileFolderPath + @"\source\repos\afikmark\SauceDemoAutomation\resources\CaptureSC\";
                        var counter = 0;
                        var fileName = blackListString + counter++;
                        TakeElementScreenShot(item, screenShotsFolder, fileName);
                    }
                }
            }
            return isWordFound;
        }

        public bool ComparePictures()
        {
            WebElement firstItem = (WebElement)itemsList.ElementAt(0);
                var screenShotPath = profileFolderPath + @"\source\repos\afikmark\SauceDemoAutomation\resources\CaptureSC\";
                TakeElementScreenShot(firstItem, screenShotPath, "firstItemPicture");
            var firstItemExpectedPath = profileFolderPath + @"\source\repos\afikmark\SauceDemoAutomation\resources\CaptureSC\ExpectedSC\firstProductItem.PNG";
            var areImgEqual = CompareBitmaps(screenShotPath, firstItemExpectedPath);
                return areImgEqual;
        }

        



    }
}
