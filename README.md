# Airfi Automation Test
This test project is powered by C#, .NET Core 3.1, and NUnit.
 * NUnit is a unit testing framework for C# and can also be used to facilitate and assemble Selenium tests
# Getting Started
## Pre-requisites
 1. For ease of use, you can install the community version of visual studios and open the cloned project on the IDE; otherwise proceed to the next step
 2. The local machine should have the following redist in order to be able to run the tests without visual studios:
    * Download and install the latest [.NET Core 3.1 version (3.1.404)](https://dotnet.microsoft.com/download/dotnet-core/3.1)
    * Download and install [Visual C++ Redistributable for Visual Studio 2015 (In case of geckodriver)](https://www.microsoft.com/en-in/download//details.aspx?id=48145)
 3. You can now use any source-code editor after downloading the dependencies on step 2 (VS code, Sublime, etc.)
 
## How to run the tests
There are a couple of ways to run the tests;
  1. The first one would be opening the project on visual studios and running the code via Test Explorer.
  2. The second would be via command line using `dotnet test` CLI
### Steps in running the test via CLI
1. Open a Terminal, CMD, etc.
2. After cloning the repo navigate to the project folder `cd ./airfi_automation/`
3. Run dotnet test command `dotnet test`

# Brief explanation on the framework used
There are a lot of articles explaining the benefits of NUnit + Selenium framework, but just to have an idea here are some samples:
  * Annotations used in NUnit help in speeding up test development & execution as tests can be executed with numerous input values.
  * TDD is primarily useful as unit tests and are instrumental in finding issues/bugs during the early stages of product development. NUnit test framework can be used with Selenium if you plan to use TDD (Test Driven Development) for the test activity.
  * It provides you the ability to run your test cases in parallel.
  * Using NUnit, you can execute test cases from console runner by either a third-party automation testing tool or by the NUnit Test Adapter inside the Visual Studio.

With that said, these features that are listed here will help the test project to be more ameanable in terms of chagnes in automation test approach, either we go for TDD, BDD, or DDT. We can adjust the framework according to the organizations needs.

# Test scenario
The test scenario is the CRUD function of the Computer Database site, it will basically do Add, Edit, Delete of items in the table. All the while verifying chagnes and behaviors of the functions within the page.

This test will cover the following scenarios that will be at least 60% of the code coverage:
1. Verify site access and title
2. Verify add computer function
3. Verify table filter function
4. Verify item details access
5. Verify edit function
6. Verify delete function

This tests not only target the majority of the code, but in terms of priority, they ran through all the critical functions in one run.

# Known issues/Limitations
 1. Run time seems to be slow, not sure if this is because of NUnit or Selenium
 2. No logging details yet as per test run only pass/fail
 3. Reports are not yet added for this framework
  
  
