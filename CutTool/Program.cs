using System;

namespace CutTool
{
    // Main program class responsible for parsing command-line arguments and invoking file processing
    class Program
    {
        // Main method
        static void Main(string[] args)
        {
            // Parse command-line arguments using the InputParser class
            string filePath = InputParser.ParseFilePath(args); // Parse file path
            string delimiter = InputParser.ParseDelimiter(args); // Parse delimiter
            int[] fieldList = InputParser.ParseFieldList(args); // Parse field list
            bool unique = InputParser.ParseUniqueFlag(args); // Parse unique flag

            // If no delimiter is provided, determine the delimiter based on the file content
            if (delimiter == "\t")
            {
                delimiter = FileProcessor.DetermineDelimiter(filePath);
            }

            // Check if field list is specified
            if (fieldList != null)
            {
                // Process the file with the specified field list, delimiter, and unique flag
                FileProcessor.ProcessFile(filePath, fieldList, delimiter, unique);
            }
            else
            {
                // Process the file with all fields, delimiter, and unique flag
                FileProcessor.ProcessFile(filePath, delimiter, unique);
            }

            // Check for the -count flag
            bool count = Array.Exists(args, arg => arg == "-count");
            if (count && fieldList != null)
            {
                foreach (int fieldNumber in fieldList)
                {
                    // If unique flag is specified, display and count unique values
                    if (unique)
                    {
                        FileProcessor.DisplayAndCountUniqueValues(filePath, fieldNumber, delimiter);
                    }
                    else
                    {
                        // Otherwise, count all values including duplicates
                        FileProcessor.CountAllValues(filePath, fieldNumber, delimiter);
                    }
                }
            }
        }
    }
}
