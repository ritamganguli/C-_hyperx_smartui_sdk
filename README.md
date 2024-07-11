# <a name="_usmwc5uvzlxk"></a>**Integrate SmartUI SDK with Selenium Tests**

Welcome to the world of simplified visual testing with the SmartUI SDK.

Integrating seamlessly into your existing Selenium testing suite, SmartUI SDK revolutionizes the way you approach visual regression testing. Our robust solution empowers you to effortlessly capture, compare, and analyze screenshots across a multitude of browsers and resolutions, ensuring comprehensive coverage and accuracy in your visual testing endeavors.
## <a name="_bq75mjac66z"></a>**Pre-requisites for running tests through SmartUI SDK[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#pre-requisites-for-running-tests-through-smartui-sdk)**
- Basic understanding of Command Line Interface and Selenium is required.
- Login to [LambdaTest SmartUI](https://smartui.lambdatest.com/) with your credentials.

The following steps will guide you in running your first Visual Regression test on LambdaTest platform using SmartUI Selenium SDK integration.
## <a name="_shug0s3amft0"></a>**Create a SmartUI Project[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#create-a-smartui-project)**
The first step is to create a project with the application in which we will combine all your builds run on the project. To create a SmartUI Project, follow these steps:

1. Go to [Projects page](https://smartui.lambdatest.com/)
1. Click on the new project button
1. Select the platform as **CLI** for executing your SDK tests.
1. Add name of the project, approvers for the changes found, tags for any filter or easy navigation.
1. Click on the Submit.
## <a name="_rba5nyjpefnp"></a>**Steps to run your first test[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#steps-to-run-your-first-test)**
Once you have created a SmartUI Project, you can generate screenshots by running automation scripts. Follow the below steps to successfully generate screenshots
### <a name="_sq07r2cghuo6"></a>**Step 1: Create/Update your test[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-1-createupdate-your-test)**
You can clone the sample repository to run LambdaTest automation tests with SmartUI and use LTCloudTest.cs file located in the LambdaTest.Selenium.Driver.Test folder.

git clone https://github.com/LambdaTest/smartui-csharp-sample

cd smartui-csharp-sample/LambdaTest.Selenium.Driver.Test
### <a name="_lx646r3hpk5k"></a>**Step 2: Update the Dependencies[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-2-update-the-dependencies)**
- Add the following dependencies in your .csproj file


```  
<ItemGroup>
    <PackageReference Include="LambdaTest.Selenium.Driver" Version="1.0.1" />
</ItemGroup>
```
NOTE

You can check the latest version of [LambdaTest.Selenium.Driver](https://www.nuget.org/packages/LambdaTest.Selenium.Driver) and update the latest version accordingly.
### <a name="_af8f89foua57"></a>**Step 3: Install the Dependencies[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-3-install-the-dependencies)**
Install required NPM modules for LambdaTest Smart UI Selenium SDK in your Frontend project over the pre steps.

```
pre:
  - dotnet clean
  - dotnet build
  - npm i @lambdatest/smartui-cli
  - dotnet restore
  - npx smartui config:create .smartui.json
```


### <a name="_wnd3sajqvzpi"></a>**Step 4: Configure your Project Token[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-4-configure-your-project-token)**
Setup your project token show in the SmartUI app after, creating your project.

- MacOS/Linux
- Windows - CMD
- Windows-PS

```
env:
 PROJECT_TOKEN: ritam*---------#C#_SDK
```



### <a name="_lfkwyaz2juco"></a>**Step 5: Create and Configure SmartUI Config[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-5-create-and-configure-smartui-config)**
You can now configure your project configurations on using various available options to run your tests with the SmartUI integration. To generate the configuration file, please execute the following command:

npx smartui config:create .smartui.json

Once, the configuration file will be created, you will be seeing the default configuration pre-filled in the configuration file:


```
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
    ] // Full Page screenshots are captured by default for web viewports
  },
  "mobile": {
    "devices": [
      "iPhone 14",  //iPhone 14 viewport
      "Galaxy S24"  //Galaxy S24 viewport
    ],
    "fullPage": true, //Full Page is true by default for mobile viewports
    "orientation": "portrait" //Change to "landscape" for landscape snapshot
  },
  "waitForTimeout": 1000, //Optional (Should only be used in case lazy-loading/async components are present)
  "waitForPageRender": 50000, //Optional (Should only be used in case of websites which take more than 30s to load)
  "enableJavaScript": false, //Enable javascript for all the screenshots of the project
  "allowedHostnames": [] //Additional hostnames to capture assets from
}

```


ADVANCED OPTIONS IN SMARTUI CONFIGURATION

- For capturing fullpage or viewport screenshots, please refer to this [documentation](https://www.lambdatest.com/support/docs/smartui-sdk-config-options/#12-viewports)
- For the list of available mobile viewports, please refer to this [documentation](https://www.lambdatest.com/support/docs/smartui-sdk-config-options/#list-of-supported-device-viewports)
- For more information about SmartUI config global options, please refer to this [documentation](https://www.lambdatest.com/support/docs/smartui-sdk-config-options/#3-global-options-optional).
### <a name="_fm4lfeie8puj"></a>**Step 6: Adding SmartUI function to take screenshot[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-6-adding-smartui-function-to-take-screenshot)**
- You can incorporate SmartUI into your custom Selenium automation test (any platform) script by adding the smartuiSnapshot function in the required segment of selenium script of which we would like to take the screenshot, as shown below:

```
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
                await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name"); //utilize this function to take the dom snapshot of your test
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
```

### <a name="_ofipr9spu8je"></a>**Step 7: Execute the Tests on SmartUI Cloud[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#step-7-execute-the-tests-on-smartui-cloud)**
Execute visual regression tests on SmartUI using the following commands

npx smartui --config .smartui.json exec -- dotnet run cloud

NOTE

You may use the npx smartui --help command in case you are facing issues during the execution of SmartUI commands in the CLI.
## <a name="_i8bdjb7e43kb"></a>**View SmartUI Results[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#view-smartui-results)**
You have successfully integrated SmartUI SDK with your Selenium tests. Visit your SmartUI project to view builds and compare snapshots between different test runs.

You can see the Smart UI dashboard to view the results. This will help you identify the Mismatches from the existing Baseline build and do the required visual testing.



## <a name="_uso9p4wk6cjn"></a>**Arguments supported in the smartUISnapshot function[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#arguments-supported-in-the-smartuisnapshot-function)**
The following are the different options which are currently supported:

|**Key**|**Description**|
| :-: | :-: |
|driver (instance)|The instance of the web driver used in your tests.|
|"Screenshot Name" (string)|Specify a name for the screenshot in your tests to match the same screenshot with the name from your baseline.|
|options (object)|Specify one or a combination of selectors in the ignoreDOM or selectDOM objects. These selectors can be based on HTML DOM IDs, CSS classes, CSS selectors, or XPaths used by your webpage. They define elements that should be excluded from or included in the visual comparison.|
## <a name="_o9uz361vbqy5"></a>**Handling Dynamic Data in SmartUI SDK New[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#handling-dynamic-data-in-smartui-sdk--)**
When conducting visual tests, you may encounter scenarios where certain elements within your application change between test runs. These changes might introduce inconsistencies in your test results.You can ignore / select specific element(s) to be removed from the comparison by parsing the options in the smartuiSnapshot function in the following way

- Ignore ID
- Ignore Class
- Ignore XPath
- Ignore CSS Selector

This is a sample for your configuration for C# to ignore by ID

driver.Navigate().GoToUrl("Required URL");

var options = new Dictionary<string, object>

{

`   `{ "ignoreDOM", new Dictionary<string, object>

`       `{

`           `{ "id", new[] { "ID-1", "ID-2" } }

`       `}

`   `}

};

await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name",options);

- Select ID
- Select Class
- Select XPath
- Select CSS Selector

This is a sample for your configuration for C# to select by ID

driver.Navigate().GoToUrl("Required URL");

var options = new Dictionary<string, object>

{

`   `{ "selectDOM", new Dictionary<string, object>

`       `{

`           `{ "id", new[] { "ID-1", "ID-2" } }

`       `}

`   `}

};

await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name",options);
## <a name="_v7143bbimcqy"></a>**For capturing the screenshot of a specific element[​**](https://www.lambdatest.com/support/docs/smartui-selenium-csharp-sdk/#for-capturing-the-screenshot-of-a-specific-element)**
You can capture screenshots of targeted elements by leveraging various locator mechanisms such as XPath, CSS ID, class, and selectors. This precision-driven approach ensures accurate and specific visual regression testing for your web application's components.

- Capture Element by ID
- Capture Element by Class
- Capture Element by XPath
- Element CSS Selector

This is a sample for your configuration for C# to capture an element by ID

driver.Navigate().GoToUrl("Required URL");

var options = new Dictionary<string, object>

{

`   `{ "element", new Dictionary<string, object>

`       `{

`           `{ "id", new[] { "Required ID"} }

`       `}

`   `}

};

await SmartUISnapshot.CaptureSnapshot(driver, "Screenshot Name",options);

For additional information about SmartUI APIs please explore the documentation [here](https://www.lambdatest.com/support/api-doc/)

