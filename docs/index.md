### C# Business-agnostic utilities.

No business-specific code. Pure utilities.

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

# Logging

Working on multipe items might take a while. Be gente with the user and let him know about the processing progress.

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