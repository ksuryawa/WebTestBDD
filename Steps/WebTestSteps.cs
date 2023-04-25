using NUnit.Framework;
using WebTestBDD.Drivers;
using WebTestBDD.PageObjects;

namespace WebTestBDD.Steps;


[Binding]
public class WebTestSteps
{
       private readonly HomePage _homePage;
        private readonly CartPage _cartPage;
        
       public WebTestSteps(BrowserDriver browserDriver)
       {
            _homePage = new HomePage(browserDriver.Current);
            _cartPage = new CartPage(browserDriver.Current);
        }
      
        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            // Navigate to shopping page
            //_homePage.Navigate(AppSettings.ApplicationUrl);
            _homePage.Navigate("https://cms.demo.katalon.com/");
            
            // Add Random items
            _homePage.AddRandomItemsToCart(4);
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            // Navigate to cart page
            _homePage.ViewCart();
        }

        [Then(@"I should see four items in my cart")]
        public void ThenIShouldSeeFourItemsInMyCart()
        {
            // Verify four items are in cart
            Assert.AreEqual(4, _cartPage.GetCartItemCount());
        }

        [When(@"I search for the lowest price item")]
        public void WhenISearchForTheLowestPriceItem()
        {
            _cartPage.SearchForLowestPriceItem();
        }

        [When(@"I remove the lowest price item from my cart")]
        public void WhenIRemoveTheLowestPriceItemFromMyCart()
        {
            _cartPage.RemoveLowestPriceItem();
        }

        [Then(@"I should see three items in my cart")]
        public void ThenIShouldSeeThreeItemsInMyCart()
        {
            Assert.AreEqual(3, _cartPage.GetCartItemCount());
        }
       
}
