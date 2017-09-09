mkdir %1\src\FizzBuzz
mkdir %1\tests 
cd %1\src\FizzBuzz 
dotnet new console -lang F#
cd ..\..\..\%1\tests
dotnet new xunit -lang F# 
dotnet add package FsCheck
dotnet add package FsCheck.Xunit
cd ..
dotnet new sln 
dotnet sln add src\FizzBuzz\FizzBuzz.fsproj
dotnet sln add tests\tests.fsproj

dotnet restore
dotnet build  
