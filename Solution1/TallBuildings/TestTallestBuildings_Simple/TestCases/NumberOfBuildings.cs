using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;


namespace TestTallestBuildings
{
    internal class NumberOfBuildings
    {
        IWebDriver driver;

        [SetUp]
        public void PrepairBrowser()
        {
            Browser browserObj = new Browser();
            driver = browserObj.PrepairBrowser();
        }

        [Test]
        //Test case designed to verify that the list contains 100 bultings in the table list
        public void NumberOfBuildingsTest()
        {
            //Get the table of buildings
            IWebElement buildingTable = driver.FindElement(By.XPath("//*[@id='buildingsTable']"));
            IList<IWebElement> tableBody = buildingTable.FindElements(By.TagName("tbody"));
            
            //Get all the rows from the table
            IList<IWebElement> rows;
            rows = tableBody[0].FindElements(By.TagName("tr"));

            Assert.That(rows.Count == 100, $"There are not 100 buildings in the list, but {rows.Count}");
            
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}
