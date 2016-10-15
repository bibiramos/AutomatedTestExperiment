using ECommerceAutomatedTest.Object;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerceAutomatedTest.Pages
{
    public class ProductPage : Page
    {
        public ProductPage()
            : base()
        { }

        public ProductPage(IWebDriver webDriver)
            : base(webDriver)
        { }

        public ProductObject FillProductInformation()
        {
            ProductObject product = new ProductObject();

            product.Id = GetId();

            product.Name = GetName();

            product.Price = GetPrice();

            return product;
        }

        private int GetId()
        {
            IWebElement element = browser.FindElement(By.CssSelector("span[itemprop=productID]"));

            string result = Regex.Match(element.Text, @"\d+").Value;

            return Int32.Parse(result);
        }

        private string GetName()
        {
            IWebElement element = browser.FindElement(By.CssSelector("b[itemprop=name]"));

            return element.Text;
        }

        private float GetPrice()
        {
            IWebElement element = browser.FindElement(By.CssSelector("i.sale.price"));

            string result = element.Text.Replace(",", ".");

            return float.Parse(result, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void ClickOnButtonAddToCart()
        {
            browser.FindElement(By.CssSelector("a#btnAdicionarCarrinho")).Click();

            WaitDocumentReady();
        }
    }
}
