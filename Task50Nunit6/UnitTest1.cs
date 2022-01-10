using NUnit.Framework;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;

namespace Task40Nunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
       
        public void Test6one()
        {
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
        public void Test6two()
        {
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
        public void Test6three()
        {
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
        public void Test7()
        {
            IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/dynamic-data-loading-demo.html");
            driver.Manage().Window.Maximize();

            var newUserButton = driver.FindElement(By.CssSelector(".btn-default"));
            newUserButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            var element = wait.Until(condition =>
            {
                try
                {
                    Assert.IsTrue(driver.FindElement(By.CssSelector("#loading")).Displayed, "New user is not displayed");
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            driver.Close();
        }
        [Test]
        public void Test8()
        {
            IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html");
            driver.Manage().Window.Maximize();

            var downloadButton = driver.FindElement(By.CssSelector("#cricle-btn"));
            downloadButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(13));
            var element = wait.Until(condition =>
            {
                try
                {
                    Assert.IsTrue(driver.FindElement(By.CssSelector(".clipauto")).Displayed, "Element is not found");
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            driver.Navigate().Refresh();

            driver.Close();

        }
    }
}