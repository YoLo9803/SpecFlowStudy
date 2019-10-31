using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using SpecFlowStudy.UiTests.CommonTools;
using System.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace SpecFlowStudy.UiTests.WebDriverTests.Steps
{
    [Binding]
    public class HiNetDomainSteps
    {
        private readonly WebDriver _webDriver;

        private readonly Dictionary<string, string> _domainIdentifier;
        public HiNetDomainSteps()
        {
            _webDriver = new WebDriver();
            _domainIdentifier = initialDomainIdentifier();
        }

        private Dictionary<string, string> initialDomainIdentifier()
        {
            Dictionary<string, string> domains = new Dictionary<string, string>();
            domains.Add(".com.tw", ".form-group:nth-child(2) .ng-binding:nth-child(1)");
            domains.Add(".net.tw", ".form-group:nth-child(2) .ng-binding:nth-child(2)");
            domains.Add(".org.tw", ".form-group:nth-child(2) .ng-binding:nth-child(3)");
            domains.Add(".tw", ".form-group:nth-child(2) .ng-binding:nth-child(5)");
            domains.Add(".com", ".form-group:nth-child(3) .ng-binding:nth-child(1)");
            domains.Add(".net", ".form-group:nth-child(3) .ng-binding:nth-child(2)");
            domains.Add(".org", ".form-group:nth-child(3) .ng-binding:nth-child(3)");
            domains.Add(".cc", ".form-group:nth-child(3) .ng-binding:nth-child(7)");
            return domains;
        }

        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {
            IWebDriver webDriver = _webDriver.Current;
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(string.Format("{0}{1}", webDriver.Url, url));
        }
        
        [Then(@"browser title is (.*)")]
        public void ThenBrowserTitleIs(string title)
        {
            string result = _webDriver.Wait.Until(d => d.Title);
            Assert.AreEqual(title, result);
        }

        [Given(@"I typed the domain name (.*)")]
        public void GivenITypedTheDomainName(string domainName)
        {
            var domainNameTextBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(".form-control")));
            domainNameTextBox.SendKeys("google");
        }

        [Given(@"I choose the domain (.*)")]
        public void GivenIChooseTheDomain(string domain)
        {
            var _com = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_domainIdentifier[domain])));
            _com.Click();
        }

        [When(@"I press the button (.*)")]
        public void WhenIPressTheButton(string buttonName)
        {
            var searchButtom = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(".btn-outline-info")));
            searchButtom.Click();
        }

        [Then(@"The result should be (.*)")]
        public void ThenTheResultShouldBe(string domainStatus)
        {
            var result = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector("td:nth-child(3)")));
            Assert.AreEqual(domainStatus, result.Text);
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            _webDriver.Quit();
        }
    }
}
