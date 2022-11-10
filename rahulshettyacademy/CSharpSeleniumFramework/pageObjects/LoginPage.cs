using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // PageObject factory pattern

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkBox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInButton;


        public IWebElement getUserName()
        {
            return username;
        }


        public ProductsPage validLogin(string userUserName, string userPassword)
        {
            username.SendKeys(userUserName);
            password.SendKeys(userPassword);
            checkBox.Click();
            signInButton.Click();
            return new ProductsPage(driver);
        }
    }
}
