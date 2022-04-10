using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        public IWebDriver SelectBrowser(BrowserType browser) => browser switch
            {
                BrowserType.chrome => driver = new ChromeDriver(),
                BrowserType.firefox => driver = new FirefoxDriver(),
                _ => throw new NotFoundException("No such browser")
            };

        [SetUp]
        public void Start()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            driver = GetDriver();
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void QuitBrowser()
        {
            driver?.Quit();
        }

        private static string Url => 
            TestContext.Parameters["demoqaUrl"]
                ?? throw new NotImplementedException($"key not found.");

        public IWebDriver GetDriver()=> 
            driver != null ? driver : driver = SelectBrowser(_browserType);
    }
}