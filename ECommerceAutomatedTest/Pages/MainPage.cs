using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceAutomatedTest.Pages
{
    public class MainPage : Page
    {
        public MainPage(IWebDriver webDriver)
            : base(webDriver)
        { }

        public MainPage() { }

        public void GotoPage()
        {
            this.GoToMainPage();
        }

        public void SearchItem(string term)
        {
            browser.FindElement(By.Id("sli_search_1")).SendKeys(term);

            browser.FindElement(By.Id("ctl00_Conteudo_PaginaSistemaArea1_ctl15_btnOK")).Click();
        }

        public void ClosePopUp()
        {
            if (this.IsPopUpShown())
            {
                browser.FindElement(By.ClassName("fechar-porteiro")).Click();
            }
        }

        private bool IsPopUpShown()
        {
            return browser.FindElement(By.ClassName("bg-alpha-porteiro")).Displayed;
        }

        public void ClickOnItemOfSearch(int position)
        {
            //browser.FindElement(By.CssSelector(".telefonescelulares.first:first-child > .hproduct > .link > h2")).Click();

            string script = @"var item = " + position + @";
            $('.vitrineProdutos > li').each(function(i)
                {
	                if (i == item)
	                {
		                $(this).find('div').find('a.link')[0].click();
	                }
                }
            );";

            try
            {
                this.ExecuteJavaScript(script);
            }
            catch (Exception)
            {
                throw new Exception("No products were found after search! Try using another search term.");
            }

            this.WaitDocumentReady();
        }
    }
}
