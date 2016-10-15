using ECommerceAutomatedTest.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceAutomatedTest.Pages
{
    public class Page
    {
        protected IWebDriver browser;

        public Page(IWebDriver webDriver)
        {
            browser = webDriver;
        }

        public Page() { }

        public void WaitDocumentReady()
        {
            TestConfig config = new TestConfig();

            browser.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(config.driverWaitTimeoutInSeconds));
        }

        public virtual void GoToPage() { }

        public void GoToMainPage()
        {
            TestConfig config = new TestConfig();

            if (browser.Url != config.siteUrl)
            {
                browser.Url = config.siteUrl;

                browser.Navigate();

                this.WaitDocumentReady();
            }
        }

        public void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor js = browser as IJavaScriptExecutor;

            js.ExecuteScript(script);
        }

        public string ExecuteJavaScriptReturnResult(string script)
        {
            IJavaScriptExecutor js = browser as IJavaScriptExecutor;

            object result = js.ExecuteScript(script);

            return Convert.ToString(result);
        }

        public void WaitUntilTrue(string condition)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));

            wait.Until(browser1 => ((IJavaScriptExecutor)browser).ExecuteScript(condition).Equals("true"));
        }

    }
}
