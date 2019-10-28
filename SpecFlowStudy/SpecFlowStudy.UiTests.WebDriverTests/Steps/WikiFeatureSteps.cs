using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowStudy.UiTests.WebDriverTests.Steps
{
    [Binding]
    public class WikiFeatureSteps
    {
        private readonly ChromeDriver _chromeDriver;

        public WikiFeatureSteps()
        {
            _chromeDriver = new ChromeDriver();
        }

        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {
            _chromeDriver.Manage().Window.Maximize();
            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];
            _chromeDriver.Navigate().GoToUrl(string.Format("{0}{1}", baseUrl, url));
        }
        
        [Then(@"browser title is (.*)")]
        public void ThenBrowserTitleIs(string title)
        {
            var result = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(10)).Until(d => d.Title);
            Assert.AreEqual(title, result);
        }

        [AfterScenario]
        public void CloseBrowserAfterTest()
        {
            _chromeDriver.Quit();
        }
    }
}
