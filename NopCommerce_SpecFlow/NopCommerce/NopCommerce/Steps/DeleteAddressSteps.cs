using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class DeleteAddressSteps
    {
        private AddAddressPage _addAddressPage = new AddAddressPage(Context.WebDriver);
        private readonly ScenarioContext _scenarioContext;

        public DeleteAddressSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [Then("the Address page is empty")]
        public void ThentheAddresspageisempty()
        {
            Assert.That(_addAddressPage.IsAddressPageEmpty(), Is.EqualTo(true));
        }

    }
}