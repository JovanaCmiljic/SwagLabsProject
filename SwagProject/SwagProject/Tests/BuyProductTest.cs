using SwagProject.Driver;
using SwagProject.Page;

namespace SwagProject.Tests
{
    public class Tests
    {

        LoginPage loginPage;
        ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();    
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

            Assert.That("2",Is.EqualTo(productPage.Cart.Text));
        }
    }
}