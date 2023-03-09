using NopCommerce.Library;
using OpenQA.Selenium;

using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;

namespace NopCommerce.Pages
{
    public class NotificationBar
    {
        public IWebDriver WebDriver;
        private WebObject _lblNotification = new WebObject(By.XPath("//div[contains(@class, 'bar-notification')]//p"), Notification.Message);
         
        public NotificationBar(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public string GetNotificationText()
        {
            return GetTextFromElement(WebDriver, _lblNotification);
        }
    }
}