using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace SpecFlowStudy.UiTests.WebDriverTests.Steps
{
    [Binding]
    public class HiNetDomainSteps
    {
        private IWebDriver _webDriver;

        public HiNetDomainSteps()
        {
            
        }

        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {
            _webDriver = new ChromeDriver { Url = ConfigurationManager.AppSettings["seleniumBaseUrl"]};
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(string.Format("{0}{1}", _webDriver.Url, url));
        }
        
        [Then(@"The title should be (.*)")]
        public void ThenTheTitleShouldBe(string text)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var result = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b/span")));
            Assert.AreEqual(text, _webDriver.Title);
        }


        [AfterScenario]
        public void CloseBrowser()
        {
            _webDriver.Quit();
        }
    }
}
