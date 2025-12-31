# Test Automation Framework

An enterprise-grade automation framework in **C#** leveraging **Selenium WebDriver**, **MSTest**, and **NLog**, supporting both **UI** and **API** automation with parallel execution and logging.\

---

## Table of Contents
- [Project Structure](#project-structure)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
- [Running Tests](#running-tests)

---

## Project Structure
```
TestAutomationFramework/
├── src/
│   ├── Ui.Tests/
│   │   ├── Pages/            # Page Object Models
│   │   ├── Tests/            # Test classes
│   │   ├── Utilities/        # Helper classes (e.g., ScreenshotUtils, UiActionHelper, UiAssertHelpers)
│   │   ├── Config/           # AppSettings.json for UI tests
│   │   ├── Base/             # Base classes, Action wrapper methods, WebDriverFactory
│   │   └── Data/             # Test data for UI tests
│   └── Api.Tests/
│       ├── Services/         # API Service definitions (Service Object Model)
│       ├── Tests/            # API test classes
│       ├── Config/           # AppSettings.json for API tests
│       ├── Base/             # Base service, RestClient factory
│       ├── Data/             # API request and schema files
│       ├── Models/           # API request and response DTOs
│       └── Utilities/        # ConfigReader, JsonSchemaValidator, RequestHelper, AssertHelpers
├── NLog.config               # Logging configuration
├── TestAutomationFramework.csproj
└── README.md
```

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio 2022
- Internet access for downloading NuGet packages
- Chrome and Edge browsers are installed in your machine
- No need to installed browser specific drivers as it is automatically handled through WebDriverManager


## Setup on mac/windows
1. Clone the repository:
```bash
git clone https://github.com/shalininsw/UI_API_Automation_Test.git
```
2. Restore NuGet packages:
```bash
dotnet restore
```
3. Build the project
```bash
dotnet build
```

## Running Tests on mac using zsh terminal
Follow these steps to execute the tests on your Mac machine:
1. Run all tests (both UI and API) with console logging. By default the UI test will run on chrome browser
```bash
dotnet test --logger "console;verbosity=detailed"
```
2. Run only UI test with console logging
```bash
dotnet test --logger "console;verbosity=detailed" --filter "TestCategory=api"
```
3. Run only UI test in edge browser with console logging.
```bash
dotnet test --filter "TestCategory=ui" --logger "console;verbosity=detailed" -- "TestRunParameters.Parameter(name=\"Browser\", value=\"edge\")"
```
4. Run only UI test in chrome browser with console logging.
```bash
dotnet test --filter "TestCategory=ui" --logger "console;verbosity=detailed" -- "TestRunParameters.Parameter(name=\"Browser\", value=\"chrome\")"
```
5. Run only API test with console logging.
```bash
dotnet test --filter "TestCategory=api" --logger "console;verbosity=detailed"
```
6. Run only UI test without console logging.
```bash
dotnet test --filter "TestCategory=ui"
```
7. Run only API test without console logging.
```bash
dotnet test --filter "TestCategory=api"
```


## Running Tests on windows using git bash terminal
1. Run only UI test in edge browser with console logging.
```bash
dotnet test --filter "TestCategory=ui" --logger "console;verbosity=detailed" -- "TestRunParameters.Parameter(name=\"Browser\", value=\"edge\")"
```

## Running Test on windows from Visual studio Test Explorer
Test explorer is another option from where we can run the test

## Parallel Execution
To run test in parallel. Go to MSTestSettings.cs file available in the root of the project. Uncomment the assemble attribute and then run one of the commands in above section

## Mobile Test Adaptation (Appium)
A brief outline how this test might be adapted for mobile (e.g., Appium):

1. **Add Appium Dependencies**
   - Install `Appium.WebDriver` NuGet package
   - The framework already uses WebDriver architecture, making Appium integration straightforward

2. **Create Mobile Driver Factory**
   - Extend `WebDriverFactory` to support mobile platforms (iOS/Android)
   - Configure `AppiumOptions` with desired capabilities (app path, platform name, device name, etc.)
   - Initialize `AndroidDriver` or `IOSDriver` instead of `ChromeDriver`/`EdgeDriver`

3. **Mobile-Specific Page Objects**
   - Create new mobile page objects under `src/Mobile.Tests/Pages/`
   - Use mobile-specific locators (Accessibility ID, UIAutomator, XPath)
   - Leverage existing `ElementActions` base class with mobile gestures (swipe, tap, scroll)

4. **Configuration**
   - Add mobile-specific settings in `AppSettings.json` (app path, platform version, device UDID)
   - Configure Appium server URL (typically `http://localhost:4723`)

5. **Test Structure**
   - Reuse existing test patterns and utilities
   - API tests remain unchanged - fully reusable
   - Create mobile-specific test classes inheriting from `BaseTest`
