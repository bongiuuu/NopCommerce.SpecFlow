using NopCommerce.Library;
using NUnit.Framework;
using Newtonsoft.Json;
using NopCommerce.Models;
using NopCommerce.Pages;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private RegisterPage
            _registerPage = new RegisterPage(Context.WebDriver);

        private readonly ScenarioContext _scenarioContext;

        public RegisterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I am in Register page")]
        public void IAmInRegisterPage()
        {
            _registerPage.GoToRegisterPage();
        }

        public void PreStepForRegister(Table table)
        {
            Account account =
                JsonConvert
                    .DeserializeObject<Account>(TableExtension.ToJson(table));
            account.Email = (!account.Email.Equals("")) ? (string)_scenarioContext["randomPrefix"] + account.Email : "";
            _scenarioContext["account"] = account;

            _registerPage.FillRegisterFields(account);
        }

        [When("I fill account information")]
        public void Ifillaccountinformation(Table table)
        {
            _scenarioContext["randomPrefix"] = "".InitializeUniqueString();
            PreStepForRegister(table);
        }

        [When("I click Register button")]
        public void IclickRegisterbutton()
        {
            _registerPage.ClickRegisterButton();
        }

        [When("I register an account with email existed in the system")]
        public void IRegisterAnAccountWithEmailExistedInTheSystem(Table table)
        {
            PreStepForRegister(table);
            _registerPage.ClickRegisterButton();
        }

        [Then("the system displays error message on fields {string}, {string}, {string}, {string}, {string}")]
        public void TheSystemDisplaysErrorMessageOnFields(string errorFirstname, string errorLastname, string errorEmail, string errorPassword, string errorConfirmPassword)
        {
            Account account = (Account)_scenarioContext["account"];
            if (account.Firstname.Equals(string.Empty))
                Assert.That(_registerPage.GetErrorMsgFirstName(), Is.EqualTo(errorFirstname));

            if (account.Lastname.Equals(string.Empty))
                Assert.That(_registerPage.GetErrorMsgLastName(), Is.EqualTo(errorLastname));

            if (account.Email.Equals(string.Empty) || !account.Email.IsValidEmail())
                Assert.That(_registerPage.GetErrorMsgEmail(), Is.EqualTo(errorEmail));

            if (account.Password.Equals(string.Empty))
                Assert.That(_registerPage.GetErrorMsgPassword(), Is.EqualTo(errorPassword));
            else if (account.Password.Length < 6)
                Assert.That(_registerPage.GetErrorMsgPasswordForm(), Is.EqualTo(errorPassword));

            if (account.ConfirmPassword.Equals(string.Empty) || !account.ConfirmPassword.Equals(account.Password))
                Assert.That(_registerPage.GetErrorMsgConfirmPassword(), Is.EqualTo(errorConfirmPassword));
        }

        [Then("the Register page displays error {string}")]
        public void TheRegisterPageDisplaysError(string message)
        {
            Assert.That(_registerPage.GetErrorMessage(), Is.EqualTo(message));
        }
    }
}