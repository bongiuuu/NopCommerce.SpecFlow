using static NopCommerce.Constants.CompleteResultConstants;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;

using OpenQA.Selenium;
using NopCommerce.Library;

namespace NopCommerce.Pages
{
    public class CompleteResultPage
    {
        public IWebDriver WebDriver;
        private string
            _lblBodyMsgByClassAndTag =
                "//div[contains(@class, 'page-body')]//div[@class='{0}']{1}";

        public CompleteResultPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public string GetMessage(UserAction action)
        {
            return GetTextFromElement(WebDriver, new WebObject(By
                .XPath(string
                    .Format(_lblBodyMsgByClassAndTag,
                    BodyMsgClassNames[action][0],
                    BodyMsgClassNames[action][1])), CompleteResult.Message));
        }
    }
}