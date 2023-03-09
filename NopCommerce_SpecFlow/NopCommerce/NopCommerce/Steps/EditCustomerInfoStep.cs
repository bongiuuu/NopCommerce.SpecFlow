using Newtonsoft.Json;
using NopCommerce.Library;
using NopCommerce.Models;
using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class EditCustomerInfoStep
    {
        private RegisterPage _registerPage = new RegisterPage(Context.WebDriver);
        private EditCustomerInfoPage _editCustomerInfoPage = new EditCustomerInfoPage(Context.WebDriver);

        private readonly ScenarioContext _scenarioContext;

        public EditCustomerInfoStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I am in Edit customer page")]
        public void IAmInEditCustomerPage()
        {
            _editCustomerInfoPage.GoToEditCustomerPage();
        }

        [When("I input values to address fields")]
        public void IInputValuesToFields(Table table)
        {
            Account oldAccountInfo = (Account)_scenarioContext["account"];
            Account newAccountInfo = JsonConvert.DeserializeObject<Account>(TableExtension.ToJson(table));
            string newEmail = (newAccountInfo.Email.Equals(string.Empty)) ? string.Empty : _scenarioContext["randomPrefix"].ToString() + newAccountInfo.Email; 

            // UPDATE NEW ACCOUNT INFORMATOIN IF VALID DATA
            if (!newAccountInfo.Gender.Equals(string.Empty))
                oldAccountInfo.Gender = newAccountInfo.Gender;

            if (!newAccountInfo.Firstname.Equals(string.Empty))
                oldAccountInfo.Firstname = newAccountInfo.Firstname;

            if (!newAccountInfo.Lastname.Equals(string.Empty))
                oldAccountInfo.Lastname = newAccountInfo.Lastname;
            
            if (!newAccountInfo.Birthday.Equals(string.Empty))
                oldAccountInfo.Birthday = newAccountInfo.Birthday;

            if (newAccountInfo.Email.IsValidEmail() && !newEmail.Equals(oldAccountInfo.Email))
                oldAccountInfo.Email = newEmail;
                newAccountInfo.Email = newEmail;

            if (!newAccountInfo.CompanyName.Equals(string.Empty))
                oldAccountInfo.CompanyName = newAccountInfo.CompanyName;

            _scenarioContext["account"] = oldAccountInfo;
            _scenarioContext["newAccountInfo"] = newAccountInfo;

            _editCustomerInfoPage.FillEditCustomerInfoFields(newAccountInfo);
        }

        [When("I input an existed email {string} to email field")]
        public void IInputAnExistedEmailToEmailField(string email)
        {
            _editCustomerInfoPage.InputEmail(_scenarioContext["_randomPrefix"].ToString() + email);
        }

        [When("I click Save button")]
        public void WhenIClickSaveButton()
        {
            _editCustomerInfoPage.ClickSaveButton();
        }

        [Then("the system displays error message on fields {string}, {string}, {string}")]
        public void TheSystemDisplaysErrorMessageOnFields(string errorFirstname, string errorLastname, string errorEmail)
        {
            Account account = (Account)_scenarioContext["newAccountInfo"];
            if (account.Firstname.Equals(string.Empty))
                Assert.That(_registerPage.GetErrorMsgFirstName(), Is.EqualTo(errorFirstname));

            if (account.Lastname.Equals(string.Empty))
                Assert.That(_registerPage.GetErrorMsgLastName(), Is.EqualTo(errorLastname));

            if (!account.Email.IsValidEmail())
                Assert.That(_registerPage.GetErrorMsgEmail(), Is.EqualTo(errorEmail));
        }

        [Then("the Edit information page displays error {string}")]
        public void TheEditInformationPageDisplaysError(string message)
        {
            Assert.That(_editCustomerInfoPage.GetErrorMessage(), Is.EqualTo(message));
        }
    }
}