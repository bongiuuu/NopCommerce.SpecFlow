using OpenQA.Selenium;

namespace NopCommerce.Library
{
    public class WebObject
    {
        public By By { get; set; }
        public string Name { get; set; }

        public WebObject(By by, string name = "")
        {
            By = by;
            Name = name;
        }
    }
}