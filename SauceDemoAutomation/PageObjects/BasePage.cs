using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoAutomation.PageObjects
{
	 class BasePage
	{
		public BasePage(IWebDriver driver)
		{
			Driver = driver;
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

	}
}
