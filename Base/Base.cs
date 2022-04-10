using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace NUnitProjectPOM
{
    public enum BrowserType
    {
        chrome,
        firefox
    }

    public class Base 
    {
        public IWebDriver? driver;
        readonly BrowserType _browserType;
        public Base(BrowserType browserType)
        {
            _browserType = browserType;
        }

        public IWebDriver SelectBrowser(BrowserType browser,
            ChromeOptions options) => browser switch
            {
                BrowserType.chrome => driver = new ChromeDriver(options),
                BrowserType.firefox => driver = new FirefoxDriver(),
                _ => throw new NotFoundException("No such browser")
            };


        public void Start()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            driver = SelectBrowser(_browserType, options);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(20);
        }


        private static string Url => 
            TestContext.Parameters["demoqaUrl"]
                ?? throw new NotImplementedException($"key not found.");
    }
}