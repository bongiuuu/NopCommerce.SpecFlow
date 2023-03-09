using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
using NopCommerce.Library;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using static NopCommerce.Library.ScreenshotHelper;
using static NopCommerce.Library.StringExtensions;
using System.Reflection;

namespace NopCommerce
{
    [Binding]
    public static class Context
    {
        public static IWebDriver WebDriver;
        public static ExtentTest Feature;
        public static ExtentTest Scenario;
        public static IConfiguration Config;
        public static ExtentReports Report;
        public static string errorImageFileLocation;
        static string AppSettingPath = "appsettings.json";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            TestContext.Progress.WriteLine($"[ LOG ] - {GetCurrentTime()}: Before Test Run");

            //Read Configuration file
            Config = ConfigurationHelper.ReadConfiguration(AppSettingPath);

            // Init Extend report
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationHelper.GetConfigurationByKey(Config, "TestResult.FilePath"));

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            Report = new ExtentReports();
            Report.AttachReporter(htmlReporter);
            Report.AddSystemInfo("Host Name", "SpecFlow - NopCommerce");
            Report.AddSystemInfo("Environment", "Test Environment");
            Report.AddSystemInfo("Test Browser", ConfigurationHelper.GetConfigurationByKey(Config, "Browser"));
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            TestContext.Progress.WriteLine($"[ LOG ] - {GetCurrentTime()}: After Test Run");
            Report.Flush();
            WebDriver.Dispose();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Feature = Report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            WebDriver = BrowserFactory.InitDriver(ConfigurationHelper.GetConfigurationByKey(Config, "Browser"));
            WebDriver.Manage().Window.Maximize();
            Scenario = Feature.CreateNode<Scenario>(TestContext.CurrentContext.Test.Name);
            Console.WriteLine("============================================================================================================");
            Console.WriteLine($"[ LOG ] - {GetCurrentTime()}: Before Scenario");

            string fullTestName = TestContext.CurrentContext.Test.Name;
            string scenario = (fullTestName.Contains("(")) ? " - " + fullTestName.Split("(")[1].Split(",")[0].Replace("\"", "") : "";
            Console.WriteLine($"[ LOG ] - {GetCurrentTime()}: Scencario - {TestContext.CurrentContext.Test.MethodName}{scenario}");
        }

        [AfterScenario]
        public static void AfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            WebDriver.Quit();
            Console.WriteLine($"[ LOG ] - {GetCurrentTime()}: After Scenario");
        }

        [AfterStep]
        [Obsolete]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepInfo = scenarioContext.StepContext.StepInfo.Text;
        
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus",
                BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object resultOfImplementation = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType.Equals("Given"))
                    Scenario.CreateNode<Given>(stepInfo);
                else if (stepType.Equals("When"))
                    Scenario.CreateNode<When>(stepInfo);
                else if (stepType.Equals("Then"))
                    Scenario.CreateNode<Then>(stepInfo);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                errorImageFileLocation = GenerateImageFileName();
                var testError = "#Error: " + scenarioContext.TestError.Message;

                if (stepType.Equals("Given"))
                    Scenario.CreateNode<Given>(stepInfo).Fail(testError, CaptureScreenshotAndAttachToExtentReport(WebDriver, errorImageFileLocation));
                else if (stepType.Equals("When"))
                    Scenario.CreateNode<When>(stepInfo).Fail(testError, CaptureScreenshotAndAttachToExtentReport(WebDriver, errorImageFileLocation));
                else if (stepType.Equals("Then"))
                    Scenario.CreateNode<Then>(stepInfo).Fail(testError, CaptureScreenshotAndAttachToExtentReport(WebDriver, errorImageFileLocation));
            }
            
            if (resultOfImplementation.ToString() == "StepDefinitionPending")
            {
                errorImageFileLocation = GenerateImageFileName();
                string errorMessage = "Step Definition is not implemented!";

                if (stepType.Equals("Given"))
                    Scenario.CreateNode<Given>(stepInfo).Skip(errorMessage, CaptureScreenshotAndAttachToExtentReport(WebDriver, errorImageFileLocation));
                else if (stepType.Equals("When"))
                    Scenario.CreateNode<When>(stepInfo).Skip(errorMessage, CaptureScreenshotAndAttachToExtentReport(WebDriver, errorImageFileLocation));
                else if (stepType.Equals("Then"))
                    Scenario.CreateNode<Then>(stepInfo).Skip(errorMessage, CaptureScreenshotAndAttachToExtentReport(WebDriver, errorImageFileLocation));
            }
        }
    }
}