using NopCommerce.Constants;
using NopCommerce.Library;
using OpenQA.Selenium;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.WebElementName;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class ProductDetailPage
    {
        public IWebDriver WebDriver;
        private WebObject _lblCategories = new WebObject(By.XPath("//div[@class='breadcrumb']//li"), ProductDetail.Category);
        private string _lblCategoryByOrder = "//div[@class='breadcrumb']//li[{0}]//span[@itemprop='name']";
        private WebObject _lblProductName = new WebObject(By.XPath("//div[@class='product-name']//h1"), ProductDetail.Name);
        private WebObject _lblProductShortDescription = new WebObject(By.XPath("//div[@class='short-description']"), ProductDetail.ShortDescription);
        private WebObject _lblProductSku = new WebObject(By.XPath("//div[@class='sku']//span[@class='value']"), ProductDetail.SKU);
        private WebObject _lblProductManufacturer = new WebObject(By.XPath("//div[@class='manufacturers']//a"), ProductDetail.Manufacturer);
        private WebObject _lblProductPrice = new WebObject(By.XPath("//div[@class='product-price']//span"), ProductDetail.Price);
        private WebObject _lblProductFullDescription = new WebObject(By.XPath("//div[@class='full-description']//p"), ProductDetail.FullDescription);
        private string _lblProductFullDescriptionByOrder = "//div[@class='full-description']//p[{0}]";
        private WebObject _txtQuantity = new WebObject(By.XPath("//div[@class='add-to-cart']//input"), ProductDetail.Quantity);
        private WebObject _btnAdd = new WebObject(By.XPath("//div[@class='add-to-cart']//button[text()='Add to cart']"), ProductDetail.Add);
        private WebObject _btnSuccessfullyCloseAddedBar = new WebObject(By.XPath("//div[@class='bar-notification success']//span"), ProductDetail.CloseAddSuccessfully);
        public ProductDetailPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void GoBackPage()
        {
            GoToPreviousPage(WebDriver);
        }

        public void GoToProductDetailPageByName(string name)
        {
            var _name = "/" + name.Replace(".", "").Replace(" ", "-");
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + _name);
        }

        public string GetProductName()
        {
            return GetTextFromElement(WebDriver, _lblProductName);
        }

        public string GetProductShortDescription()
        {
            return GetTextFromElement(WebDriver, _lblProductShortDescription);
        }

        public string GetProductSku()
        {
            return GetTextFromElement(WebDriver, _lblProductSku);
        }

        public string GetProductManufacturer()
        {
            return GetTextFromElement(WebDriver, _lblProductManufacturer);
        }

        public string GetProductPrice()
        {
            return GetTextFromElement(WebDriver, _lblProductPrice);
        }

        public string GetProductFullDescription()
        {
            int lines = FindElements(WebDriver, _lblProductFullDescription).Count;
            string fullDescription = "";
            for (int order = 1; order <= lines; order++)
            {
                WebObject webObject = new WebObject(
                    By.XPath(string.Format(_lblProductFullDescriptionByOrder, order)),
                    string.Format(ProductDetail.FullDescriptionByOrder, order));
                fullDescription += GetTextFromElement(WebDriver, webObject);
            }
            return fullDescription;
        }

        public void InputProductQuantity(int quantity)
        {
            InputElement(WebDriver, _txtQuantity, quantity.ToString());
        }

        public void ClickAddButton()
        {
            ClickElement(WebDriver, _btnAdd);
            ClickElement(WebDriver, _btnSuccessfullyCloseAddedBar);
        }

        public string GetProductCategoryName()
        {
            int categoryOrder = FindElements(WebDriver, _lblCategories).Count - 1;
            WebObject webObject = new WebObject(
                By.XPath(string.Format(_lblCategoryByOrder, categoryOrder)),
                string.Format(ProductDetail.CategoryByOrder, categoryOrder));
            return GetTextFromElement(WebDriver, webObject);
        }

        public string GetFullProductCategoryBar()
        {
            int categoryBarSize = FindElements(WebDriver, _lblCategories).Count;
            string result = "";
            
            for (int order = 2; order <= categoryBarSize - 1; order++)
            {
                WebObject webObject = new WebObject(
                    By.XPath(string.Format(_lblCategoryByOrder, order)),
                    string.Format(ProductDetail.CategoryByOrder, order));
                result += GetTextFromElement(WebDriver, webObject) + "/";
            }
            
            return result;
        }
    }
}