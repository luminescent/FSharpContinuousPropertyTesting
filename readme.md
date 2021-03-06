# Continuous Property Testing with F#, FsCheck and Fake 

This project is the subject of a lightning talk for Progressive .NET 2017 

A few details on property testing:
  * [Property Testing](https://en.wikipedia.org/wiki/Property_testing) - definition. Further extensive documentation at [propertesting](http://propertesting.com)
  * [FsCheck](https://github.com/fscheck/FsCheck) - F# library for property testing 

How to set up Fake and paket from scratch (TBD). 

  * Create the .NET core projects with their required dependencies (run `CreateProjects.cmd your-project-name`)

```
mkdir %1\src\FizzBuzz
mkdir %1\tests 
cd %1\src\FizzBuzz 
dotnet new console -lang F#
cd ..\..\..\%1\tests
dotnet new xunit -lang F# 
dotnet add package FsCheck
dotnet add package FsCheck.Xunit
dotnet add reference ..\src\FizzBuzz\FizzBuzz.fsproj
cd ..
dotnet new sln 
dotnet sln add src\FizzBuzz\FizzBuzz.fsproj
dotnet sln add tests\tests.fsproj

dotnet restore
dotnet build  
```  

  * Migrate to paket and install Fake (run `InstallPaketAndFake.cmd` from the newly created solution folder) 

```
mkdir .paket
cd .paket 
curl -L -O https://github.com/fsprojects/Paket/releases/download/5.94.0/paket.bootstrapper.exe 
paket.bootstrapper.exe
.paket\paket.exe convert-from-nuget 
echo.>> paket.dependencies
echo nuget Fake >> paket.dependencies
.paket\paket.exe install
dir /s fake.exe

dotnet restore
dotnet build
```

  * The build scrips 

Put `build.fsx` and `build.cmd` in the solution folder. The first is the `Fake` build file. `build.cmd` calls on targets from the build file. Call `build.cmd Build` to run the build, and `build.cmd Watch` to run builds and tests continuously. 

### Talk Outlined

Goal: wire up `paket` and `Fake` to do continuous testing and work through a few examples of property based testing with `FsCheck`.

Get to know the audience: who has used F#? Paket? Fake? Property-based-testing?

Set up the projects as explained above.  

Current situation in the industry: example based testing.

Definiton of property testing: what is a property? How does that change our way of thinking when writing tests? Property is a relationship between the input and the output of a function. Why? Generate random input to cover a multitude of scenarios. Examples of properties: adding items to shopping carts, 0 as a neutral element for addition etc. 

More involved example: shuffle function!

Coding examples - FizzBuzz, max element of array