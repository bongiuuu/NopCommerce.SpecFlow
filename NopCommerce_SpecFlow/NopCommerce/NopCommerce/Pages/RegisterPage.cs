using NopCommerce.Constants;
using NopCommerce.Library;
using NopCommerce.Models;
using OpenQA.Selenium;

using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class RegisterPage
    {
        public IWebDriver WebDriver;
        private WebObject
            _lblErrorMessage =
                new WebObject(By.XPath("//div[contains(@class, 'message-error')]//li"), UserAddressField.ErrorRegister);

        private String
            _radBtnGender = @"//label[contains(@for, 'gender') and text()='{0}']";

        private WebObject _txtFirstName = new WebObject(By.Id("FirstName"), UserAddressField.FirstName);

        private WebObject _lblErrorFirstName = new WebObject(By.Id("FirstName-error"), UserAddressField.ErrorFirstName);

        private WebObject _txtLastName = new WebObject(By.Id("LastName"), UserAddressField.LastName);

        private WebObject _lblErrorLastName = new WebObject(By.Id("LastName-error"), UserAddressField.ErrorLastName);

        private WebObject
            _ddlBirthdayDay = new WebObject(By.XPath("//select[@name='DateOfBirthDay']"), UserAddressField.Day);

        private WebObject
            _ddlBirthdayMonth = new WebObject(By.XPath("//select[@name='DateOfBirthMonth']"), UserAddressField.Month);

        private WebObject
            _ddlBirthdayYear = new WebObject(By.XPath("//select[@name='DateOfBirthYear']"), UserAddressField.Year);

        private WebObject _txtEmail = new WebObject(By.Id("Email"), UserAddressField.Email);

        private WebObject _lblErrorEmail = new WebObject(By.Id("Email-error"), UserAddressField.ErrorEmail);

        private WebObject _txtCompany = new WebObject(By.Id("Company"), UserAddressField.Company);

        private WebObject _txtPassword = new WebObject(By.Id("Password"), UserAddressField.Password);

        private WebObject _lblErrorPassword = new WebObject(By.Id("Password-error"), UserAddressField.ErrorPassword);

        private WebObject
            _lblErrorPasswordForm1 =
                new WebObject(By.XPath("//span[@id='Password-error']//p"), UserAddressField.ErrorPasswordLine1);

        private WebObject
            _lblErrorPasswordFrom2 =
                new WebObject(By.XPath("//span[@id='Password-error']//li"), UserAddressField.ErrorPasswordLine2);

        private WebObject _txtConfirmPassword = new WebObject(By.Id("ConfirmPassword"), UserAddressField.ConfirmPassword);

        private WebObject _lblErrorConfirmPassword = new WebObject(By.Id("ConfirmPassword-error"), UserAddressField.ConfirmPassword);

        private WebObject _btnRegister = new WebObject(By.Name("register-button"), UserAddressField.ButtonRegister);

        public RegisterPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void GoToRegisterPage()
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + UrlConstants.RegisterEndpoint);
        }

        public string GetErrorMessage()
        {
            return GetTextFromElement(WebDriver, _lblErrorMessage);
        }

        public void SelectGender(string gender)
        {
            var _gender = "" + gender;
            if (!_gender.Equals(""))
            {
                ClickElement(WebDriver, new WebObject(By.XPath(string.Format(_radBtnGender, gender)), UserAddressField.RadioButtonGender));
            }
        }

        public void InputFirstName(string firstName)
        {
            InputElement (WebDriver, _txtFirstName, firstName);
        }

        public string GetErrorMsgFirstName()
        {
            return GetTextFromElement(WebDriver, _lblErrorFirstName);
        }

        public void InputLastName(string lastName)
        {
            InputElement (WebDriver, _txtLastName, lastName);
        }

        public string GetErrorMsgLastName()
        {
            return GetTextFromElement(WebDriver, _lblErrorLastName);
        }

        public void SelectDay(string dateOfBirth)
        {
            var _dateOfBirth = "" + dateOfBirth;
            if (!_dateOfBirth.Equals(""))
            {
                string day = dateOfBirth.Split("/")[0].TrimStart(new Char[] { '0' } );
                SelectDropDownListByValue (WebDriver, _ddlBirthdayDay, day);
            }
        }

        public void SelectMonth(string dateOfBirth)
        {
            var _dateOfBirth = "" + dateOfBirth;
            if (!_dateOfBirth.Equals(""))
            {
                string month = dateOfBirth.Split("/")[1].TrimStart(new Char[] { '0' } );
                SelectDropDownListByValue (WebDriver, _ddlBirthdayMonth, month);
            }
        }

        public void SelectYear(string dateOfBirth)
        {
            var _dateOfBirth = "" + dateOfBirth;
            if (!_dateOfBirth.Equals(""))
            {
                string year = dateOfBirth.Split("/")[2].TrimStart(new Char[] { '0' } );
                SelectDropDownListByValue (WebDriver, _ddlBirthdayYear, year);
            }
        }

        public void SelectBirthday(string dateOfBirth)
        {
            SelectDay (dateOfBirth);
            SelectMonth (dateOfBirth);
            SelectYear (dateOfBirth);
        }

        public void InputEmail(string email)
        {
            InputElement (WebDriver, _txtEmail, email);
        }

        public string GetErrorMsgEmail()
        {
            return GetTextFromElement(WebDriver, _lblErrorEmail);
        }

        public void InputCompany(string company)
        {
            var _company = "" + company;
            if (!_company.Equals(""))
            {
                InputElement (WebDriver, _txtCompany, company);
            }
        }

        public void InputPassword(string password)
        {
            InputElement (WebDriver, _txtPassword, password);
        }

        public string GetErrorMsgPassword()
        {
            return GetTextFromElement(WebDriver, _lblErrorPassword);
        }

        public string GetErrorMsgPasswordForm()
        {
            string message = GetTextFromElement(WebDriver, _lblErrorPasswordForm1) + GetTextFromElement(WebDriver, _lblErrorPasswordFrom2);
            return message.Replace("\n", "");
        }

        public void InputConfirmPassword(string password)
        {
            InputElement (WebDriver, _txtConfirmPassword, password);
        }

        public string GetErrorMsgConfirmPassword()
        {
            return GetTextFromElement(WebDriver, _lblErrorConfirmPassword);
        }

        public void ClickRegisterButton()
        {
            ClickElement (WebDriver, _btnRegister);
        }

        public void FillRegisterFields(Account account)
        {
            SelectGender(account.Gender);
            InputFirstName(account.Firstname);
            InputLastName(account.Lastname);
            SelectBirthday(account.Birthday);
            InputEmail(account.Email);
            InputCompany(account.CompanyName);
            InputPassword(account.Password);
            InputConfirmPassword(account.ConfirmPassword);
        }

        public void RegisterAnAccount(Account account)
        {
            GoToRegisterPage();
            FillRegisterFields(account);
            ClickRegisterButton();
        }
    }
}