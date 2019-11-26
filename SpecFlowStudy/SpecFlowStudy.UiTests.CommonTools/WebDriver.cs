using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowStudy.UiTests.CommonTools
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;
        private WebDriverWait _wait;

        public string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver == null)
                {
                    _currentWebDriver = new ChromeDriver { Url = SeleniumBaseUrl };
                }

                return _currentWebDriver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                if (_wait == null)
                {
                    this._wait = new WebDriverWait(Current, TimeSpan.FromSeconds(10));
                }
                return _wait;
            }
        }

        public void Quit()
        {
            _currentWebDriver?.Quit();
        }
    }
}