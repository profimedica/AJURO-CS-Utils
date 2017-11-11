Logging the progress of processing items

Completion percentge - A progresive info at end of line

Sample:

3 files to process
3 Item1 [in 6 seconds and 200 milliseconds]
2 Item1 26%

Usage:



            // 
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