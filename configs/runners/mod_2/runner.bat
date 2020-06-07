Path = %SystemRoot%\system32;
set myPath=%cd%
set debugDir=%myPath%\Applitools.Tests\bin\Debug

cmd /k %debugDir%\nunit3-console %debugDir%\Applitools.Tests.dll --where "cat == modern2" --noresult