using NopCommerce.Library;
using NopCommerce.Models;
using OpenQA.Selenium;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;

namespace NopCommerce.Pages
{
    public class AddressFields
    {
        private IWebDriver WebDriver;
        private string _txtFirstName = "_FirstName";
        private string _lblFirstNameError = "_FirstName-error";
        private string _txtLastName = "_LastName";
        private string _lblLastNameError = "_LastName-error";
        private string _txtEmail = "_Email";
        private string _lblEmailError = "_Email-error";
        private string _txtCompany = "_Company";
        private string _ddlCountry = "_CountryId";
        private string _lblCountryError = "_CountryId-error";
        private string _ddlStateProvince = "_StateProvinceId";
        private string _txtCity = "_City";
        private string _lblCityError = "_City-error";
        private string _txtAddress1 = "_Address1";
        private string _lblAddress1Error = "_Address1-error";
        private string _txtAddress2 = "_Address2";
        private string _txtZipCode = "_ZipPostalCode";
        private string _lblZipCodeError = "_ZipPostalCode-error";
        private string _txtPhone = "_PhoneNumber";
        private string _lblPhone = "_PhoneNumber-error";
        private string _txtFax = "_FaxNumber";

        public AddressFields(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void InputFirstName(string addressPart, string firstName)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtFirstName), UserAddressField.FirstName), firstName);
        }

        public string GetFirstNameError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblFirstNameError), UserAddressField.ErrorFirstName));
        }

        public void InputLastName(string addressPart, string lastName)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtLastName), UserAddressField.LastName), lastName);
        }

        public string GetLastNameError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblLastNameError), UserAddressField.ErrorLastName));
        }

        public void InputEmail(string addressPart, string email)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtEmail), UserAddressField.Email), email);
        }

        public string GetEmailError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblEmailError), UserAddressField.ErrorEmail));
        }

        public void InputCompany(string addressPart, string company)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtCompany), UserAddressField.Company), company);
        }

        public void SelectCountry(string addressPart, string country)
        {
            if (!country.Equals(string.Empty))
                SelectDropDownListByText(WebDriver, new WebObject(By.Id(addressPart + _ddlCountry), UserAddressField.Country), country);
        }

        public string GetCountryError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblCountryError), UserAddressField.ErrorCountry));
        }

        public void SelectState(string addressPart, string state)
        {
            if (!state.Equals(string.Empty))
                SelectDropDownListByText(WebDriver, new WebObject(By.Id(addressPart + _ddlStateProvince), UserAddressField.State), state);
        }

        public void InputCity(string addressPart, string city)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtCity), UserAddressField.City), city);
        }

        public string GetCityError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblCityError), UserAddressField.ErrorCity));
        }

        public void InputAddress1(string addressPart, string address)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtAddress1), UserAddressField.Address1), address);
        }

        public string GetAddress1Error(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblAddress1Error), UserAddressField.ErrorAddress1));
        }

        public void InputAddress2(string addressPart, string address)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtAddress2), UserAddressField.Address2), address);
        }

        public void InputZipCode(string addressPart, string zipcode)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtZipCode), UserAddressField.ZipCode), zipcode);
        }

        public string GetZipCodeError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblZipCodeError), UserAddressField.ErrorZipCode));
        }

        public void InputPhone(string addressPart, string phone)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtPhone), UserAddressField.Phone), phone);
        }

        public string GetPhoneError(string addressPart)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.Id(addressPart + _lblPhone), UserAddressField.ErrorPhone));
        }

        public void InputFax(string addressPart, string fax)
        {
            InputElement(WebDriver, new WebObject(By.Id(addressPart + _txtFax), UserAddressField.Fax), fax);
        }

        public void InputAddressFields(string addressPart, Address address)
        {
            InputFirstName(addressPart, address.FirstName);
            InputLastName(addressPart, address.LastName);
            InputEmail(addressPart, address.Email);
            InputCompany(addressPart, address.Company);
            SelectCountry(addressPart, address.Country);
            SelectState(addressPart, address.State);
            InputCity(addressPart, address.City);
            InputAddress1(addressPart, address.Address1);
            InputAddress2(addressPart, address.Address2);
            InputZipCode(addressPart, address.Zipcode);
            InputPhone(addressPart, address.Phone);
            InputFax(addressPart, address.Fax);
        }
    }
}