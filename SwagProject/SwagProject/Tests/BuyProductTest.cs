using OpenQA.Selenium;
using SwagProject.Driver;
using SwagProject.Page;
using System.Security.Cryptography.X509Certificates;

namespace SwagProject.Tests
{
    public class Tests
    {

        LoginPage loginPage;
        ProductPage productPage;
       
        CardPage cardPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new CardPage();
            
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }


        [Test]
        public void TC01_AddTwoProductInCart_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddShirt.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));
        }

        [Test]
        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.SelectOption("Price (high to low)");

            Assert.That((productPage.SortByPrice.Displayed));
        }
        [Test]
        public void TC03_GoToAboutPage_ShouldRedactionToNewPage() 
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.About.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));

        }

        [Test]
        public void TC04_BuyProducts_ShouldBeFinishedShopping() 
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddShirt.Click();
            productPage.ShoppingCartClick.Click();
            cardPage.Checkout.Click();
            cardPage.FirstName.SendKeys("aa");
            cardPage.LastName.SendKeys("bb");
            cardPage.ZipCode.SendKeys("vv");
            cardPage.ButtonContinue.Submit();
            cardPage.ButtonFinish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER",Is.EqualTo(cardPage.OrderFinished.Text));


        }
       
        

}   }   
        




    
