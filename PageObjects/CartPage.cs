using OpenQA.Selenium;

namespace WebTestBDD.PageObjects;

/// <summary>
/// Page Object for CartPage
/// </summary>
public class CartPage : BasePage
{
    //The Selenium web driver to automate the browser
    private readonly IWebDriver _driver;

    public CartPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    private IWebElement lowestPriceItem;
    
    #region Locators
    private readonly By _trTotalCartRow =
        By.XPath("//table[@class='shop_table shop_table_responsive cart woocommerce-cart-form__contents']/tbody/tr");

    private readonly By _trQuantity =
        By.XPath("//*[@class='product-quantity']/div/input");
    private readonly By _tdRemoveButton = By.XPath("//td[@class='product-remove']/a");
    private readonly By _tdPrice = By.XPath("//td[@class='product-remove']/following-sibling::td[3]");
    #endregion

    #region Actions

    public int GetCartItemCount()
    {
        /*var itemList = _driver.FindElements(_trTotalCartRow);
        return itemList.Count - 1;*/

        int totalNoOfItemsInCart = 0;
        var listOfQuantity = _driver.FindElements(_trQuantity);
        if (listOfQuantity.Count > 0)
        {
            foreach (var quantity in listOfQuantity)
            {
                totalNoOfItemsInCart= totalNoOfItemsInCart + int.Parse(quantity.GetAttribute("value"));
            }
        }

        return totalNoOfItemsInCart;
    }

    public void SearchForLowestPriceItem()
    {
        var removeItems = _driver.FindElements(_tdRemoveButton);
        var priceItems = _driver.FindElements(_tdPrice);
        if (removeItems.Count > 0)
        {
            var minPrice = float.MaxValue;
          
            int index = 0;
            foreach (var removeItem in removeItems)
            {
                var oldPrice = priceItems[index]
                    .Text
                    .Replace("$", "");
                var price = float.Parse(oldPrice);
                
                if (price < minPrice)
                {
                    minPrice = price;
                    lowestPriceItem = removeItem;

                }

                index++;
            }

        }
    }

    public void RemoveLowestPriceItem()
    {
        lowestPriceItem?.Click();
    }


    #endregion
}
