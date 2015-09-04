if not exist %cd%\..\Bin\NugetPackage (mkdir %cd%\..\Bin\NugetPackage)

%cd%\Nuget.exe pack %cd%\AdoExecutor.nuspec -BasePath %cd%\..\ -OutputDirectory %cd%\..\Bin\NugetPackage
%cd%\Nuget.exe pack %cd%\AdoExecutor.StrongName.nuspec -BasePath %cd%\..\ -OutputDirectory %cd%\..\Bin\NugetPackage
pause