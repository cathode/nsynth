if exist %SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319 set MSBUILDPATH=%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319
if exist %SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319 set MSBUILDPATH=%SYSTEMROOT%\Microsoft.NET\Framework64\v4.0.30319

%MSBUILDPATH%\msbuild.exe NSynth.MSBuild