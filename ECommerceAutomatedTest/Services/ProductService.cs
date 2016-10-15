using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ECommerceAutomatedTest.Pages;
using ECommerceAutomatedTest.Object;

namespace ECommerceAutomatedTest.Services
{
    public class ProductService
    {
        public static ProductObject GetProduct(IWebDriver browser)
        {
            ProductPage page = new ProductPage(browser);

            ProductObject product = new ProductObject();

            product = page.FillProductInformation();

            return product;
        }

        public static void AddToCart(IWebDriver browser, ECommerceAutomatedTest.Enum.Enums.Warranty warranty)
        {
            ProductPage productPage = new ProductPage(browser);

            productPage.ClickOnButtonAddToCart();

            CartPage cartPage = new CartPage(browser);

            cartPage.SetWarranty(warranty);
        }
    }
}
