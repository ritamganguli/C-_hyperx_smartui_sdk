using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using LambdaTest.Selenium.Driver;

namespace LambdaTest.Selenium.TestProject
{
    public static class CloudTest
    {
        public static async Task Run()
        {
            var username = Environment.GetEnvironmentVariable("LT_USERNAME") ?? "<USERNAME>";
            var accessKey = Environment.GetEnvironmentVariable("LT_ACCESS_KEY") ?? "<ACCESS_KEY>";
            var githubUrl = Environment.GetEnvironmentVariable("GITHUB_URL");

            var capabilities = new JObject
            {
                ["browserName"] = "Chrome",
                ["browserVersion"] = "latest",
                ["platformName"] = "Windows 10",
                ["name"] = "Selenium SmartUI Test",
                ["build"] = "Selenium SmartUI Build",
                ["user"] = username,
                ["accessKey"] = accessKey,
                ["network"] = true,
                ["video"] = true,
                ["console"] = true
            };

            if (githubUrl != null)
            {
                capabilities["github"] = new JObject { ["url"] = githubUrl };
            }

            var options = new ChromeOptions();
            options.AddAdditionalOption("LT:Options", capabilities);

            var remoteUrl = "https://hub.lambdatest.com/wd/hub";
            using (var driver = new RemoteWebDriver(new Uri(remoteUrl), options.ToCapabilities()))
            {
                driver.Navigate().GoToUrl("https://www.lambdatest.com");

                // Take SmartUI snapshot
                await SmartUISnapshot.CaptureSnapshot(driver, "Lambdatest-Cloud");

                driver.Quit();
            }
        }
    }
}
