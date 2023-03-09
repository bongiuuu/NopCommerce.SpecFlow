using NopCommerce.Library;
using OpenQA.Selenium;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;

namespace NopCommerce.Pages
{
    public class HeaderBar
    {
        public IWebDriver WebDriver;
        private WebObject _linkMyAccount = new WebObject(By.ClassName("ico-account"), Header.MyAccount);
        private WebObject _linkLogOut = new WebObject(By.ClassName("ico-logout"), Header.Logout);
        private WebObject _linkRegister = new WebObject(By.ClassName("ico-register"), Header.Register);
        private WebObject _linkLogIn = new WebObject(By.ClassName("ico-login"), Header.Login);
        private WebObject _linkShoppingCart = new WebObject(By.ClassName("ico-cart"), Header.ShoppingCart);
        private String _lblLinkNameByOrder = @"//div[@class='header-links']//li[{0}]//a";

        public HeaderBar(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void ClickToLogin()
        {
            ClickElement(WebDriver, _linkLogIn);
        }

        public void ClickToRegister()
        {
            ClickElement(WebDriver, _linkRegister);
        }

        public void ClickToMyAccount()
        {
            ClickElement(WebDriver, _linkMyAccount);
        }

        public void ClickToLogout()
        {
            ClickElement(WebDriver, _linkLogOut);
        }

        public void ClickToShoppingCart()
        {
            ClickElement(WebDriver, _linkShoppingCart);
        }

        public string GetLinkNameByOrder(int order)
        {
            return GetTextFromElement(WebDriver, new WebObject(By.XPath(string.Format(_lblLinkNameByOrder, order)), string.Format(Header.LinkName, order)));
        }
    }
}