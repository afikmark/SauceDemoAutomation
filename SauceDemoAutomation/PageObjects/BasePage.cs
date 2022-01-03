using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
	[Property("Owner", "Afik")]
	class BasePage
	{
		public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}
		
	

		public void ExplicitWait_StringInElement(int timeInMilliSeconds, IWebElement element, string text)
        {
			
			var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeInMilliSeconds));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));


		}

		public void implictWait(int timeInMilliSeconds)
        {
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeInMilliSeconds);
		}

		public IWebDriver Driver { get; set; }

		public void FillText(IWebElement el, string text)
		{
			el.Clear();
			el.SendKeys(text);
		}

		public void Click(IWebElement el)
		{
		
			el.Click();
		}

		public string GetText(IWebElement el)
		{
			return el.Text;
		}

		public void TakeElementScreenShot(WebElement element, string screenShotPath,string screenShotName)
        {
			element.GetScreenshot().SaveAsFile(screenShotPath+screenShotName+".PNG");
        }


		public bool CompareBitmaps(string firstImgPath, string secondImgPath)
        {
            try { 
			Bitmap firstBtimap = new Bitmap(firstImgPath);
			Bitmap secondBitmap = new Bitmap(secondImgPath);
			var areEqual = firstBtimap.Size.Equals(secondBitmap.Size);
				return areEqual;
			}
			catch(Exception e)
            {
				Console.WriteLine(e.Message);
				return false;
            }

               
        }

		public string GetTitle()
        {
			return Driver.Title;
        }

	}
}
