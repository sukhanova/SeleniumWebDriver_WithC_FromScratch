using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class AlertActionsAutoSuggestive
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {
            // setup for Chrome driver
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";

        }


        [Test]
        public void frames()
        {

            //scroll

            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            // accepts frame id, name or index
            driver.SwitchTo().Frame("courses-iframe"); // frame id
           // driver.SwitchTo().Frame("iframe-name"); // frame name
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            Thread.Sleep(3000);
            var frameHeader = driver.FindElement(By.CssSelector("h1")).Text;

            TestContext.Progress.WriteLine($"Page header is {frameHeader}"); // Prints All Access Subscription
            driver.SwitchTo().DefaultContent(); // brings you back to the parent page
            Thread.Sleep(3000);
            var pageHeader = driver.FindElement(By.CssSelector("h1")).Text;
            TestContext.Progress.WriteLine($"Page header is {pageHeader}"); // prints Practice Page


        }


        [Test]
        public void test_Alert()
        {

            String name = "Oliver";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();

            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept(); // selects OK
            // driver.SwitchTo().Alert().Dismiss(); // selects Cancel or some other negative value of

            // if you need to type something on pop-up window:
            // driver.SwitchTo().Alert().SendKeys("test input");

            StringAssert.Contains(name, alertText, "Alert display an incorrect name");

        }


        [Test]
        public void test_AutosuggestiveDropdown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("us");
            Thread.Sleep(3000);
            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Contains("United"))
                {
                    option.Click();
                }
            }

            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }


        [Test]
        public void test_staticDropdown()
        {

            //IWebElement dropdown = driver.FindElement(By.CssSelector("#dropdown-class-example"));
            //dropdown.Click();
            //SelectElement optionToSelect = new SelectElement(dropdown);
            //optionToSelect.SelectByIndex(1);

            IWebElement dropdown = driver.FindElement(By.CssSelector("#dropdown-class-example"));
            dropdown.Click();
            IList<IWebElement> options = driver.FindElements(By.CssSelector("#dropdown-class-example option"));
            foreach (IWebElement option in options)
            {
                //option.GetAttribute("value"); // option1/option2 etc
                TestContext.Progress.WriteLine(option.GetAttribute("text"));
                if (option.Text.Contains("2")) {
                    option.Click();
                }
            }
        }

        [Test]
        public void test_Actions()
        {
            driver.Url = "https://www.rahulshettyacademy.com/";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            // driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();
            Thread.Sleep(3000);
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();

        }


        [Test]
        public void test_DragAndDrop()
        {
            driver.Url = "https://demoqa.com/droppable/";
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();
           
        }




        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(8000);
            driver.Quit();
        }
    }
}
