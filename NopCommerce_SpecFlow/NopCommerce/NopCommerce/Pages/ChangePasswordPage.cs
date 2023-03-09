using NopCommerce.Constants;
using NopCommerce.Library;
using OpenQA.Selenium;

using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class ChangePasswordPage
    {
        public IWebDriver WebDriver;
        private WebObject _lblErrorMessage = new WebObject(By.XPath("//div[contains(@class,'message-error')]//li"), ChangePassword.ErrorMessage);
        private WebObject _txtOldPassword = new WebObject(By.Id("OldPassword"), ChangePassword.OldPassword);
        private WebObject _lblErrorOldPassword = new WebObject(By.Id("OldPassword-error"), ChangePassword.ErrorOldPassword);
        private WebObject _txtNewPassword = new WebObject(By.Id("NewPassword"), ChangePassword.NewPassword);
        private WebObject _lblErrorNewPassword = new WebObject(By.Id("NewPassword-error"), ChangePassword.ErrorNewPassword);
        private WebObject _lblErrorNewPassword1 = new WebObject(By.XPath("//span[@data-valmsg-for='NewPassword']//p"), ChangePassword.ErrorNewPasswordLine1);
        private WebObject _lblErrorNewPassword2 = new WebObject(By.XPath("//span[@data-valmsg-for='NewPassword']//li"), ChangePassword.ErrorNewPasswordLine2);
        private WebObject _txtConfirmNewPassword = new WebObject(By.Id("ConfirmNewPassword"), ChangePassword.ConfirmNewPassword);
        private WebObject _lblErrorConfirmNewPassword = new WebObject(By.Id("ConfirmNewPassword-error"), ChangePassword.ErrorConfirmNewPassword);
        private WebObject _btnChangePassword = new WebObject(By.XPath("//button[contains(@class, 'change-password-button')]"), ChangePassword.ButtonChangePassword);

        public ChangePasswordPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void GoToChangePasswordPage()
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + UrlConstants.ChangePasswordEndpoint);
        }

        public string GetErrorMessage()
        {
            return GetTextFromElement(WebDriver, _lblErrorMessage);
        }
        
        public void InputOldPassWord(string password)
        {
            InputElement(WebDriver, _txtOldPassword, password);
        }

        public string GetErrorMessageOldPassword()
        {
            return GetTextFromElement(WebDriver, _lblErrorOldPassword);
        }

        public void InputNewPassword(string password)
        {
            InputElement(WebDriver, _txtNewPassword, password);
        }

        public string GetErrorMessageNewPassword()
        {
            return GetTextFromElement(WebDriver, _lblErrorNewPassword).Replace("\r\n", "");
        }

        public string GetErrorMessageNewPasswordForm()
        {
            string message = GetTextFromElement(WebDriver, _lblErrorNewPassword1) + GetTextFromElement(WebDriver, _lblErrorNewPassword2);
            return message.Replace("\n", "");
        }

        public void InputConfirmNewPassword(string password)
        {
            InputElement(WebDriver, _txtConfirmNewPassword, password);
        }

        public string GetErrorMessageConfirmNewPassword()
        {
            return GetTextFromElement(WebDriver, _lblErrorConfirmNewPassword);
        }

        public void ClickChangePasswordButton()
        {
            ClickElement(WebDriver, _btnChangePassword);
        }
    }
}