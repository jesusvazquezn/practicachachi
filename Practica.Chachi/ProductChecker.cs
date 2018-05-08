using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica.Chachi
{
    class ProductChecker
    {
        ChromeDriver Chrome;
        public string site = "https://www.measureup.com/default.aspx";

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

        [Test]
        public void SearchProduct()
        {
            try
            {
                string product = "70-410";

                Chrome.Navigate().GoToUrl(site);
                Chrome.FindElement(By.Id("ctl00_wpm_HomePage_ctl01_Simplesearch_SearchPhrase")).Clear();
                Chrome.FindElement(By.Id("ctl00_wpm_HomePage_ctl01_Simplesearch_SearchPhrase")).SendKeys(product);
                Chrome.FindElementById("ctl00_wpm_HomePage_ctl01_Simplesearch_SearchButton").Click();
                Chrome.FindElementByXPath("//*[@id=\"ctl00_wpm_SearchPage_ctl05_SearchResultsAjaxPanel\"]/table/tbody/tr");
            } catch (Exception e)
            {
                Console.WriteLine("EEEEERROOOOOOOR: " + e);
                Assert.Fail();
            }
            
        }
        /*
        [Test]
        public void SearchArticle()
        {
            string article = "MeasureUp Contact Information";

            Chrome.Navigate().GoToUrl(site);
            Chrome.FindElementByXPath("//*[@id=\"navigation\"]/ul/li[4]/ul").
        }
        */
        [TearDown]
        public void CloseBrowser()
        {
            Chrome.Quit();
        }
    }
}
