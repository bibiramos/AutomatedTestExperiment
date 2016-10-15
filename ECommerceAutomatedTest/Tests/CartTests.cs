using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using ECommerceAutomatedTest.Services;
using ECommerceAutomatedTest.Object;
using ECommerceAutomatedTest.Config;

namespace ECommerceAutomatedTest.Tests
{
    [TestFixture]
    public class CartTests : BaseTests
    {
        [Test]
        [TestCase(Browser.Firefox)]
        [TestCase(Browser.Chrome)]
        [TestCase(Browser.InternetExplorer)]
        public void AddItemsToCartAndValidate(
            [Values] Browser browserName)
        {
            IWebDriver webDriver = this.GetDriverByBrowser(browserName);

            TestConfig config = new TestConfig();

            int numberOfItems = config.numberOfItemsOnCart;

            List<ProductObject> products = PurchaseService.AddProductToCart(webDriver, config.searchTerm, numberOfItems);

            List<ProductObject> productsOnCart = PurchaseService.GetProductsOnCart(webDriver, products);

            if (products.Count != productsOnCart.Count)
            {
                webDriver.Quit();

                throw new Exception(string.Format("Some products weren't added to cart! \n Number of items added: {0} \n Number of items found: {1}", products.Count, productsOnCart.Count));
            }

            string exception = null;

            var compareProducts = products.Zip(productsOnCart, (n, w) => new { productAdded = n, productFound = w });

            foreach (var comparision in compareProducts)
            {
                if (comparision.productAdded.Id != comparision.productFound.Id) 
                {
                    exception = exception + string.Format("ID of the product found is different from the product added! \n ID of the product added: {0} \n ID of the product found: {1} \n", comparision.productAdded.Id, comparision.productFound.Id);
                }

                if (!comparision.productAdded.Name.Equals(comparision.productFound.Name)) 
                {
                    exception = exception + string.Format("Name of the product found is different from the product added! \n Name of the product added: {0} \n Name of the product found: {1} \n", comparision.productAdded.Name, comparision.productFound.Name);
                }

                if (comparision.productAdded.Price != comparision.productFound.Price) 
                {
                    exception = exception + string.Format("Price of the product found is different from the product added! \n Price of the product added: {0} \n Price of the product found: {1} \n", comparision.productAdded.Price, comparision.productFound.Price);
                }
            }

            if (exception != null)
            {
                webDriver.Quit();

                throw new Exception(exception);
            }

            webDriver.Quit();
        }
    }
}
