using FluentAssertions;
using OpenQA.Selenium;

namespace WebTestBDD.PageObjects;


public abstract class BasePage
{
    private readonly IWebDriver _driver;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Navigate(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void AssertTitle(string title)
    {
        string pageTitle = _driver.Title;
        pageTitle.Should().Be(title);
    }
}