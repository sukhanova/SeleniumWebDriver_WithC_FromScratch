using System;
using System.Threading;
using CSharpSeleniumFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class WindowHandlers : Base
    {

        [Test]
        public void WindowHandle()
        {
            String email = "mentor@rahulshettyacademy.com";
            String parentWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);
            String childWindowName = driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindowName);

            // TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

            String text = driver.FindElement(By.CssSelector(".red")).Text;

            String[] splittedText = text.Split("at");

            String[] trimmedString = splittedText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimmedString[0]);

            driver.SwitchTo().Window(parentWindow);

            Thread.Sleep(5000);
            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);
            

        }

    }
}