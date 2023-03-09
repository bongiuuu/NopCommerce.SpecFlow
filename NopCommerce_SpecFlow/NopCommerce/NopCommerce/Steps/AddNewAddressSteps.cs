using Newtonsoft.Json;
using NopCommerce.Library;
using NopCommerce.Models;
using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

using static NopCommerce.Constants.AddNewAddressConstants;

namespace NopCommerce.Steps
{
    [Binding]
    public class AddNewAddressSteps
    {
        private AddAddressPage _addAddressPage = new AddAddressPage(Context.WebDriver);
        private AddressFields _addressFields = new AddressFields(Context.WebDriver);
        private readonly ScenarioContext _scenarioContext;

        public AddNewAddressSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I am in Add new address page")]
        public void IAmInAddNewAddressPage()
        {
            _addAddressPage.GoToAddNewAddressPage();
        }

        [Given("I click Add new address button")]
        [When("I click Add new address button")]
        public void IClickAddNewAddressButton()
        {
            _addAddressPage.ClickAddNewButton();
        }
        
        [Given("I already have an address with information")]
        public void GivenIalreadyhaveanaddresseswithinformation(Table table)
        {
            IAmInAddNewAddressPage();
            IClickAddNewAddressButton();
            IFillAddressInformationToFields(table);
            IClickSaveNeAddressButton();
        }

        [Given("I fill address information to fields")]
        [When("I fill address information to fields")]
        [When("I update address information")]
        public void IFillAddressInformationToFields(Table table)
        {
            Address address = JsonConvert.DeserializeObject<Address>(TableExtension.ToJson(table));
            _addAddressPage.InputAddress(address);
            _scenarioContext["address"] = address;
        }

        [Given("I click Save new address button")]
        [When("I click Save new address button")]
        public void IClickSaveNeAddressButton()
        {
            _addAddressPage.ClickSaveButton();
        }


        [Then("the added address is showed on the page")]
        [Then("the address is displayed with new information")]
        public void TheAddedAddressIsShowedOnThePage()
        {
            Address address = (Address)_scenarioContext["address"];
            var lastestAddress = _addAddressPage.GetNumberOfAddresses();
            var state = (address.State.Equals(string.Empty)) ? string.Empty : address.State + ", ";
            var fax = (address.Fax.Equals(string.Empty)) ? string.Empty : " " + address.Fax;
            Assert.That(_addAddressPage.GetNameByOrder(lastestAddress), Is.EqualTo(address.FirstName + " " + address.LastName));
            Assert.That(_addAddressPage.GetEmailByOrder(lastestAddress), Is.EqualTo("Email: " + address.Email));
            Assert.That(_addAddressPage.GetPhoneByOrder(lastestAddress), Is.EqualTo("Phone number: " + address.Phone));
            Assert.That(_addAddressPage.GetFaxByOrder(lastestAddress), Is.EqualTo("Fax number:" + fax));

            if (!address.Company.Equals(string.Empty))
                Assert.That(_addAddressPage.GetCompanyByOrder(lastestAddress), Is.EqualTo(address.Company));

            Assert.That(_addAddressPage.GetAddress1ByOrder(lastestAddress), Is.EqualTo(address.Address1));

            if (!address.Address2.Equals(string.Empty))
                Assert.That(_addAddressPage.GetAddress2ByOrder(lastestAddress), Is.EqualTo(address.Address2));

            Assert.That(_addAddressPage.GetCityStateZipByOrder(lastestAddress), Is.EqualTo(address.City + ", " + state + address.Zipcode));
            Assert.That(_addAddressPage.GetCountryByOrder(lastestAddress), Is.EqualTo(address.Country));
        }
        
        [Then("the Add new address page displays error message of {string}, {string}, {string}, {string}, {string}, {string}, {string}, {string}")]
        public void TheAddNewAddressPageDisplaysErrorMessageOf(string eFirstName,string eLastName,string eEmail,string eCountry,string eCity,string eAddress1,string eZipCode,string ePhone)
        {
            Address address = (Address)_scenarioContext["address"];
            if (address.FirstName.Equals(string.Empty))
                Assert.That(_addressFields.GetFirstNameError(PrefixAddress), Is.EqualTo(eFirstName));

            if (address.LastName.Equals(string.Empty))
                Assert.That(_addressFields.GetLastNameError(PrefixAddress), Is.EqualTo(eLastName));

            if (address.Email.Equals(string.Empty) || !address.Email.IsValidEmail())
                Assert.That(_addressFields.GetEmailError(PrefixAddress), Is.EqualTo(eEmail));

            if (address.Country.Equals(string.Empty))
                Assert.That(_addressFields.GetCountryError(PrefixAddress), Is.EqualTo(eCountry));

            if (address.City.Equals(string.Empty))
                Assert.That(_addressFields.GetCityError(PrefixAddress), Is.EqualTo(eCity));

            if (address.Address1.Equals(string.Empty))
                Assert.That(_addressFields.GetAddress1Error(PrefixAddress), Is.EqualTo(eAddress1));

            if (address.Zipcode.Equals(string.Empty))
                Assert.That(_addressFields.GetZipCodeError(PrefixAddress), Is.EqualTo(eZipCode));

            if (address.Phone.Equals(string.Empty))
                Assert.That(_addressFields.GetPhoneError(PrefixAddress), Is.EqualTo(ePhone));
        }
    }
}