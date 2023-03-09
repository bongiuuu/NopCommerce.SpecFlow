using NopCommerce.Pages;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class EditAddressSteps
    {
        private AddAddressPage _addAddressPage = new AddAddressPage(Context.WebDriver);
        private readonly ScenarioContext _scenarioContext;

        public EditAddressSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When("I click Edit button")]
        public void IClickEditButton()
        {
            _addAddressPage.ClickEditButton();
        }
        
        [When("I click Delete button")]
        public void IClickDeleteButton()
        {
            _addAddressPage.ClickDeleteButton();
        }

    }
}