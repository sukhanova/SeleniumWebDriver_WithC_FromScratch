using System;
using System.Collections;
using System.Collections.Generic;
using CSharpSeleniumFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SortWebTables : Base
    {

        [Test]
        public void sortTable()
        {
            ArrayList listA = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            // step 1  - get all items into array list A
            IList <IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in veggies)
            {
                listA.Add(veggie.Text);
            }

            TestContext.Progress.WriteLine($"Array of {listA.Count} items before sorting");
            foreach (String item in listA)
            {
                TestContext.Progress.WriteLine(item);
            }

            // step 2 - sort array list


            listA.Sort();
            TestContext.Progress.WriteLine($"Array of {listA.Count} items after sorting");
            foreach (String item in listA)
            {
                TestContext.Progress.WriteLine(item);
            }

            // step 3 - click column name

            // driver.FindElement(By.XPath("//th[contains(@aria-label,'fruit')]")).Click();
            driver.FindElement(By.CssSelector("th[aria-label*='fruit']")).Click(); // partial text match

            // step 4 - get all items into array list B
            ArrayList listB = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement sortedVeggie in sortedVeggies)
            {
                listB.Add(sortedVeggie.Text);
            }

            //TestContext.Progress.WriteLine($"Array B of {listB.Count} items");
            //foreach (String item in listB)
            //{
            //    TestContext.Progress.WriteLine(item);
            //}

            // compare array liststs A and B and verify they are equal

            Assert.AreEqual(listA, listB, "Arrays are not matching!");

        }

    }
}
