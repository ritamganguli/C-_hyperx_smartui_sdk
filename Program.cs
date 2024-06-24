using LambdaTest.Selenium.TestProject;

namespace LambdaTest.Selenium.Driver.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify the test to run: local or cloud");
                return;
            }

            switch (args[0].ToLower())
            {
                case "local":
                    await LocalTest.Run();
                    break;
                case "cloud":
                    await CloudTest.Run();
                    break;
                case "localoptions":
                    await LocalOptionsTest.Run();
                    break;
                case "cloudoptions":
                    await CloudOptionsTest.Run();
                    break;
                default:
                    Console.WriteLine("Unknown test specified. Please use 'local','cloud','localoptions' or 'cloudoptions' as argument");
                    break;
            }
        }
    }
}
