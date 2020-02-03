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

        [Given(@"I navigated to https://domain.hinet.net")]
        public void GivenINavigatedTo()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://domain.hinet.net");
        }

        [Then(@"The title should be HiNet 域名註冊")] 
        public void ThenTheTitleShouldBe()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var result = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b/span")));
            Assert.AreEqual("HiNet 域名註冊", _webDriver.Title);
            _webDriver.Quit();
        }
    }
}
