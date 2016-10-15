using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ECommerceAutomatedTest.Tests
{
    public class BaseTests
    {
        public IWebDriver GetDriverByBrowser(Browser browserName)
        {
            string directory = Directory.GetCurrentDirectory() + @"\Dependencies";

            switch (browserName)
            {
                case Browser.Firefox:

                    return new FirefoxDriver();

                case Browser.Chrome:

                    return new ChromeDriver(directory); 

                case Browser.InternetExplorer:

                    return new InternetExplorerDriver(directory); 

                default:

                    throw new NotImplementedBrowserException("Browser not implemented yet.");
            }
        }
    }

    public enum Browser
    {
        Firefox,

        Chrome,

        InternetExplorer
    }
}
