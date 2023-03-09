using OpenQA.Selenium;
using static NopCommerce.Library.DriverUtils;
using static NopCommerce.Constants.UrlConstants;
using static NopCommerce.Constants.WebElementName;
using NopCommerce.Library;
using static NopCommerce.Context;

namespace NopCommerce.Pages
{
    public class SearchPanel
    {
        public IWebDriver WebDriver;
        private WebObject _txtSearch = new WebObject(By.XPath("//input[@class='search-text']"), Search.SearchBox);
        private WebObject _checkboxBtnAdvancedSearch = new WebObject(By.XPath("//div[child::label[text()='Advanced search']]//input"), Search.CheckboxAdvancedSearch);
        private WebObject _blockAdvancedSearch = new WebObject(By.XPath("//div[@class='advanced-search']"), Search.AdvancedSearchTable);
        private WebObject _ddlCategory = new WebObject(By.XPath("//div[child::label[contains(text(), 'Category')]]//select"), Search.DropdownCategory);
        private WebObject _checkboxSearchSubCategory = new WebObject(By.XPath("//input[contains(@data-val-required, 'Automatically search sub categories field is required')]"), Search.SearchSubcategory);
        private WebObject _ddlManufacturer = new WebObject(By.XPath("//div[child::label[contains(text(), 'Manufacturer')]]//select"), Search.DropdownManufacturer);
        private WebObject _checkboxSearchDescription = new WebObject(By.XPath("//input[contains(@data-val-required,'Search In product descriptions')]"), Search.SearchDescription);
        private WebObject _btnSearch = new WebObject(By.XPath("//div[@class='buttons']//button[text()='Search']"), Search.SearchButton);
        private WebObject _lblErrorWaning = new WebObject(By.XPath("//div[@class='warning']"), Search.Warning);
        private WebObject _lblNoResult = new WebObject(By.XPath("//div[@class='no-result']"), Search.NoResult);
        public SearchPanel(IWebDriver driver)
        {
            WebDriver = driver;
        }
        
        public void GoToSearchPage()
        {
            NavigateToUrl(WebDriver, ConfigurationHelper.GetConfigurationByKey(Config, "TestUrl") + SearchEndpoint);
        }

        public void ClickToChooseAdvancedSearch(int numberOfTimes)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                ClickElement(WebDriver, _checkboxBtnAdvancedSearch);
            }
        }

        public bool IsAdvancedSearchFieldsDisplay()
        {
            return !GetAttributeValueFromElement(WebDriver, _blockAdvancedSearch, "style").Equals("display: none;");
        }

        public void InputSearchKeyword(string keyword)
        {
            InputElement(WebDriver, _txtSearch, keyword);
        }

        public void SelectCategory(string category)
        {
            SelectDropDownListByText(WebDriver, _ddlCategory, category);
        }

        public void SelectAutoSearchSubCategories()
        {
            ClickElement(WebDriver, _checkboxSearchSubCategory);
        }

        public void SelectManufacturer(string manufacturer)
        {
            SelectDropDownListByText(WebDriver, _ddlManufacturer, manufacturer);
        }

        public void SelectSearchDescription()
        {
            ClickElement(WebDriver, _checkboxSearchDescription);
        }

        public void ClickSearchButton()
        {
            ClickElement(WebDriver, _btnSearch);
        }

        public string GetWarningErrorMessage()
        {
            return GetTextFromElement(WebDriver, _lblErrorWaning);
        }

        public string GetNoResultMessage()
        {
            return GetTextFromElement(WebDriver, _lblNoResult);
        }
    }
}