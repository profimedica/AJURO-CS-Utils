### C# Business-agnostic utilities.

No business-specific code. Pure utilities.

### Good prectices advice

Keep business specific isolated from all support code.

Organize support code on topics and keep a good isolation of concerns.


# Logging

Working on multipe items might take a while. Be gente with the user and let him know about the processing progress.

### Output Sample

Here a sample of logging the progress to console

```
There are 35121 files to mark
35121 C:\PRO\ANG\AJURO-seed-Angular-HTTPClient\angular-cli\gulpfile.js [in 3 miliseconds]
35120 C:\PRO\ANG\AJURO-seed-Angular-HTTPClient\angular-cli\karma.conf.js [in 12 miliseconds]
35119 C:\PRO\ANG\AJURO-seed-Angular-HTTPClient\angular-cli\protractor.conf.js [in 54 miliseconds]
35118 C:\PRO\ANG\AJURO-seed-Angular-HTTPClient\angular-cli\e2e\app.e2e-spec.ts [in 1 miliseconds]
35117 C:\PRO\ANG\AJURO-seed-Angular-HTTPClient\angular-cli\e2e\app.po.ts 26%
```

Step 1:

Create an instance of the LoggingSystem
```
AJURO_CS_Utils.LoggingSystem ajuroLoggingSystemForProcessingFiles = new AJURO_CS_Utils.LoggingSystem();
```

Step 2:

Let the LoggingSystem know how many objects you have and, optionally, how do you prefer to call them:
```
ajuroLoggingSystemForProcessingFiles.CountChanged(allPaths.Count, "file", "mark");
```

Step 3:

Let the LoggingSystem know when you start processing a new item. 
```
ajuroLoggingSystemForProcessingFiles.IndexChanged(i, path);
Stopwatch stopWatch = new Stopwatch();
long initialMiliseconds = stopWatch.ElapsedMilliseconds;
foreach (string path in allPaths)
{
	stopWatch.Start();
	// Do some magic
	stopWatch.Stop();
	long currentMiliseconds = stopWatch.ElapsedMilliseconds - initialMiliseconds;
	initialMiliseconds = stopWatch.ElapsedMilliseconds;
}
ajuroLoggingSystemForProcessingFiles.IndexCompleted(currentMiliseconds);
```

Step 4:

Let the LoggingSystem know about the progress of big files.
```
// Show the progress
for (int i = 0; i < fileContent.Length; i++)
{
	if (fileContent.Length > 10000)
	{
		int percentCompleted = i/ (fileContent.Length / 100);
		if ( lastPercentage != percentCompleted && i % 100 == 0 )
		{
			ajuroLoggingSystemForProcessingFiles.ItemPercentChanged(percentCompleted);
			lastPercentage = percentCompleted;
		}
	}
}
```

# Time

Convert elapsed miliseconds to readable elapsed time

Output Example:
```
2 days 4 hours 13 minutes 5 seconds and 876 miliseconds
15 seconds and 12 miliseconds
```

# Files

Recursively map a function over the files with specified file extension.

Call Example
```
files.RecursiveProcess(@"C:\PRO\ANG\AJURO-seed-Angular-HTTPClient\angular-cli", new List<string>() { "js", "ts" }, true, MyFunctions);
```
