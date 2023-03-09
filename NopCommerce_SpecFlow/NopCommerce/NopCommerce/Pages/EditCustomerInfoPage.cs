using NopCommerce.Constants;
using NopCommerce.Library;
using NopCommerce.Models;
using OpenQA.Selenium;

using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class EditCustomerInfoPage : RegisterPage
    {
        private WebObject _btnSave = new WebObject(By.Id("save-info-button"), "Button Save");
        public EditCustomerInfoPage(IWebDriver driver) : base(driver)
        {
        }
        
        public void GoToEditCustomerPage()
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + UrlConstants.CustomerEndpoint);
        }

        public void FillEditCustomerInfoFields(Account account)
        {
            SelectGender(account.Gender);
            InputFirstName(account.Firstname);
            InputLastName(account.Lastname);
            SelectBirthday(account.Birthday);
            InputEmail(account.Email);
            InputCompany(account.CompanyName);
        }

        public void ClickSaveButton()
        {
            ClickElement(WebDriver, _btnSave);
        }
    }
}