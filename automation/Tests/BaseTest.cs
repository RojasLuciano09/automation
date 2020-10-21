using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace automation02.Tests
{
    public class Tests
    {
        public static ExtentReports _extent = Base._extent;
        public static ExtentTest _test = Base._test;

        public IWebDriver driver;

        /// <summary>
        /// Se realiza una instancia del navegador MOZILLA, se puede modificar por Chrome, tambien hay que indicarle de donde tomar el driver.exe
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver("C:\\Users\\l.rojas\\Desktop\\QA\\Trabajo\\Automatizacion\\biopago\\automation02\\Config\\resources", getFirefoxOptions());
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver.Manage().Window.Maximize();

        }

        /// <summary>
        /// Genera un 'profile' para el navegador mozilla, añadiendole mas metodos para que  descargue archivos sin preguntar.
        /// </summary>
        /// <returns></returns>
        private FirefoxOptions getFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "C:\\Windows\\temp");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
            options.SetPreference("pdfjs.disabled", true);  // disable the built-in PDF viewer
            options.AcceptInsecureCertificates = true;
            
            return options;
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
                    _test.Log(Status.Fail, "Fail ");
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
