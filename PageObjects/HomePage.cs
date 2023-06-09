using OpenQA.Selenium;
using WebTestBDD.Helpers;

namespace WebTestBDD.PageObjects;


public class HomePage : BasePage
{
    private readonly IWebDriver _driver;

    public HomePage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    #region Locators

    private readonly By _addToCartButtons = By.XPath("//*[contains(@href,'?add-to-cart=')]");
    private readonly By _buttonAddToCart = By.XPath("//a[normalize-space()='Cart']");
    #endregion
    
    #region Actions

    public void AddRandomItemsToCart(int itemCount)
    {
        var items = _driver.FindElements(_addToCartButtons);
        
        for (int i = 0; i < itemCount && i < items.Count; i++)
        {
            items[GenerateUniqueRandomData.GetUniqueNumber(items.Count)].Click();
        }
    }

    public void ViewCart()
    {
        _driver.FindElement(_buttonAddToCart).Click();
    }

    #endregion
}
