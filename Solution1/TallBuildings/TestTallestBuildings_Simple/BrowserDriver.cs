using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System;
using Microsoft.Win32;
using System.Diagnostics;

namespace TestTallestBuildings
{
    internal class Browser
    {
        IWebDriver driver;
        public IWebDriver PrepairBrowser()
        {
            for (int i = 7; i >= 5; i--)
            {
                try
                {
                    var location = AppDomain.CurrentDomain.BaseDirectory + "../../../../../drivers/chrome/10" + i +"/";
                    driver = new ChromeDriver(@location);
                }
                catch {
                    var strCmdComm = "/C taskkill /F /PID chromedriver.exe";
                    System.Diagnostics.Process.Start("CMD.exe", strCmdComm);
                    System.Threading.Thread.Sleep(2000);
                    continue; 
                }
            }
            
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.skyscrapercenter.com/buildings?list=tallest100-construction";
            //Select tallest 100 Completed buildings from the dropdown list
            IWebElement element = driver.FindElement(By.XPath("//*[@class='select-lists-pages pr-10 py-4 px-3']"));
            SelectElement select = new SelectElement(element);
            select.SelectByValue("tallest100-completed");

            return driver;
        }
    }
}
