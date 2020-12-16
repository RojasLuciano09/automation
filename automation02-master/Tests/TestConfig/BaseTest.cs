using automation02.Tests.TestConfig;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace automation02.Tests
{


    public class Tests
    {
        public  ExtentReports _extent = Base._extent;
        public  ExtentTest _test = Base._test;



        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ///Revisar en donde se encuentra el chromedriver.exe
            ///En el proyecto lo guarde en Tests->TestConfig
            driver = new ChromeDriver("C:\\Users\\n.rojas\\source\\repos\\automation02\\Tests\\TestConfig\\");       
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }



        [TearDown]
        public void AfterTest()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(driver, fileName);

                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;

                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }

    }
}