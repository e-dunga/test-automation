using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTallestBuildings
{
    internal class BuildingWithMaxNumOfFloors
    {
        IWebDriver driver;
        Dictionary<string, int> buildings = new Dictionary<string, int>();

        [SetUp]
        public void PrepairBrowser()
        {
            Browser browserObj = new Browser();
            driver = browserObj.PrepairBrowser();
        }

        [Test]
        //Test case designed to verify that the list contains 100 bultings in the table list
        public void BuildingWithMaxNumOfFloorsTest()
        {
            //Get the table of buildings
            IWebElement buildingTable = driver.FindElement(By.XPath("//*[@id='buildingsTable']"));
            IList<IWebElement> tableBody = buildingTable.FindElements(By.TagName("tbody"));
            IList<IWebElement> rows;
            var data = "";
            rows = tableBody[0].FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                data = row.Text;
                buildings.Add(data.Split('\n')[1], int.Parse(data.Split('\n')[7]));
            }

            System.Console.WriteLine("The building with the most number of floors: " + buildings.Max(kvp => kvp.Key));
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
