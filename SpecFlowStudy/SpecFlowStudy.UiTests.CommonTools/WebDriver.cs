using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowStudy.UiTests.CommonTools
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;
        private WebDriverWait _wait;

        public string _seleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        private string _browserConfig => ConfigurationManager.AppSettings["browser"];

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver != null)
                    return _currentWebDriver;

                _currentWebDriver = GetWebDriver();
                _currentWebDriver.Url = _seleniumBaseUrl;

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
        //TODO: 多瀏覽器測試待寫
        private IWebDriver GetWebDriver()
        {
            DriverOptions desiredCapabilities;
            switch (_browserConfig)
            {
                case "IE":
                    desiredCapabilities = new InternetExplorerOptions();
                    break;
                case "Chrome":
                    desiredCapabilities = new ChromeOptions();
                    break;
                case "Firefox":
                    desiredCapabilities = new FirefoxOptions();
                    break;
                default:
                    throw new NotSupportedException($"{_browserConfig} is not a supported browser");
            }

            return new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["seleniumHub"]), desiredCapabilities);
        }

        public void Quit()
        {
            _currentWebDriver?.Quit();
        }
    }
}
