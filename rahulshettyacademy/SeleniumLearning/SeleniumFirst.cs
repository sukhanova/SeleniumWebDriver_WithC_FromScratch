using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            // setup for Edge driver to run test in Edge browser
            // new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new EdgeDriver();


            // setup for Firefox driver to run tests in Firefox browser
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //driver = new FirefoxDriver();

            // setup for Chrome driver
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();


            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            driver.Close();
        }


        [TearDown]
        public void CloseBrowser()
        {
            //driver.Quit();
        }
    }
}
