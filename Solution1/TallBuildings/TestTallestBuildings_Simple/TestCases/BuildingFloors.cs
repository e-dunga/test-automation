using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace TestTallestBuildings
{
    internal class BuildingFloors
    {
        IWebDriver driver;
        public readonly int expectedNrOfFloors = 123;

        [SetUp]
        public void PrepairBrowser()
        {
            Browser browserObj = new Browser();
            driver = browserObj.PrepairBrowser();
        }

        [Test]
        public void FactsBuildingFloorTest()
        {
            driver.FindElement(By.XPath("//*[@data-order='Lotte World Tower']")).Click();
            driver.FindElement(By.XPath("//*[@href='#facts']")).Click();
            IList<IWebElement> buildingInfo = driver.FindElements(By.XPath("//*[@class='ml-2 font-semibold text-darkgray self-center']"));

            int nrOfFloorsFound = int.Parse(buildingInfo.Last().Text);
            Assert.That(expectedNrOfFloors == nrOfFloorsFound, $"The number of Floors is not exactly {expectedNrOfFloors}, but {nrOfFloorsFound}");
        }

        //Test case designed to verify that the Lotte World Tower has an exact number of Floors
        //public void DrawingBuildingFloorsTest()
        //{

        //    driver.FindElement(By.XPath("//*[@data-order='Lotte World Tower']")).Click();

        //    //Get data regarding Floors
        //    IWebElement floorElement = driver.FindElement(By.XPath("//*[@class='flex flex-wrap floors-content']"));
        //    IList<IWebElement> elements = floorElement.FindElements(By.XPath("//*[@class='flex w-full justify-end']"));

        //    //Get all Floor types and for the total number of Floors
        //    var nrOfFloors = 0;
        //    foreach (IWebElement element in elements)
        //    {
        //        nrOfFloors += int.Parse(element.Text);
        //    }

        //    Assert.That(nrOfFloors == expectedNrOfFloors, $"There are not {expectedNrOfFloors} total number of floors, but {nrOfFloors}");

        //}
        //public void HiddenBuldingFloorTest()
        //{
        //    IWebElement buildingTable = driver.FindElement(By.XPath("//*[@id='buildingsTable']"));
        //    IList<IWebElement> tableBody = buildingTable.FindElements(By.TagName("tbody"));
        //    IList<IWebElement> rows;
        //    var data = "";

        //    rows = tableBody[0].FindElements(By.TagName("tr"));
        //    foreach (IWebElement row in rows)
        //    {
        //        if (row.FindElement(By.ClassName("building-hover")).Text == "Lotte World Tower")
        //        {
        //            System.Console.WriteLine(row.Text);
        //            data = row.Text;
        //        }
        //    }
        //    var nrOfFloorsFound = int.Parse(data.Split('\n')[7]);

        //    Assert.That(expectedNrOfFloors == nrOfFloorsFound, $"The number of Floors is not exactly {expectedNrOfFloors}, but {nrOfFloorsFound}");
        //}

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();  
        }
    }
}
