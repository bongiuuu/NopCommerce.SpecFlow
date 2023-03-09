using NopCommerce.Constants;
using NopCommerce.Library;
using OpenQA.Selenium;

using static NopCommerce.Context;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;

namespace NopCommerce.Pages
{
    public class LoginPage
    {
        public IWebDriver WebDriver;
        private WebObject _lblSummaryErrorMsg = new WebObject(By.XPath("//div[@class='message-error validation-summary-errors']"), UserAddressField.ErrorLogin);
        private WebObject _txtEmail = new WebObject(By.Id("Email"), UserAddressField.Email);
        private WebObject _lblErrorEmail = new WebObject(By.Id("Email-error"), UserAddressField.ErrorEmail);
        private WebObject _txtPassword = new WebObject(By.Id("Password"), UserAddressField.Password);
        private WebObject _btnLogin = new WebObject(By.XPath("//button[text()='Log in']"), UserAddressField.ButtonLogin);

        public LoginPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void GoToLoginPage()
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + UrlConstants.LoginEndpoint);
        }

        public string GetLoginErrorMsg()
        {
            return GetTextFromElement(WebDriver, _lblSummaryErrorMsg).Replace("\r\n", "");
        }

        public void InputEmail(string email)
        {
            InputElement (WebDriver, _txtEmail, email);
        }

        public string GetEmailErrorMsg()
        {
            return GetTextFromElement(WebDriver, _lblErrorEmail);
        }

        public void InputPassword(string password)
        {
            InputElement (WebDriver, _txtPassword, password);
        }

        public void ClickLoginButton()
        {
            ClickElement (WebDriver, _btnLogin);
        }
    }
}