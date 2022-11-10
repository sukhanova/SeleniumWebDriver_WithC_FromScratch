using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        // locators: Xpath, id, className, name, tagName, text

        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {
            // setup for Chrome driver
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            // Implicit wait 5 seconds can be declared globally and will apply to entire program:
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Explicit wait is used to target the specific element instead of applying globally


            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]

        public void LocatorsIdentification()
        {
            // username
            driver.FindElement(By.Id("username")).SendKeys("Oliver");
            driver.FindElement(By.ClassName("form-control")).Clear();
            // driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");

            driver.FindElement(By.Id("username")).SendKeys("okootest");

            // passowrd
            driver.FindElement(By.Name("password")).SendKeys("learning");


            // click button using css selector
            // tagname[attribute='value']

            // driver.FindElement(By.CssSelector("input[id='signInBtn']")).Click();
            // driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();


            // Xpath
            // driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.XPath("//label[@class='text-info']/span/input")).Click();

            // driver.FindElement(By.CssSelector(".text-info span input")).Click();
            //driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();

            // click button using Xpath
            //  //tagname[@attribute = 'value']
            // driver.FindElement(By.XPath("//input[@name='signin']")).Click();
            // driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            driver.FindElement(By.CssSelector("#signInBtn")).Click();


            // explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));

            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);


            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));

            // validate url of the link text
            String hrefAttribute = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            // Assertion
            Assert.AreEqual(expectedUrl, hrefAttribute, "There are no match!!!");

            // Xpath
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();



        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
