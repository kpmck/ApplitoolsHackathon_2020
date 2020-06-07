@echo off
Path = %SystemRoot%\system32;

@echo off
set myPath=%cd%
dir %myPath%\configs\runners

@echo off
set debugDir=%myPath%\Applitools.Tests\bin\Debug

@echo off
set /p version=Enter a version from above to set version of site to run tests against:

IF [%version%]==[] (
	dir %myPath%\configs
) else (
	xcopy /e /v /s /y %myPath%\configs\runners\%version% %debugDir%
	xcopy /e /v /s /y %myPath%\packages\NUnit.ConsoleRunner.3.11.1\tools %debugDir%
)
start %debugDir%\runner.bat
