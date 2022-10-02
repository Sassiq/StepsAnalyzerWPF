# Steps Analyzer

C# WPF Application with MVVM pattern usage.
App analyzes the number of steps taken over a selected period (with plotting) for different users.

Functions:
- View information about users.
- View plot of the selected user progress.
- View "unstable" users, whose average result differs from the best or worst more than 20%. They are marked in red.
- Save user data in different formats. XML and JSON save formats are supported now.

To change TestData folder or save format you can use [appsettings.json](https://github.com/Sassiq/StepsAnalyzerWPF/blob/master/StepsAnalyzer.Presentation/appsettings.json).
Like this:
```
{
	"deserializationPath" : "../../../../TestData",
	"serializationType" : "JSON"
}
```
Optionally, you can make your own appsettings.json in one folder with .exe file of the application.
