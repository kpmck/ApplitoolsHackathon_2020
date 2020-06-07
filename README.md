# ApplitoolsHackathon_2020
## Prerequisites
1. Visual Studio 2019 or Visual Studio 2017 with .NET Framework 4.7.2
2. MS Edge Browser Version v83.0.478.45
3. Chrome Browser Version v83
4. Firefox Browser Version > v60

## Getting Started
1. Clone the repository `git clone https://github.com/kpmck/ApplitoolsHackathon_2020.git`
2. Set Applitools API Key one of two ways: 
    1. Hard-code it on line 16 (`config.SetApiKey("");`) in the *ApplitoolsHackathon_2020\Applitools.Tests\base\ApplitoolsBaseTestClass.cs* class 
    2. Create an environment variable key **APPLITOOLS_API_KEY** and make its value your Applitools API key.
3. Navigate to the *ApplitoolsHackathon_2020* directory and open *ApplitoolsHackathon_2020.sln* 
4. [Restore NuGet packages](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore#:~:text=Enable%20package%20restore%20by%20choosing,and%20select%20Restore%20NuGet%20Packages.).
5. Build the solution. Close Visual Studio.

## To Run Tests From Batch File
1. Navigate to the *ApplitoolsHackathon_2020* directory.
2. Run TestRunner.bat file.
3. When it prompts you, indicate which version and method you wish to run the test:
    - **mod_1** => Modern tests will be executed against version 1 of the site
    - **mod_2** => Modern tests will be executed against version 2 of the site
    - **trad_1** => Traditional tests will be executed against version 1 of the site
    - **trad_2** => Traditional tests will be executed against version 2 of the site
4. NUnit console runner will execute tests and indicate completion. Traditional tests will output to their respective results .txt file in the *ApplitoolsHackathon_2020* directory.  
  
## To Run Tests Within Visual Studio
1. Navigate to the *ApplitoolsHackathon_2020* directory.
2. Open Visual Studio and execute desired tests in Visual Studio's Test Explorer. Each test is smart enough to determine which site it should run against!
- **NOTE**: Only traditional tests will output to their respective results .txt file in the *ApplitoolsHackathon_2020* directory.

## Link to Applitools Results Dashboard
[Click Here!](https://eyes.applitools.com/app/test-results/00000251810797155971?accountId=Zsy_AH1idUW9od97n7Ui9Q~~&display=gallery&top=00000251810797101103%286%29)
