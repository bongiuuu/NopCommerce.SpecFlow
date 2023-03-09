using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NopCommerce.Library
{
    public static class BrowserFactory
    {
        public static IWebDriver InitDriver(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return new ChromeDriver(ConfigurationHelper.GetConfigurationByKey(Context.Config, "ChromeFolder"));
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();
                default:
                    throw new ArgumentOutOfRangeException(browserName);
            }
        }
    }
}