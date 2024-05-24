using System;

namespace CutTool
{
    /// <summary>
    /// Main program class responsible for parsing command-line arguments and invoking file processing.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = InputParser.ParseFilePath(args);
            string delimiter = InputParser.ParseDelimiter(args);
            int[] fieldList = InputParser.ParseFieldList(args);
            bool unique = InputParser.ParseUniqueFlag(args);

            // If no delimiter is provided, determine the delimiter based on the file content
            if (delimiter == "\t")
            {
                delimiter = FileProcessor.DetermineDelimiter(filePath);
            }

            if (fieldList != null)
            {
                // Process the file with the specified field list and delimiter
                FileProcessor.ProcessFile(filePath, fieldList, delimiter, unique);
            }
            else
            {
                // Process the file without specifying fields (returns all fields) and with the specified delimiter
                FileProcessor.ProcessFile(filePath, delimiter, unique);
            }
        }
    }
}
