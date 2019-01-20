ECHO OFF
rem dotnet tool install fake-cli --tool-path .

fake run build.fsx

exit /b %errorlevel%

ECHO ON 