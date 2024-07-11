
# SmartUI SDK Integration with Selenium Tests

Welcome to the world of simplified visual testing with the SmartUI SDK.

Integrating seamlessly into your existing Selenium testing suite, SmartUI SDK revolutionizes the way you approach visual regression testing. Our robust solution empowers you to effortlessly capture, compare, and analyze screenshots across a multitude of browsers and resolutions, ensuring comprehensive coverage and accuracy in your visual testing endeavors.

## Pre-requisites for running tests through SmartUI SDK

- Basic understanding of Command Line Interface and Selenium is required.
- Login to LambdaTest SmartUI with your credentials.

The following steps will guide you in running your first Visual Regression test on LambdaTest platform using SmartUI Selenium SDK integration.

## Create a SmartUI Project

The first step is to create a project with the application in which we will combine all your builds run on the project. To create a SmartUI Project, follow these steps:

1. Go to Projects page.
2. Click on the new project button.
3. Select the platform as CLI for executing your SDK tests.
4. Add name of the project, approvers for the changes found, tags for any filter or easy navigation.
5. Click on the Submit.

## Steps to run your first test

Once you have created a SmartUI Project, you can generate screenshots by running automation scripts. Follow the below steps to successfully generate screenshots.

### Step 1: Create/Update your test

You can clone the sample repository to run LambdaTest automation tests with SmartUI and use `LTCloudTest.cs` file located in the `LambdaTest.Selenium.Driver.Test` folder.

\`\`\`sh
git clone https://github.com/LambdaTest/smartui-csharp-sample
cd smartui-csharp-sample/LambdaTest.Selenium.Driver.Test
\`\`\`

### Step 2: Update the Dependencies

Add the following dependencies in your `.csproj` file:

\`\`\`xml
<ItemGroup>
    <PackageReference Include="LambdaTest.Selenium.Driver" Version="1.0.1" />
</ItemGroup>
\`\`\`

> **NOTE**: You can check the latest version of `LambdaTest.Selenium.Driver` and update the latest version accordingly.

### Step 3: Install the Dependencies

Install required NPM modules for LambdaTest Smart UI Selenium SDK in your Frontend project.

\`\`\`sh
npm i @lambdatest/smartui-cli
dotnet restore
\`\`\`

### Step 4: Configure your Project Token

Setup your project token shown in the SmartUI app after creating your project.

#### MacOS/Linux

\`\`\`sh
export PROJECT_TOKEN="123456#1234abcd-****-****-****-************"
\`\`\`

#### Windows - CMD

\`\`\`cmd
set PROJECT_TOKEN=123456#1234abcd-****-****-****-************
\`\`\`

#### Windows - PS

\`\`\`powershell
$env:PROJECT_TOKEN="123456#1234abcd-****-****-****-************"
\`\`\`

### Step 5: Create and Configure SmartUI Config

You can now configure your project configurations using various available options to run your tests with the SmartUI integration. To generate the configuration file, please execute the following command:

\`\`\`sh
npx smartui config:create .smartui.json
\`\`\`

Once the configuration file is created, you will see the default configuration pre-filled in the configuration file:

\`\`\`json
{
  "web": {
    "browsers": [
      "chrome",
      "firefox",
      "safari",
      "edge"
    ],
    "viewports": [
      [
        1920
      ],
      [
        1366
      ],
      [
        1028
      ]
    ]
  },
  "mobile": {
    "devices": [
      "iPhone 14",
      "Galaxy S24"
    ],
    "fullPage": true,
    "orientation": "portrait"
  },
  "waitForTimeout": 1000,
  "waitForPageRender": 50000,
  "enableJavaScript": false,
  "allowedHostnames": []
}
\`\`\`

### Step 6: Adding SmartUI function to take screenshot

You can incorporate SmartUI into your custom Selenium automation test (any platform) script by adding the `smartuiSnapshot` function in the required segment of Selenium script of which we would like to take the screenshot, as shown below:

\`\`\`csharp
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
                driver.Navigate().GoToUrl("Required URL");
                await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name");
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
\`\`\`

### Step 7: Execute the Tests on SmartUI Cloud

Execute visual regression tests on SmartUI using the following commands:

\`\`\`sh
npx smartui --config .smartui.json exec -- dotnet run cloud
\`\`\`

> **NOTE**: You may use the `npx smartui --help` command in case you are facing issues during the execution of SmartUI commands in the CLI.

## View SmartUI Results

You have successfully integrated SmartUI SDK with your Selenium tests. Visit your SmartUI project to view builds and compare snapshots between different test runs.

You can see the Smart UI dashboard to view the results. This will help you identify the Mismatches from the existing Baseline build and do the required visual testing.

## Arguments supported in the smartUISnapshot function

The following are the different options which are currently supported:

| Key                  | Description |
|----------------------|-------------|
| `driver` (instance)  | The instance of the web driver used in your tests. |
| `"Screenshot Name"` (string) | Specify a name for the screenshot in your tests to match the same screenshot with the name from your baseline. |
| `options` (object)   | Specify one or a combination of selectors in the `ignoreDOM` or `selectDOM` objects. These selectors can be based on HTML DOM IDs, CSS classes, CSS selectors, or XPaths used by your webpage. They define elements that should be excluded from or included in the visual comparison. |

## Handling Dynamic Data in SmartUI SDK

When conducting visual tests, you may encounter scenarios where certain elements within your application change between test runs. These changes might introduce inconsistencies in your test results. You can ignore / select specific element(s) to be removed from the comparison by parsing the options in the `smartuiSnapshot` function in the following way:

### Ignore ID

\`\`\`csharp
driver.Navigate().GoToUrl("Required URL");

var options = new Dictionary<string, object>
{
    { "ignoreDOM", new Dictionary<string, object>
        {
            { "id", new[] { "ID-1", "ID-2" } }
        }
    }
};
await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name", options);
\`\`\`

### Select ID

\`\`\`csharp
driver.Navigate().GoToUrl("Required URL");

var options = new Dictionary<string, object>
{
    { "selectDOM", new Dictionary<string, object>
        {
            { "id", new[] { "ID-1", "ID-2" } }
        }
    }
};
await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name", options);
\`\`\`

## Capturing the screenshot of a specific element

You can capture screenshots of targeted elements by leveraging various locator mechanisms such as XPath, CSS ID, class, and selectors. This precision-driven approach ensures accurate and specific visual regression testing for your web application's components.

### Capture Element by ID

\`\`\`csharp
driver.Navigate().GoToUrl("Required URL");

var options = new Dictionary<string, object>
{
    { "element", new Dictionary<string, object>
        {
            { "id", new[] { "Required ID"} }
        }
    }
};
await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name", options);
\`\`\`

For additional information about SmartUI APIs please explore the [documentation here](https://www.lambdatest.com/support/docs/category/smartui/).
