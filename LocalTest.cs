using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LambdaTest.Selenium.Driver;


namespace LambdaTest.Selenium.TestProject
{
    public static class LocalTest
    {
        public static async Task Run()
        {
            using IWebDriver driver = new ChromeDriver();
            try
            {   
                Console.WriteLine("Driver started");
                driver.Navigate().GoToUrl("https://www.lambdatest.com");
                await SmartUISnapshot.CaptureSnapshot(driver, "Lambdatest-Local");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
