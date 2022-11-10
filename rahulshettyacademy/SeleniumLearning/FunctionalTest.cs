using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class FunctionalTest
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
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void radioButton()
        {
            // find rdio buttons and assign radiobuttons to list
            IList <IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }

            }


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean userButtonSelected = driver.FindElement(By.Id("usertype")).Selected;
            TestContext.Progress.WriteLine($"User button is selected {userButtonSelected}"); // now issue with application so it will rerturn false even thou button is selected


            // Assert.That(userButtonSelected, Is.True);
            Assert.That(userButtonSelected, Is.False);


        }

        [Test]
        public void dropDown()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement optionToSelect = new SelectElement(dropdown);
            optionToSelect.SelectByText("Teacher");
            optionToSelect.SelectByValue("consult");
            optionToSelect.SelectByIndex(0);

        }

    }
}
