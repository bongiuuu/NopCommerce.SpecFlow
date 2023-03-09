using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using static NopCommerce.Context;

namespace NopCommerce.Library
{
    public class ScreenshotHelper
    {
        public static string GenerateImageFileName()
        {
            var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationHelper.GetConfigurationByKey(Config, "Screenshot.Folder"));
            string fullTestName = TestContext.CurrentContext.Test.Name;
            string scenario = (fullTestName.Contains("(")) ? "_" + fullTestName.Split("(")[1].Split(",")[0].Replace("\"", "") : "";
            string testName = TestContext.CurrentContext.Test.MethodName;
            string fileName = string.Format(@"Screenshot_{0}_{1}{2}", testName, scenario, DateTime.Now.ToString("yyyyMMdd_HHmmssff"));
            Directory.CreateDirectory(screenshotDirectory);
            return string.Format(@"{0}\{1}.png", screenshotDirectory, fileName);
        }

        public static string CaptureScreenshot(IWebDriver driver, string className, string testName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string fileLocation = GenerateImageFileName();
            screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            return fileLocation;
        }

        public static MediaEntityModelProvider CaptureScreenshotAndAttachToExtentReport(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenshotAsString = screenshot.AsBase64EncodedString;
            screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotAsString, screenshotName).Build();
        }
    }
}