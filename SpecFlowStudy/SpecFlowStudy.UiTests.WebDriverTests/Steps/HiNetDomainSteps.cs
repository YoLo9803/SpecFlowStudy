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
        private readonly WebDriver _webDriver;

        private readonly Dictionary<string, string> _webElementIdentifier;
        public HiNetDomainSteps()
        {
            _webDriver = new WebDriver();
            _webElementIdentifier = initialWebElementIdentifier();
        }

        private Dictionary<string, string> initialWebElementIdentifier()
        {
            Dictionary<string, string> webElements = new Dictionary<string, string>();
            webElements.Add(".com.tw", ".form-group:nth-child(2) .ng-binding:nth-child(1)");
            webElements.Add(".net.tw", ".form-group:nth-child(2) .ng-binding:nth-child(2)");
            webElements.Add(".org.tw", ".form-group:nth-child(2) .ng-binding:nth-child(3)");
            webElements.Add(".tw", ".form-group:nth-child(2) .ng-binding:nth-child(5)");
            webElements.Add(".com", ".form-group:nth-child(3) .ng-binding:nth-child(1)");
            webElements.Add(".net", ".form-group:nth-child(3) .ng-binding:nth-child(2)");
            webElements.Add(".org", ".form-group:nth-child(3) .ng-binding:nth-child(3)");
            webElements.Add(".cc", ".form-group:nth-child(3) .ng-binding:nth-child(7)");
            webElements.Add("IdentityNumber", ".form-group:nth-child(2) .form-control");
            webElements.Add("ChineseName", ".form-group:nth-child(3) .form-control");
            webElements.Add("EnglishFirstName", ".col-sm-12 > .col-sm-3:nth-child(2) > .form-control");
            webElements.Add("EnglishLastName", ".col-sm-3:nth-child(4) > .form-control");
            webElements.Add("PostalCode", ".form-group > .col-sm-3 > .form-control");
            webElements.Add("ChineseAddress", ".col-sm-9 > .form-control");
            webElements.Add("EnglishAddress", ".col-sm-6:nth-child(2) > .form-control");
            webElements.Add("City", ".col-sm-12 > .col-sm-4 > .ng-invalid");
            webElements.Add("ContactNumber", ".form-control:nth-child(2)");
            webElements.Add("Cellphone", ".form-group:nth-child(11) .form-control");
            webElements.Add("Email", ".form-group:nth-child(12) .form-control");
            webElements.Add("BackupEmail", ".form-group:nth-child(13) .form-control");
            webElements.Add("DomainPassword_id", "setpcode");
            webElements.Add("ConfirmDomainPassword_name", "pcode2");
            webElements.Add("電子發票由上方註冊資料帶入", "//div[17]/div/input");
            webElements.Add("網域名稱申購約定條款", "//div[19]/div/input");
            webElements.Add("中華電信個資蒐集告知條款", "//div[20]/div/input");
            webElements.Add("同意推介個人化商品服務", "//div[21]/div[2]/input");
            return webElements;
        }

        [Given(@"I choose the checkBox (.*)")]
        public void GivenIChooseTheCheckBoxElectronicReceipt(string checkBoxName)
        {
            var checkBox = _webDriver.Wait.Until(d => d.FindElement(By.XPath(_webElementIdentifier[checkBoxName])));
            checkBox.Click();
        }


        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {
            IWebDriver webDriver = _webDriver.Current;
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(string.Format("{0}{1}", webDriver.Url, url));
        }
        
        [Then(@"The function title should be (.*)")]
        public void ThenTheFunctionTitleShouldBe(string text)
        {
            var result = _webDriver.Wait.Until(d => d.FindElement(By.XPath("//b/span")));
            Assert.AreEqual(text, result.Text);
        }

        [Given(@"I typed the domain name (.*)")]
        public void GivenITypedTheDomainName(string domainName)
        {
            var domainNameTextBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(".form-control")));
            domainNameTextBox.SendKeys(domainName);
        }

        [Given(@"I choose the domain (.*)")]
        public void GivenIChooseTheDomain(string domain)
        {
            var _com = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier[domain])));
            _com.Click();
        }

        [When(@"I press the button (.*)")]
        public void WhenIPressTheButton(string buttonText)
        {
            var sendingButton = _webDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath(string.Format("//button[contains(.,'{0}')]", buttonText))));
            sendingButton.Click();
        }

        [Given(@"I press the button (.*)")]
        public void GivenIPressTheButton(string buttonText)
        {
            var sendingButton = _webDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath(string.Format("//button[contains(.,'{0}')]", buttonText))));
            sendingButton.Click();
        }

        [Given(@"Enter form details")]
        public void GivenEnterFormDetails(Table table)
        {
            TableRow row = table.Rows.Single();
            IWebElement textBox;
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["IdentityNumber"])));
            textBox.SendKeys(row["IdentityNumber"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["ChineseName"])));
            textBox.SendKeys(row["ChineseName"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["EnglishFirstName"])));
            textBox.SendKeys(row["EnglishFirstName"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["EnglishLastName"])));
            textBox.SendKeys(row["EnglishLastName"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["PostalCode"])));
            textBox.SendKeys(row["PostalCode"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["ChineseAddress"])));
            textBox.SendKeys(row["ChineseAddress"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["EnglishAddress"])));
            textBox.SendKeys(row["EnglishAddress"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["City"])));
            textBox.SendKeys(row["City"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["ContactNumber"])));
            textBox.SendKeys(row["ContactNumber"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["Cellphone"])));
            textBox.SendKeys(row["Cellphone"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["Email"])));
            textBox.SendKeys(row["Email"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector(_webElementIdentifier["BackupEmail"])));
            textBox.SendKeys(row["BackupEmail"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.Id(_webElementIdentifier["DomainPassword_id"])));
            textBox.SendKeys(row["DomainPassword"].ToString());
            textBox = _webDriver.Wait.Until(d => d.FindElement(By.Name(_webElementIdentifier["ConfirmDomainPassword_name"])));
            textBox.SendKeys(row["ConfirmDomainPassword"].ToString());
        }

        [Then(@"The result should be (.*)")]
        public void ThenTheResultShouldBe(string domainStatus)
        {
            var result = _webDriver.Wait.Until(d => d.FindElement(By.CssSelector("td:nth-child(3)")));
            Assert.AreEqual(domainStatus, result.Text);
        }

        [Then(@"The alert message of browser should be (.*)")]
        public void ThenTheAlertMessageOfBrowserShouldBe(string errorMessage)
        {
            var alert = _webDriver.Wait.Until(d => d.SwitchTo().Alert());
            Assert.AreEqual(errorMessage+"\r\n", alert.Text);
            alert.Accept();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            _webDriver.Quit();
        }
    }
}
