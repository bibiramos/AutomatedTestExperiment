using ECommerceAutomatedTest.Object;
using ECommerceAutomatedTest.Pages;
using ECommerceAutomatedTest.Enum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAutomatedTest.Services
{
    public static class PurchaseService
    {
        public static List<ProductObject> AddProductToCart(IWebDriver browser, string itemToSearch, int numberOfItems, ECommerceAutomatedTest.Enum.Enums.Warranty warranty = ECommerceAutomatedTest.Enum.Enums.Warranty.NoWarranty)
        {
            MainPage mainPage = new MainPage(browser);

            mainPage.GotoPage();

            mainPage.ClosePopUp();

            List<ProductObject> products = new List<ProductObject>();

            for (int i = 0; i < numberOfItems; i++)
            {
                mainPage.GoToMainPage();

                mainPage.SearchItem(itemToSearch);

                mainPage.ClickOnItemOfSearch(i);

                products.Add(ProductService.GetProduct(browser));

                ProductService.AddToCart(browser, warranty);
            }

            return products;
        }

        public static List<ProductObject> GetProductsOnCart(IWebDriver browser, List<ProductObject> productsIds)
        {
            CartPage cartPage = new CartPage(browser);

            cartPage.GoToPage();

            int numberOfProducts = cartPage.GetNumberOfProductsOnCart();

            List<ProductObject> products = new List<ProductObject>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                products.Add(cartPage.GetProductInformationOnCart(i));
            }

            return products;
        }
    }
}
