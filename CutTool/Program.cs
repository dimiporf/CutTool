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
            // Check if at least one argument is provided
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: dotnet run <file_path> [-field <field_list> [<delimiter>]] [-delim <delimiter>]");
                return;
            }

            string filePath = args[0];
            string delimiter = "\t"; // Default delimiter
            bool unique = false;

            // Check for the -delim option
            for (int i = 1; i < args.Length - 1; i++)
            {
                if (args[i] == "-delim")
                {
                    delimiter = args[i + 1];
                    break;
                }
            }

            // Check for the -field option
            int[] fieldList = null;
            for (int i = 1; i < args.Length - 1; i++)
            {
                if (args[i] == "-field")
                {
                    // Parse the field list
                    string[] fieldListStr = args[i + 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    fieldList = new int[fieldListStr.Length];
                    for (int j = 0; j < fieldListStr.Length; j++)
                    {
                        if (!int.TryParse(fieldListStr[j], out fieldList[j]) || fieldList[j] <= 0)
                        {
                            Console.WriteLine("Field list must contain valid positive integers.");
                            return;
                        }
                    }
                    break;
                }
            }

            // Check for the -uniq option
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] == "-uniq")
                {
                    unique = true;
                    break;
                }
            }

            // If no delimiter is provided, determine the delimiter based on the file content
            if (delimiter == "\t")
            {
                delimiter = FileProcessor.DetermineDelimiter(filePath);
            }
            if (fieldList != null)
            {
                // Process the file with the specified field list and delimiter
                FileProcessor.ProcessFile(filePath, fieldList, delimiter);
            }
            else
            {
                // Process the file without specifying fields (returns all fields) and with the specified delimiter
                FileProcessor.ProcessFile(filePath, delimiter);
            }
        }
    }
}
