using NopCommerce.Library;
using NopCommerce.Models;
using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static NopCommerce.Constants.CompleteResultConstants;
using TechTalk.SpecFlow.Assist;

namespace NopCommerce.Steps
{
    [Binding]
    public class CommonSteps
    {
        private RegisterPage _registerPage = new RegisterPage(Context.WebDriver);
        private CompleteResultPage _completeResultPage = new CompleteResultPage(Context.WebDriver);
        private NotificationBar _notificationBar = new NotificationBar(Context.WebDriver);
        private AlertPopup _alertPopup = new AlertPopup(Context.WebDriver);
        private ProductsContainer _productContainer = new ProductsContainer(Context.WebDriver);
        private readonly ScenarioContext _scenarioContext;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I already have an account with information")]
        public void IAlreadyHaveAnAccountWithInformation(Table table)
        {
            var account = table.CreateInstance<Account>();
            _scenarioContext["randomPrefix"] = "".InitializeUniqueString();
            account.Email = (!account.Email.Equals(string.Empty)) ? _scenarioContext["randomPrefix"].ToString() + account.Email : string.Empty;
            _scenarioContext["account"] = account;

            _registerPage.RegisterAnAccount(account);
        }


        [Given("the system already had an account with information")]
        public void TheSystemAlreadyHadAnAccountWithInformation(Table table)
        {
            var account = table.CreateInstance<Account>();
            _scenarioContext["_randomPrefix"] = "".InitializeUniqueString();
            account.Email = (!account.Email.Equals(string.Empty)) ? _scenarioContext["_randomPrefix"].ToString() + account.Email : string.Empty;
            _scenarioContext["_account"] = account;

            _registerPage.RegisterAnAccount(account);
        }

        [Then("the system displays {string}")]
        public void TheSystemDisplays(string message)
        {
            Assert.That(_completeResultPage.GetMessage(UserAction.Register), Is.EqualTo(message));
        }

        [Then("the notification shows a message {string}")]
        public void TheNotificationShowsAMessage(string message)
        {
            Assert.That(_notificationBar.GetNotificationText(), Is.EqualTo(message));
        }

        [When("the system displays an alert message {string}")]
        [Then("the system displays an alert message {string}")]
        public void Thenthesystemdisplaysanalertmessage(string message)
        {
            Assert.That(_alertPopup.GetAlertMessage(), Is.EqualTo(message));
        }

        [When("I click OK button on alert")]
        public void WhenIclickOKbuttononalert()
        {
            _alertPopup.ClickOk();
        }

        [When("I click Cancel button on alert")]
        public void WhenIclickCancelbuttononalert()
        {
            _alertPopup.ClickCancel();
        }

        [When("I refresh the page")]
        public void WhenIrefreshthepage()
        {
            _productContainer.RefreshPage();
        }
    }
}