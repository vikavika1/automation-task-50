using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Task40Nunit
{
    public class Tests
    {
        [SetUp]
        public void Setup() {}

        [Test]

        public void Test5() {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/basic-select-dropdown-demo.html");
            driver.Manage().Window.Maximize();

            SelectElement select = new SelectElement(driver.FindElement(By.Id("multi-select")));

            Assert.IsTrue(select.IsMultiple);

            select.SelectByIndex(2);
            select.SelectByIndex(4);
            select.SelectByIndex(7);

            Assert.AreEqual(3, select.AllSelectedOptions.Count);

            driver.Close();
        }
            [Test]
       
        public void Test6one() {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
            driver.Manage().Window.Maximize();

            var clicMeButton = driver.FindElement(By.XPath("//button[contains(@onclick, 'myConfirmFunction')]"));
            clicMeButton.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Assert.IsTrue(driver.FindElement(By.CssSelector("#confirm-demo")).Displayed, "Message is not displayed");

            driver.Close();
        }
        [Test]
        public void Test6two() {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
            driver.Manage().Window.Maximize();

            var clicMeButton = driver.FindElement(By.XPath("//button[contains(@onclick, 'myConfirmFunction')]"));
            clicMeButton.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();

            Assert.IsTrue(driver.FindElement(By.CssSelector("p#confirm-demo")).Displayed, "Message is not displayed");

            driver.Close();
        }
        [Test]
        public void Test6three() {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
            driver.Manage().Window.Maximize();

            var clicMeButton = driver.FindElement(By.XPath("//button[contains(@onclick, 'myPromptFunction()')]"));
            clicMeButton.Click();
            Thread.Sleep(2000);

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys("Olga");
            alert.Accept();

            Assert.IsTrue(driver.FindElement(By.CssSelector("#prompt-demo")).Displayed, "Message is not displayed");

            driver.Close();
        }
        [Test]
        public void Test7() {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/dynamic-data-loading-demo.html");
            driver.Manage().Window.Maximize();

            var newUserButton = driver.FindElement(By.CssSelector(".btn-default"));
            newUserButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(condition => driver.FindElement(By.CssSelector("#loading")).Displayed);

            Assert.IsTrue(element, "New user is not displayed");
            driver.Close();
        }
        [Test]
        public void Test8() {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html");
            driver.Manage().Window.Maximize();

            var downloadButton = driver.FindElement(By.CssSelector("#cricle-btn"));
            downloadButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(condition => driver.FindElement(By.ClassName("clipauto")).Displayed);
            Assert.IsTrue(element, "Element is not found");

            driver.Navigate().Refresh();
            driver.Close();
        }
    }
}