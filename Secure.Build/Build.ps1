# Fixes exit code bug in PowerShell
trap
{
    write-output $_
    exit 1
}

# If the build computer is not running the appropriate version of .NET, then the build will not run. Throw an error immediately.
if( (ls "$env:windir\Microsoft.NET\Framework\v4.0*") -eq $null ) {
	throw "This project requires .NET 4.0 to compile. Unfortunatly .NET 4.0 doesn't appear to be installed on this machine."
}


# Set up varriables for build script
$invocation = (Get-Variable MyInvocation).Value
$directorypath = Split-Path $invocation.MyCommand.Path
$solutionPath = $directorypath -replace "Secure.Build", ""
$v4_net_version = (ls "$env:windir\Microsoft.NET\Framework\v4.0*").Name
$nl = [Environment]::NewLine

Mkdir -Path "$directorypath\Secure.Tests\bin\debug" -Force
Copy-Item -LiteralPath "$directorypath\Tools\nunit\nunit.framework.dll" "$directorypath\Secure.Tests\bin\debug" -Force 

# Build the project using msbuild.exe.
# note, we've already determined that .NET is already installed on this computer.
cmd /c C:\Windows\Microsoft.NET\Framework\$v4_net_version\msbuild.exe "$solutionPath\Secure.sln" /p:Configuration=Release 
cmd /c C:\Windows\Microsoft.NET\Framework\$v4_net_version\msbuild.exe "$solutionPath\Secure.sln" /p:Configuration=Debug

# Break if the build throws an error.
if(! $?) {
	throw "Fatal error, project build failed"
}


# Good, the build passed
Write-Host "$nl project build passed."  -ForegroundColor Green

# Run the tests.
cmd /c $directorypath\Tools\nunit\nunit-console.exe $solutionPath\Secure.Tests\bin\debug\Secure.Tests.dll

# Break if the tests throw an error.
if(! $?) {
	throw "Test run failed."
}

# Run the console app
cmd /c $solutionPath\Secure.ConsoleApp\Bin\Release\Secure.ConsoleApp.exe