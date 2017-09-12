mkdir .paket
cd .paket 
curl -L -O https://github.com/fsprojects/Paket/releases/download/5.94.0/paket.bootstrapper.exe 
paket.bootstrapper.exe
cd .. 
.paket\paket.exe convert-from-nuget 
echo.>> paket.dependencies
echo nuget Fake >> paket.dependencies
.paket\paket.exe install
dir /s fake.exe

dotnet restore
dotnet build