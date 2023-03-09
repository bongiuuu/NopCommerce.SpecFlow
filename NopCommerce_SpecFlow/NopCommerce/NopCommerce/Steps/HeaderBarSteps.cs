using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

using static NopCommerce.Constants.HeaderBarConstants;

namespace NopCommerce.Steps
{
    [Binding]
    public class HeaderBarSteps
    {
        private HeaderBar _headerBar = new HeaderBar(Context.WebDriver);
        private readonly ScenarioContext _scenarioContext;

        public HeaderBarSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When("I click Logout button")]
        public void IClickLogoutButton()
        {
            _headerBar.ClickToLogout();
        }

        [Then("I logged in to the website successfully")]
        public void ILoggedIntoTheWebsiteSuccessfully()
        {
            Assert.That(_headerBar.GetLinkNameByOrder(1), Is.EqualTo(TitleMyAccount));
            Assert.That(_headerBar.GetLinkNameByOrder(2), Is.EqualTo(TitleLogout));
        }

        [Then("I logged out the website successfully")]
        public void ILoggedOutTheWebsiteSuccessfully()
        {
            Assert.That(_headerBar.GetLinkNameByOrder(1), Is.EqualTo(TitleRegister));
            Assert.That(_headerBar.GetLinkNameByOrder(2), Is.EqualTo(TitleLogin));
        }
    }
}