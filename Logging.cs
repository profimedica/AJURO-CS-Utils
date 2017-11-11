using System;

namespace AJURO_CS_Utils
{
    public enum InfoLevels
    {
        Time,
        Extended,
        Debug,
        Data
    }

    /*
    public class ConsoleLogStructure
    {
        public long FilesLeft; // Files left to process
        public string FilePath; // Current file path
        public int FilePercentage; // Completion percentage
        public long Miliseconds; // Processing of current file completed in x miliseconds
    }
    */

    // Logging while executting
    public class LoggingSystem
    {

        public InfoLevels InfoLevel = InfoLevels.Debug;

        public long FilesLeft; // Files left to process

        // Total files
        long totalItems = -1;
        public long TotalItems
        {
            get
            {
                return totalItems;
            }
            set
            {
                totalItems = value;
            }
        }
        // Current file index
        int itemIndex = -1;
        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }
            set
            {
                itemIndex = value;
            }
        }

        // Current file path
        string itemName = string.Empty;
        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }

        public void IndexCompleted(long currentMiliseconds)
        {

            if (InfoLevel >= AJURO_CS_Utils.InfoLevels.Time)
            {
                for (int k = 0; k < consoleCharactersToErase; k++)
                {
                    Console.Write("\b \b");
                }
                consoleCharactersToErase = 0;
                Console.Write(" [in " + Time.GetReadableElapsedTime(currentMiliseconds) + "]" + '\n');
            }
        }

        // What type of items we have? Singular.
        string itemType = "item";
        public string ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
            }
        }

        int consoleCharactersToErase = 0;

        public void ItemPercentChanged(int percentCompleted)
        {
            if (InfoLevel >= AJURO_CS_Utils.InfoLevels.Debug)
            {
                for (int k = 0; k < consoleCharactersToErase; k++)
                {
                    Console.Write("\b \b");
                }
                Console.Write(" " + percentCompleted + "%");
            }
            consoleCharactersToErase = 3;
            if (percentCompleted >= 10) { consoleCharactersToErase += 1; }
            if (percentCompleted >= 100) { consoleCharactersToErase += 1; };
        }

        // The name of the processing operation.
        string processType = "process";
        public string ProcessType
        {
            get
            {
                return processType;
            }
            set
            {
                processType = value;
            }
        }

        // Initialize with the number of items this logging is created for
        public LoggingSystem()
        {
        }

        public int FilePercentage; // Completion percentage
        public long Miliseconds; // Processing of current file completed in x miliseconds

        /*
         * @itemIndex the item index
         * */
        public void CountChanged(int totalItems, string itemType, string processType)
        {
            TotalItems = totalItems;
            ItemType = itemType;
            ProcessType = processType;

            if (InfoLevel >= InfoLevels.Debug)
            {
                Console.WriteLine("There are " + TotalItems + " " + ItemType + "s to " + ProcessType + "");
            }
        }
        /*
         * @itemIndex the item index
         * */
        public void IndexChanged(int itemIndex, string itemName)
        {
            ItemName = itemName;
            ItemIndex = itemIndex;

            if (InfoLevel >= InfoLevels.Debug)
            {
                Console.Write(ItemIndex + " " + ItemName);
            }
        }
    }
    
    // Log to console
    public class LogToConsole
    {
    }
}
