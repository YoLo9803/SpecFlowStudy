using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowStudy.UiTests.CommonTools;
using System.Configuration;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowStudy.UiTests.WebDriverTests.Steps
{
    [Binding]
    public class HiNetDomainSteps
    {
        private WebDriver _webDriver;

        public HiNetDomainSteps()
        {
            
        }

        [Given(@"我選擇(.*)瀏覽器")]
        public void Given我選擇瀏覽器(string browserName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            app.Settings["browser"].Value = browserName;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
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
