# How to run and see the code coverage in OpenCover format
## On the Test Folder project solution
``` 
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

# Run ReportGenerator
``` 
.\ReportGenerator.exe "-reports:{project root}\Hangman.Tests\coverage.opencover.xml" "-targetdir:{project root}\Report
```