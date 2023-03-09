using NopCommerce;
using NopCommerce.Library;
using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage = new LoginPage(Context.WebDriver);

        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I am in Login page")]
        public void IAmInLoginPage()
        {
            _loginPage.GoToLoginPage();
        }
        
        [When("I input {string} to Email field")]
        public void IInputToEmailField(string email)
        {
            string userEmail = (email.Equals(string.Empty)) ? string.Empty : _scenarioContext["randomPrefix"].ToString() + email;
            _scenarioContext["isValidEmail"] = (userEmail.IsValidEmail()) ? true : false;
            _loginPage.InputEmail(userEmail); 
        }

        [When("I input {string} to Password field")]
        public void IInputToPasswordField(string password)
        {
            _loginPage.InputPassword(password);
        }
        
        [When("I login with email {string} and password {string}")]
        public void WhenIloginwithemailandpassword(string email,string password)
        {
            string userEmail = (email.Equals(string.Empty)) ? string.Empty : _scenarioContext["randomPrefix"].ToString() + email;
            _scenarioContext["isValidEmail"] = (userEmail.IsValidEmail()) ? true : false;

            _loginPage.InputEmail(userEmail);
            _loginPage.InputPassword(password);
            _loginPage.ClickLoginButton();
        }

        [When("I click Login button")]
        public void IClickLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [When("I log in with {string} and {string}")]
        [Given("I log in with {string} and {string}")]
        public void Iloginwithand(string email, string password)
        {
            _loginPage.GoToLoginPage();
            IInputToEmailField(email);
            IInputToPasswordField(password);
            IClickLoginButton();
        }
        
        [Then("the Login page displays error {string}")]
        public void TheLoginPageDisplaysError(string errorMessage)
        {
            string _errorMessage = (!(bool)_scenarioContext["isValidEmail"]) ? _loginPage.GetEmailErrorMsg() : _loginPage.GetLoginErrorMsg();
            Assert.That(_errorMessage, Is.EqualTo(errorMessage));
        }
    }
}