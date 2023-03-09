using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static NopCommerce.Library.StringExtensions;

namespace NopCommerce.Library
{
    public static class DriverUtils
    {
        public static int GetWaitTimeoutSeconds()
        {
            return int.Parse(ConfigurationHelper.GetConfigurationByKey(Context.Config, "TimeoutInSecond"));
        }

        public static void NavigateToUrl(IWebDriver driver, string url)
        {
            driver.Url = url;
            Console.WriteLine($"[ PASSED ] - {GetCurrentTime()}: Open URL: {driver.Url}");
        }

        public static IWebElement WaitForElementToBeVisible(IWebDriver driver, WebObject element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                return wait.Until(ExpectedConditions.ElementIsVisible(element.By));
            }
            catch (WebDriverTimeoutException)
            {
                var message = $"[ FAILED ] - {GetCurrentTime()}: Element is not visible. Element information: [ {element.Name.ToUpper()} ]";
                Console.WriteLine(message);
                return null;
            }
        }

        public static IWebElement WaitForElementToBeClickable(IWebDriver driver, WebObject element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                return wait.Until(ExpectedConditions.ElementToBeClickable(element.By));
            }
            catch (WebDriverTimeoutException)
            {
                var message = $"[ FAILED ] - {GetCurrentTime()}: Element is not clickable. Element information: [ {element.Name.ToUpper()} ]";
                Console.WriteLine(message);
                return null;
            }
        }

        public static IWebElement WaitForElementToBeInvisible(IWebDriver driver, WebObject element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                return wait.Until(ExpectedConditions.ElementIsVisible(element.By));
            }
            catch (WebDriverTimeoutException)
            {
                var message = $"[ FAILED ] - {GetCurrentTime()}: Element is still visible. Element information: [ {element.Name.ToUpper()} ]";
                Console.WriteLine(message);
                return null;
            }
        }

        public static IWebElement WaitForElementToBeExisted(IWebDriver driver, WebObject element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                return wait.Until(ExpectedConditions.ElementExists(element.By));
            }
            catch (WebDriverTimeoutException)
            {
                var message = $"[ FAILED ] - {GetCurrentTime()}: Element does not exist. Element information: [ {element.Name.ToUpper()} ]";
                Console.WriteLine(message);
                return null;
            }
        }

        public static void WaitForPageLoadCompletely(IWebDriver driver, By elementBy)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
            wait.Until(driver1 =>
                    ((IJavaScriptExecutor) driver)
                        .ExecuteScript("return document.readyState")
                        .Equals("complete"));
        }

        public static IReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, WebObject element)
        {
            return driver.FindElements(element.By);
        }

        public static bool IsElementDisplayed(IWebDriver driver, WebObject element)
        {
            bool result;
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GetWaitTimeoutSeconds()));
                result = wait.Until(ExpectedConditions.ElementIsVisible(element.By)).Displayed;
            }
            catch (Exception)
            {
                result = false;
                var message = $"[ FAILED ] - {GetCurrentTime()}: [ {element.Name.ToUpper()} ] is not displayed as expected!";
                Console.WriteLine(message);
            }
            return result;
        }

        public static string GetTextFromElement(IWebDriver driver, WebObject element)
        {
            var _element = WaitForElementToBeVisible(driver, element);
            string value = _element.Text;
            var message = $"[ PASSED ] - {GetCurrentTime()}: Get text from [ {element.Name.ToUpper()} ]: {value}";

            Console.WriteLine(message);
            return value;
        }

        public static void ClickElement(IWebDriver driver, WebObject element)
        {
            var _element = WaitForElementToBeClickable(driver, element);
            var message = $"[ PASSED ] - {GetCurrentTime()}: Click element: [ {element.Name.ToUpper()} ]";

            _element.Click();
            Console.WriteLine(message);
        }

        public static void InputElement(IWebDriver driver, WebObject element, string text)
        {
            var _element = WaitForElementToBeVisible(driver, element);
            var message = $"[ PASSED ] - {GetCurrentTime()}: Input to [ {element.Name.ToUpper()} ] field: {text}";
            
            _element.Clear();
            _element.SendKeys (text);

            Console.WriteLine(message);
            Context.Scenario.Pass(message);
        }

        public static void SelectDropDownListByValue(IWebDriver driver, WebObject element, string value)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(element.By));
            var message = $"[ PASSED ] - {GetCurrentTime()}: Select from [ {element.Name.ToUpper()} ] dropdown list: {value}";

            dropdown.SelectByValue (value);
            Console.WriteLine(message);
        }

        public static void SelectDropDownListByText(IWebDriver driver, WebObject element, string value)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(element.By));
            var message = $"[ PASSED ] - {GetCurrentTime()}: Select from [ {element.Name.ToUpper()} ] dropdown list: {value}";

            dropdown.SelectByText (value);
            Console.WriteLine(message);
        }

        public static string GetAttributeValueFromElement(IWebDriver driver, WebObject element, string attribute)
        {
            var _element = WaitForElementToBeExisted(driver, element);
            string value = _element.GetAttribute(attribute);
            var message = $"[ PASSED ] - {GetCurrentTime()}: Get [ {attribute.ToUpper()} ] value of element [ {element.Name.ToUpper()} ]: {value}";
            Console.WriteLine(message);
            return value;
        }

        public static void GoToPreviousPage(IWebDriver driver)
        {
            driver.Navigate().Back();

            var message = $"[ PASSED ] - {GetCurrentTime()}: Go back to previous page";
            Console.WriteLine(message);
        }

        public static void RefreshWebPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();

            var message = $"[ PASSED ] - {GetCurrentTime()}: Refresh the page";
            Console.WriteLine(message);
        }
    }
}
