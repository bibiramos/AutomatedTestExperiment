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
    public class CartPage : Page
    {
        public CartPage()
            : base()
        { }

        public CartPage(IWebDriver webDriver)
            : base(webDriver)
        { }

        public override void GoToPage()
        {
            try
            {
                this.ClickOnCartIcon();
            }
            catch (NoSuchElementException)
            {
                //Driver redirects to main page

                this.GoToMainPage();

                this.ClickOnCartIcon();
            }
        }

        private void ClickOnCartIcon()
        {
            browser.FindElement(By.Id("ctl00_TopBar_TopBar1_lnkCarrinho")).Click();
        }

        public void SetWarranty(ECommerceAutomatedTest.Enum.Enums.Warranty warranty)
        {
            WaitDocumentReady();

            if (browser.FindElement(By.Id("popOverlay")).Displayed)
            {

                switch (warranty)
                {
                    case Enum.Enums.Warranty.NoWarranty:
                        browser.FindElement(By.Id("rbGES_0")).Click();
                        break;
                    case Enum.Enums.Warranty.ToMonths12:
                        browser.FindElement(By.Id("rbGES_12")).Click();
                        break;
                    case Enum.Enums.Warranty.ToMonths24:
                        browser.FindElement(By.Id("rbGES_24")).Click();
                        break;
                    case Enum.Enums.Warranty.ToMonths36:
                        browser.FindElement(By.Id("rbGES_36")).Click();
                        break;
                }

                browser.FindElement(By.Id("btnComprarGarantia")).Click();

                WaitDocumentReady();
            }
        }

        public int GetNumberOfProductsOnCart()
        {
            string script = @"var numberOfItems = 0;
            $('table.cart > tbody').find('tr').each(function()
                {
	                numberOfItems++;
                }
            );

            return numberOfItems";

            return Int32.Parse(this.ExecuteJavaScriptReturnResult(script));
        }

        public ProductObject GetProductInformationOnCart(int positionOnCart)
        {
            ProductObject product = new ProductObject();

            product.Id = GetId(positionOnCart);

            product.Name = GetName(positionOnCart);

            product.Price = GetPrice(positionOnCart);

            return product;
        }

        private int GetId(int positionOnCart)
        {
            string script = @"var ids = new Array();
            $('table.cart > tbody').find('tr').each(function()
                {
	                ids.push($(this).attr('data-idsku'));
                }
            );

            return ids[" + positionOnCart + @"]";

            return Int32.Parse(this.ExecuteJavaScriptReturnResult(script));
        }

        private string GetName(int positionOnCart)
        {
            string script = @"var names = new Array();
            $('table.cart > tbody').find('tr').each(function()
                {
	                names.push($(this).find('td.produto > a > strong').text());
                }
            );
            return names[" + positionOnCart + @"]";

            return this.ExecuteJavaScriptReturnResult(script);
        }

        private float GetPrice(int positionOnCart)
        {
            string script = @"var prices = new Array();
            $('table.cart > tbody').find('tr').each(function()
                {
	                prices.push($(this).find('td.valorUnitario > strong').text());
                }
            );
            return prices[" + positionOnCart + @"]";

            string result = this.ExecuteJavaScriptReturnResult(script);

            result = Regex.Match(result, @"(\d*[,]\d*)").Value;

            result = result.Replace(",", ".");

            return float.Parse(result, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
