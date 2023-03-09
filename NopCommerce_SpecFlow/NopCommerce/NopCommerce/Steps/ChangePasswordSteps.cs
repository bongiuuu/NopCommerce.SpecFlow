using NopCommerce.Library;
using NopCommerce.Models;
using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class ChangePasswordSteps
    {
        private ChangePasswordPage _changePasswordPage = new ChangePasswordPage(Context.WebDriver);
        private NotificationBar _notificationBar = new NotificationBar(Context.WebDriver);
        private readonly ScenarioContext _scenarioContext;

        public ChangePasswordSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I am in Change Password page")]
        public void IAmInChangePasswordPage()
        {
            _changePasswordPage.GoToChangePasswordPage();
        }
        
        [When("I change old password {string} with new password {string} and confirm password {string}")]
        public void WhenIchangeoldpasswordwithnewpasswordandconfirmpassword(string oldPassword,string newPassword,string confirmNewPassword)
        {
            Account account = (Account)_scenarioContext["account"];
            _scenarioContext["oldPassword"] = oldPassword;
            _scenarioContext["newPassword"] = newPassword;
            _scenarioContext["confirmNewPassword"] = confirmNewPassword;
            _scenarioContext["isOldPasswordMatched"] = (oldPassword.Equals(account.Password)) ? true : false;
            _scenarioContext["isNewPasswordDifferent"] = (!newPassword.Equals(account.Password)) ? true : false;
            
            _changePasswordPage.InputOldPassWord(oldPassword);
            _changePasswordPage.InputNewPassword(newPassword);
            _changePasswordPage.InputConfirmNewPassword(confirmNewPassword);
            _changePasswordPage.ClickChangePasswordButton();
        }

        [When("I click Change password button")]
        public void IClickChangePasswordButton()
        {
            _changePasswordPage.ClickChangePasswordButton();
        }

        [Then("the Change password page displays {string}")]
        [When("the Change password page displays {string}")]
        public void TheChangePasswordPageDisplays(string message)
        {
            string newPassword = (string)_scenarioContext["newPassword"];
            Account account = (Account)_scenarioContext["account"];

            Assert.That(_notificationBar.GetNotificationText(), Is.EqualTo(message));
            account.Password = newPassword;
            account.ConfirmPassword = newPassword;
            _scenarioContext["account"] = account;
        }

        [Then("the Change password page displays error message of {string}, {string}, {string} or {string}")]
        public void TheChangePasswordPageDisplaysErrorMessageOfOr(string errorOldPassword, string errorNewPassword, string errorConfirmNewPassword, string errorChangePassword)
        {
            string oldPassword = (string)_scenarioContext["oldPassword"];
            string newPassword = (string)_scenarioContext["newPassword"];
            string confirmNewPassword = (string)_scenarioContext["confirmNewPassword"];
            
            // ASSERTION - OLD PASSWORD
            if (oldPassword.Trim().Equals(string.Empty))
                Assert.That(_changePasswordPage.GetErrorMessageOldPassword(), Is.EqualTo(errorOldPassword));
            else
                if (!(bool)_scenarioContext["isOldPasswordMatched"])
                    Assert.That(_changePasswordPage.GetErrorMessage(), Is.EqualTo(errorChangePassword));

            // ASSERTION - NEW PASSWORD
            if (newPassword.Trim().Equals(string.Empty) || newPassword.Trim().Length < 6)
                Assert.That(_changePasswordPage.GetErrorMessageNewPassword(), Is.EqualTo(errorNewPassword));
            else
                if (!(bool)_scenarioContext["isNewPasswordDifferent"])
                    Assert.That(_changePasswordPage.GetErrorMessage(), Is.EqualTo(errorChangePassword));

            // ASSERTION - CONFIRM NEW PASSWORD
            if (confirmNewPassword.Trim().Equals(string.Empty) || !confirmNewPassword.Trim().Equals(newPassword.Trim()))
                Assert.That(_changePasswordPage.GetErrorMessageConfirmNewPassword(), Is.EqualTo(errorConfirmNewPassword));
        }
    }
}