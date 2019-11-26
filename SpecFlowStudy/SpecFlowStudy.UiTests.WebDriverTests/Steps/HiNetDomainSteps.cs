using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using SpecFlowStudy.UiTests.CommonTools;
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
        private WebDriver _webDriver;

        public HiNetDomainSteps()
        {
            
        }

        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {
            _webDriver = new WebDriver();
            IWebDriver webDriver = _webDriver.Current;
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(string.Format("{0}{1}", webDriver.Url, url));
        }
        
        [Then(@"The title should be (.*)")]
        public void ThenTheTitleShouldBe(string text)
        {
            var result = _webDriver.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b/span")));
            Assert.AreEqual(text, _webDriver.Current.Title);
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            _webDriver.Quit();
        }
    }
}
