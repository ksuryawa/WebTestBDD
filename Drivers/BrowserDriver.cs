using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebTestBDD.Drivers
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable
        {
            private readonly Lazy<IWebDriver> _currentWebDriverLazy;
            private bool _isDisposed;

            public BrowserDriver()
            {
                _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
            }

            /// <summary>
            /// The Selenium IWebDriver instance
            /// </summary>
            public IWebDriver Current => _currentWebDriverLazy.Value;

            /// <summary>
            /// Creates the Selenium web driver (opens a browser)
            /// </summary>
            /// <returns></returns>
            private IWebDriver CreateWebDriver()
            {
                //We use the Chrome browser
                new DriverManager().SetUpDriver(new ChromeConfig(),VersionResolveStrategy.MatchingBrowser);
                
                var chromeDriverService = ChromeDriverService.CreateDefaultService();

                var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("start-maximised");
                
                var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                
                return chromeDriver;
            }

            /// <summary>
            /// Disposes the Selenium webdriver (closing the browser)
            /// </summary>
            public void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                if (_currentWebDriverLazy.IsValueCreated)
                {
                    Current.Quit();
                }

                _isDisposed = true;
            }
        }
    
}