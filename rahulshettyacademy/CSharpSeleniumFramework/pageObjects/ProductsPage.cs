using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace CSharpSeleniumFramework.pageObjects
{
    public class ProductsPage
    {

        IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;


        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }
    }
}
