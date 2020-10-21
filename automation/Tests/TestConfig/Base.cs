using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace automation02.Tests.TestConfig
{


    [SetUpFixture]
    public static class Base
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;


        [OneTimeSetUp]
        public static void OneSetup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            htmlReporter.Config.Theme = Theme.Dark;

            _extent = new ExtentReports();

            _extent.AnalysisStrategy = AnalysisStrategy.Test;
            /*
            var parent = _extent.CreateTest("Parent");
            parent.CreateNode("Regression").Pass("pass");
            parent.CreateNode("Unit").Fail("fail");
           */

            _extent.AttachReporter(htmlReporter);

            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "QA");
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _extent.Flush();
        }


    }
}
