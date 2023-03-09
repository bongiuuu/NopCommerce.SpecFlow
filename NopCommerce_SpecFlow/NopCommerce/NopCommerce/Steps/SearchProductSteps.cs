using NopCommerce.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NopCommerce.Steps
{
    [Binding]
    public class SearchProductSteps
    {
        private SearchPanel _searchPanel = new SearchPanel(Context.WebDriver);
        private ProductsContainer _productContainer = new ProductsContainer(Context.WebDriver);
        private ProductDetailPage _productDetailPage = new ProductDetailPage(Context.WebDriver);

        private readonly ScenarioContext _scenarioContext;

        public SearchProductSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I am in Search page")]
        public void GivenIaminSearchpage()
        {
            _searchPanel.GoToSearchPage();
        }

        [When("I click {string} to choose Advanced search")]
        public void WhenIclicktochooseAdvancedsearch(string numberOfTimes)
        {
            _searchPanel.ClickToChooseAdvancedSearch(int.Parse(numberOfTimes));
        }

        [Then("the advanced search fields are {string}")]
        public void Thentheadvancedsearchfieldsareshowed(string showedOrHidden)
        {
            var expected = (showedOrHidden.Equals("showed")) ? true : false;
            Assert.That(_searchPanel.IsAdvancedSearchFieldsDisplay(), Is.EqualTo(expected));
        }

        [When("I input {string} to Search field")]
        public void WhenIinputtoSearchfield(string keyword)
        {
            _searchPanel.InputSearchKeyword(keyword);
            _scenarioContext["keyword"] = keyword;
        }

        [When("I click to choose Advanced search")]
        public void WhenIclicktochooseAdvancedsearch()
        {
            _searchPanel.ClickToChooseAdvancedSearch(1);
        }

        [When("I click Search button")]
        public void GivenIclickSearchbutton()
        {
            _searchPanel.ClickSearchButton();
        }

        [Then("the Search page displays {string}")]
        public void ThentheSearchpagedisplays(string message)
        {
            var keyword = (string)_scenarioContext["keyword"];
            var realityMessage = (keyword.Length < 3) ? _searchPanel.GetWarningErrorMessage() : _searchPanel.GetNoResultMessage();
            Assert.That(realityMessage, Is.EqualTo(message));
        }

        [Then("the Search page displays products related to {string}")]
        [When("the Search page displays products related to {string}")]
        public void ThentheSearchpagedisplaysproductsrelatedto(string keyword)
        {
            _productContainer.SelectPageSize(18);
            int productNumbers = _productContainer.GetTotalProducts();
            List<String> productNameList = new List<string>();

            for (int order = 1; order <= productNumbers; order++)
            {
                var productName = _productContainer.GetProductNameByOrder(order).ToLower();
                productNameList.Add(productName);
                if (!productName.Contains(keyword.ToLower()))
                {
                    _productContainer.GoToProductDetailPageByOrder(order);
                    Assert.IsTrue(_productDetailPage.GetProductCategoryName().ToLower().Contains(keyword.ToLower()));
                    _productDetailPage.GoBackPage();
                }
            }

            _scenarioContext["productNameList"] = productNameList;
        }

        [When("I click to choose category dropdown value {string}, click {string} auto search sub categories checkbox, choose manufacturer dropdown value {string}, click {string} search in product descriptions checkbox")]
        public void WhenIclicktochoosecategorydropdownvalueclickautosearchsubcategoriescheckboxchoosemanufacturerdropdownvalueclicksearchinproductdescriptionscheckbox(string category,string autoSubCategory,string manufacturer,string onlyDescription)
        {
            if (!category.Equals(string.Empty))
                _searchPanel.SelectCategory(category);
            
            if (!autoSubCategory.Equals(string.Empty))
                _searchPanel.SelectAutoSearchSubCategories();
            
            if (!manufacturer.Equals(string.Empty))
                _searchPanel.SelectManufacturer(manufacturer);
            
            if (!onlyDescription.Equals(string.Empty))
                _searchPanel.SelectSearchDescription();

            _scenarioContext["category"] = category.ToLower();
            _scenarioContext["autoSubCategory"] = autoSubCategory.ToLower();
            _scenarioContext["manufacturer"] = manufacturer.ToLower();
            _scenarioContext["onlyDescription"] = onlyDescription;
        }

        [Then("the Search page displays product which is related to keyword {string} and advanced options")]
        [When("the Search page displays product which is related to keyword {string} and advanced options")]
        public void ThentheSearchpagedisplaysproductwhichisrelatedtokeywordandadvancedoptions(string keyword)
        {
            _productContainer.SelectPageSize(18);
            int productNumbers = _productContainer.GetTotalProducts();
            string category = _scenarioContext["category"].ToString();
            string _subCategory = (category.Contains(">>")) ? category.Split(" >> ")[1] : category;
            string autoSubCategory = _scenarioContext["autoSubCategory"].ToString();
            string manufacturer = _scenarioContext["manufacturer"].ToString();
            string onlyDescription = _scenarioContext["onlyDescription"].ToString();
            List<String> productNameList = new List<string>();

            for (int order = 1; order <= productNumbers; order++)
            {
                var productName = _productContainer.GetProductNameByOrder(order).ToLower();
                productNameList.Add(productName);

                _productContainer.GoToProductDetailPageByOrder(order);
                    
                if (!category.Equals(string.Empty))
                    Assert.IsTrue(_productDetailPage.GetFullProductCategoryBar().ToLower().Contains(_subCategory));

                if (!autoSubCategory.Equals(string.Empty) && category.Equals(string.Empty))
                {
                    string _productName = _productDetailPage.GetProductName().ToLower();
                    string _productCategory = _productDetailPage.GetProductCategoryName().ToLower();
                    bool toAssert = (_productName.Contains(keyword) || _productCategory.Contains(keyword)) ? true : false;

                    Assert.IsTrue(toAssert);
                }
                
                if (!manufacturer.Equals(string.Empty))
                    Assert.That(_productDetailPage.GetProductManufacturer().ToLower(), Is.EqualTo(manufacturer));

                if (!onlyDescription.Equals(string.Empty))
                {
                    var shortDescription = _productDetailPage.GetProductShortDescription().ToLower();
                    if (!shortDescription.Contains(keyword.ToLower()))
                        Assert.IsTrue(_productDetailPage.GetProductFullDescription().ToLower().Contains(keyword.ToLower()));
                }

                _productDetailPage.GoBackPage();
            }
            _scenarioContext["productNameList"] = productNameList;
        }

        [Then("the search result is not changed")]
        public void Thenthesearchresultisnotchanged()
        {
            int productNumbers = _productContainer.GetTotalProducts();
            List<string> productNames = (List<string>)_scenarioContext["productNameList"];
            for (int order = 1; order <= productNumbers; order++) 
            {
                var productName = _productContainer.GetProductNameByOrder(order).ToLower();
                Assert.That(productName, Is.EqualTo(productNames[order - 1]));
            }
        }

    }
}