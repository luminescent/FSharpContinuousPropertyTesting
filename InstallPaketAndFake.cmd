mkdir .paket 
copy ..\progressive-net-talk\.paket\paket.bootstrapper.exe 
cd .paket
paket.bootstrapper.exe
.paket\paket.exe convert-from-nuget 
echo.>> paket.dependencies
echo nuget Fake >> paket.dependencies
.paket\paket.exe install
dir /s fake.exe

dotnet restore
dotnet build