using OpenQA.Selenium;
using static NopCommerce.Library.DriverUtils;

namespace NopCommerce.Pages
{
    public class AlertPopup
    {
        public IWebDriver WebDriver;
        public AlertPopup(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public string GetAlertMessage()
        {
            return WebDriver.SwitchTo().Alert().Text;
        }

        public void ClickOk()
        {
            WebDriver.SwitchTo().Alert().Accept();
        }

        public void ClickCancel()
        {
            WebDriver.SwitchTo().Alert().Dismiss();
        }
    }
}