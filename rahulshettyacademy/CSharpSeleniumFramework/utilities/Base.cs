using System;
using System.Configuration;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
namespace CSharpSeleniumFramework.utilities
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {

            // setup for Chrome driver
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        } 


        [TearDown]
        public void AfterTest()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
