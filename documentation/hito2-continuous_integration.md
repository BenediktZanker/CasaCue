# Hito 2: CasaCue Project Documentation – Continuous Integration

## Decision-Making Process

### 1. Choice of CI/CD Tool: GitHub Actions
   **Reasoning**: I chose GitHub Actions for continuous integration (CI) as it integrates directly with GitHub, where my project repository is hosted. GitHub Actions provides a flexible and easy-to-configure workflow, supporting .NET projects natively and allowing me to manage CI within the same platform.

### 2. Test Framework: xUnit
   **Reasoning**: I selected xUnit as the test framework due to its seamless compatibility with .NET Core and .NET 8. xUnit provides straightforward assertions, reliable test discovery, and it is widely used within the .NET ecosystem. Additionally, xUnit’s structure supports both unit and integration tests, making it ideal for verifying CasaCue’s core logic.

### 3. .NET Version: .NET 8
   **Reasoning**: I decided to use .NET 8 to leverage the latest performance enhancements, improved APIs, and features that optimize web applications. Since .NET 8 is well-supported by both xUnit and GitHub Actions, it ensures compatibility and efficiency throughout my CI/CD pipeline.

---

## Setup Guide: Step-by-Step

### Step 1: Project Initialization

1. **Create a New .NET Web API Project**:
   - First, I set up the backend project for CasaCue as a .NET Web API to manage restaurant waitlists:
     ```bash
     dotnet new webapi -n CasaCue
     ```

2. **Create the Test Project**:
   - Next, I created a test project using xUnit, where I will validate the core logic and functions of the CasaCue backend.
     ```bash
     dotnet new xunit -n CasaCue.Tests
     ```

3. **Link the Test Project with the Backend Project**:
   - I linked the test project to the backend project to allow direct access to backend code from within my tests:
     ```bash
     dotnet add reference ../CasaCue/CasaCue.csproj
     ```

### Step 2: Implementing the Initial Test

1. **Edit the Example Test**:
   - To verify that the environment was set up correctly, I added a simple test to check basic functionality:
     ```csharp
     using Xunit;

     namespace CasaCue.Tests
     {
         public class UnitTest1
         {
             [Fact]
             public void TestBasicFunctionality()
             {
                 int expected = 5;
                 int actual = 2 + 3;
                 Assert.Equal(expected, actual);
             }
         }
     }
     ```

2. **Run Tests Locally**:
   - I ran the following command to ensure everything was working correctly with the new test:
     ```bash
     dotnet test
     ```

### Step 3: Configuring GitHub Actions for CI

1. **Create a GitHub Actions Workflow File**:
   - In the root directory of my project, I created a new directory `.github/workflows` to house the GitHub Actions workflow file.
   - Within this directory, I created a file named `ci.yml` to define the CI workflow.

2. **Configure the Workflow**:
   - In `ci.yml`, I configured the following steps to automate builds and tests:
     ```yaml
     name: .NET CI

     on:
       push:
         branches:
           - main
           - development
       pull_request:
         branches:
           - main
           - development

     jobs:
       build:
         runs-on: ubuntu-latest

         steps:
         - name: Checkout code
           uses: actions/checkout@v2

         - name: Setup .NET
           uses: actions/setup-dotnet@v2
           with:
             dotnet-version: '8.x'

         - name: Restore dependencies
           run: |
             dotnet restore CasaCue/CasaCue.csproj
             dotnet restore CasaCue.Tests/CasaCue.Tests.csproj

         - name: Build
           run: dotnet build CasaCue/CasaCue.csproj --configuration Release --no-restore

         - name: Test
           run: dotnet test CasaCue.Tests/CasaCue.Tests.csproj --no-restore --verbosity normal
     ```

3. **Explanation of Workflow Steps**:
   - **Checkout code**: Fetches the latest code from the repository.
   - **Setup .NET**: Configures .NET 8 in the CI environment to ensure compatibility.
   - **Restore dependencies**: Installs all necessary NuGet dependencies for both the backend and test projects.
   - **Build**: Builds the backend project to check for compilation errors and verify code integrity.
   - **Test**: Executes the xUnit tests to validate the core logic and functionality of the application.

### Step 4: Verifying the CI Pipeline

1. **Push to GitHub**:
   - After setting up the CI configuration, I pushed the project to GitHub. This triggered the workflow, allowing me to monitor the CI process directly in GitHub.

2. **Monitoring the Workflow**:
   - I navigated to the **Actions** tab in my GitHub repository to monitor the execution of the workflow.
   - I confirmed that the pipeline ran successfully, with all steps completed, verifying that dependencies were restored, the project was built without issues, and all tests passed as expected.

---

## Conclusion

This document outlines my choices and the setup steps I followed to implement continuous integration for CasaCue using GitHub Actions and xUnit with .NET 8. With this configuration, all code changes are now automatically built and tested, maintaining high-quality standards and reliability throughout the project lifecycle.

For further details, refer to the main [README](../README.md).