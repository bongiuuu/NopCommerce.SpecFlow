using NopCommerce.Constants;
using NopCommerce.Library;
using OpenQA.Selenium;
using static NopCommerce.Constants.CategoryConstants;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class ProductsContainer
    {
        public IWebDriver WebDriver;
        private WebObject _productUpdatingStatus = new WebObject(By.XPath("//div[@class='products-container']//div[contains(@style, 'display: block')]"), ProductContainer.UpdatingContainer);
        private WebObject _productNoUpdateStatus = new WebObject(By.XPath("//div[@class='products-container']//div[contains(@style, 'display: none')]"), ProductContainer.NoUpdatingContainer);
        private WebObject _ddlSort = new WebObject(By.Id("products-orderby"), ProductContainer.DropdownSort);
        private string _optSort = "//option[contains(text(), '{0}')]";
        private WebObject _ddlPageSize = new WebObject(By.Id("products-pagesize"), ProductContainer.DropdownPageSize);
        private WebObject _itemProduct = new WebObject(By.XPath("//div[@class='item-box']"), ProductContainer.ItemProduct);
        private string _itemProductNameByOrder = "//div[@class='item-box'][{0}]//div[@class='details']//a";
        private string _itemProductPicByOrder = "//div[@class='item-box'][{0}]//div[@class='picture']//a";
        private string _itemProductPriceByOrder = "//div[@class='item-box'][{0}]//div[@class='prices']//span";

        public ProductsContainer(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void RefreshPage()
        {
            RefreshWebPage(WebDriver);
        }

        public void GoToCategoryPage(string category)
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + CategoryEndpoints[category]);
        }

        public void SelectSortType(string sortType)
        {
            WebObject webObject = new WebObject(
                By.XPath(string.Format(_optSort, sortType)),
                string.Format(ProductContainer.SortOption, sortType));
            ClickElement(WebDriver, _ddlSort);
            ClickElement(WebDriver, webObject);
            ClickElement(WebDriver, _ddlSort);

            WaitForElementToBeExisted(WebDriver, _productUpdatingStatus);
            WaitForElementToBeExisted(WebDriver, _productNoUpdateStatus);
        }

        public void SelectPageSize(int size)
        {
            SelectDropDownListByText(WebDriver, _ddlPageSize, size.ToString());
            WaitForElementToBeExisted(WebDriver, _productUpdatingStatus);
            WaitForElementToBeExisted(WebDriver, _productNoUpdateStatus);
        }

        public string GetProductNameByOrder(int order)
        {
            WebObject webObject = new WebObject(
                By.XPath(string.Format(_itemProductNameByOrder, order)),
                string.Format(ProductContainer.ProductNameByOrder, order)
            );
            return GetTextFromElement(WebDriver, webObject);
        }

        public void GoToProductDetailPageByOrder(int order)
        {
            WebObject webObject = new WebObject(
                By.XPath(string.Format(_itemProductPicByOrder, order)),
                string.Format(ProductContainer.ProductPicByOrder, order)
            );
            ClickElement(WebDriver, webObject);
        }

        public int GetTotalProducts()
        {
            return FindElements(WebDriver, _itemProduct).Count;
        }

        public List<string> GetListProductNames()
        {
            var _numberOfProduct = GetTotalProducts();
            List<string> _productNames = new List<string>();
            for (int order = 1; order <= _numberOfProduct; order++)
            {
                WebObject webObject = new WebObject(
                By.XPath(string.Format(_itemProductNameByOrder, order)),
                string.Format(ProductContainer.ProductNameByOrder, order)
            );
                _productNames.Add(GetTextFromElement(WebDriver, webObject));
            }
            return _productNames;
        }
    }
}