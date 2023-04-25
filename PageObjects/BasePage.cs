using FluentAssertions;
using OpenQA.Selenium;

namespace WebTestBDD.PageObjects;

/// <summary>
/// Base Page Object
/// </summary>
public abstract class BasePage
{
    private readonly IWebDriver _driver;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Navigate(string url)
    {
        // Set the implicit wait time to 10 seconds
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        _driver.Navigate().GoToUrl(url);
    }

    public void AssertTitle(string title)
    {
        string pageTitle = _driver.Title;
        pageTitle.Should().Be(title);
    }
    
    public void AssertHeader(string header)
    {
        string pageH1= _driver.FindElement(By.XPath("//h1")).Text;
        pageH1.Should().Be(header);
    }
}