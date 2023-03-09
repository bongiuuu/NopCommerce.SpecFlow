using NopCommerce.Library;
using NopCommerce.Models;
using OpenQA.Selenium;

using static NopCommerce.Constants.AddNewAddressConstants;
using static NopCommerce.Constants.UrlConstants;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class AddAddressPage
    {
        private IWebDriver WebDriver;
        private AddressFields _addressField = new AddressFields(Context.WebDriver);
        private WebObject _lblNoAddress = new WebObject(By.XPath("//div[text()='No addresses']"), UserAddressField.NoAddress);
        private WebObject _btnAddNew = new WebObject(By.XPath("//button[text()='Add new']"), UserAddressField.ButtonAddNew);
        private WebObject _btnEdit = new WebObject(By.XPath("//button[text()='Edit']"), UserAddressField.ButtonEdit);
        private WebObject _btnDelete = new WebObject(By.XPath("//button[text()='Delete']"), UserAddressField.ButtonDelete);
        private WebObject _btnSave = new WebObject(By.XPath("//button[@type='submit' and text()='Save']"), UserAddressField.ButtonSave);
        private WebObject _tableAddressItem = new WebObject(By.XPath("//div[@class='address-list']//div[contains(@class,'address-item')]"), UserAddressField.Table);
        private string _lblNameByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='name']";
        private string _lblEmailByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='email']";
        private string _lblPhoneByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='phone']";
        private string _lblFaxByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='fax']";
        private string _lblCompanyByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='company']";
        private string _lblAddress1ByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='address1']";
        private string _lblAddress2ByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='address2']";
        private string _lblCityStateZipByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='city-state-zip']";
        private string _lblCountryByOrder = @"//div[contains(@class, 'address-item')][{0}]//li[@class='country']";

        public AddAddressPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public bool IsAddressPageEmpty()
        {
            return IsElementDisplayed(WebDriver, _lblNoAddress);
        }

        public int GetNumberOfAddresses()
        {
            return FindElements(WebDriver, _tableAddressItem).Count;
        }

        public void GoToAddNewAddressPage()
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + AddNewAddressEndpoint);
        }

        public void ClickAddNewButton()
        {
            ClickElement(WebDriver, _btnAddNew);
        }

        public void ClickEditButton()
        {
            ClickElement(WebDriver, _btnEdit);
        }

        public void ClickDeleteButton()
        {
            ClickElement(WebDriver, _btnDelete);
        }

        public void InputAddress(Address address)
        {
            _addressField.InputAddressFields(PrefixAddress, address);
        }

        public void ClickSaveButton()
        {
            ClickElement(WebDriver, _btnSave);
        }

        public string GetNameByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblNameByOrder, order.ToString())), UserAddressField.Name));
        }

        public string GetEmailByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblEmailByOrder, order.ToString())), UserAddressField.Email));
        }

        public string GetPhoneByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblPhoneByOrder, order.ToString())), UserAddressField.Phone));
        }

        public string GetFaxByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblFaxByOrder, order.ToString())), UserAddressField.Fax));
        }

        public string GetCompanyByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblCompanyByOrder, order.ToString())), UserAddressField.Company));
        }

        public string GetAddress1ByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblAddress1ByOrder, order.ToString())), UserAddressField.Address2));
        }

        public string GetAddress2ByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblAddress2ByOrder, order.ToString())), UserAddressField.Address2));
        }

        public string GetCityStateZipByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblCityStateZipByOrder, order.ToString())), UserAddressField.CityStateZipCode));
        }

        public string GetCountryByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblCountryByOrder, order.ToString())), UserAddressField.Country));
        }
    }
}