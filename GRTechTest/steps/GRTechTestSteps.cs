using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GRTechTest.extensionMethods;
using NUnit.Framework;
using System.Threading;

namespace GRTechTest.steps
{
    [Binding]
    public class BasicSearchTestSteps
    {
        IndexPage           _pgIndex        = new IndexPage();
        ResultsPage         _pgResults      = new ResultsPage();
        DetailPage          _pgDetail       = new DetailPage();
        SubTotalPage        _pgSubTotal     = new SubTotalPage();
        ShoppingCartPage    _pgShoppingCart = new ShoppingCartPage();
        public IWebDriver   _driver = new ChromeDriver();
        [Given(@"I am on Amazon")]
        public void GivenIAmOnAmazon()
        {
            _driver.Url = "https://www.amazon.com/";
            _driver.Manage().Window.Maximize();
        }
        
        [When(@"I search for a (.*)")]
        public void WhenISearchForA(string product)
        {
            _driver.XSet(_pgIndex.txtSearch, product);
            _driver.XEnter(_pgIndex.txtSearch);
        }
        
        [Then(@"I recieve results for that (.*)")]
        public void ThenIRecieveResultsForThat(string product)
        {
            Assert.IsTrue(_driver.XCount(_pgResults.lblResults) > 0);
        }
        
        [Then(@"I end my test")]
        public void ThenIEndMyTest()
        {
            _driver.Quit();
        }
        [When(@"I add (.*) products")]
        public void WhenIAddProducts(int num)
        {
            addItem("LG 24UD58-B");
            addItem("Metasploit: The Penetration Tester's Guide");
            addItem("Surprise Cat Coffee Mug");
        }

        private void addItem(string item)
        {
            _driver.XSet(_pgIndex.txtSearch, item);
            _driver.XEnter(_pgIndex.txtSearch);
            _driver.XClick(_pgResults.getItem(item));
            _driver.XClick(_pgDetail.btnAddToCart);
            Thread.Sleep(2000);
            if (_driver.XCount(_pgDetail.btnClosePopUp) > 0)
            {
                _driver.XClick(_pgDetail.btnClosePopUp);
            }            
        }

        [Then(@"I see my products in my shopping cart")]
        public void ThenISeeMyProductsInMyShoppingCart()
        {
            Assert.IsTrue(_driver.XCount(_pgSubTotal.getCartItemCount("3")) > 0);
            _driver.XClick(_pgSubTotal.btnCart);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getCartItemCount("3")) > 0);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getItem("LG 24UD58-B")) > 0);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getItem("Metasploit: The Penetration Tester's Guide")) > 0);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getItem("Surprise Cat Coffee Mug")) > 0);
        }

        [Then(@"if I remove an item")]
        public void ThenIfIRemoveAnItem()
        {
            _driver.XClick(_pgShoppingCart.btnDeleteItem("LG 24UD58-B"));
        }

        [Then(@"I will not see the deleted item")]
        public void ThenIWillNotSeeTheDeletedItem()
        {
            Thread.Sleep(2000);
            Assert.IsFalse(_driver.XCount(_pgShoppingCart.getCartItemCount("3")) > 0);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getCartItemCount("2")) > 0);
            Assert.IsFalse(_driver.XCount(_pgShoppingCart.getItem("LG 24UD58-B")) > 0);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getItem("Metasploit: The Penetration Tester's Guide")) > 0);
            Assert.IsTrue(_driver.XCount(_pgShoppingCart.getItem("Surprise Cat Coffee Mug")) > 0);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
