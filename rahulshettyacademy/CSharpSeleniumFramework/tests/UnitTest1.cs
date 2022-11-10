using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSeleniumFramework.pageObjects;
using CSharpSeleniumFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CSharpSeleniumFramework
{
    public class E2ETest : Base
    {

        [Test]
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productPage = loginPage.validLogin("rahulshettyacademy", "learning");
            productPage.waitForPageDisplay();
            
            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
                // TestContext.Progress.WriteLine(actualProducts[item]);
            }

            Assert.AreEqual(expectedProducts, actualProducts, "There are not match!");

            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Id("country")).SendKeys("ite");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("United States of America")));
            driver.FindElement(By.LinkText("United States of America")).Click();

            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();

            // Click Purchase button
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            // driver.FindElement(By.CssSelector(".btn-success")).Click();
            // driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

            String confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmText, "There are no match!");

        }
    }
}
