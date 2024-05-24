using System;

namespace CutTool
{
    /// <summary>
    /// Static class responsible for parsing command-line arguments.
    /// </summary>
    public static class InputParser
    {
        /// <summary>
        /// Parses the command-line arguments and extracts the file path.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>The file path.</returns>
        public static string ParseFilePath(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: dotnet run <file_path> [-field <field_list> [<delimiter>]] [-delim <delimiter>]");
                Environment.Exit(1);
            }
            return args[0];
        }

        /// <summary>
        /// Parses the command-line arguments and extracts the delimiter if specified.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>The delimiter.</returns>
        public static string ParseDelimiter(string[] args)
        {
            for (int i = 1; i < args.Length - 1; i++)
            {
                if (args[i] == "-delim")
                {
                    return args[i + 1];
                }
            }
            return "\t"; // Default delimiter
        }

        /// <summary>
        /// Parses the command-line arguments and extracts the field list if specified.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>The field list as an array of integers.</returns>
        public static int[] ParseFieldList(string[] args)
        {
            for (int i = 1; i < args.Length - 1; i++)
            {
                if (args[i] == "-field")
                {
                    // Parse the field list
                    string[] fieldListStr = args[i + 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] fieldList = new int[fieldListStr.Length];
                    for (int j = 0; j < fieldListStr.Length; j++)
                    {
                        if (!int.TryParse(fieldListStr[j], out fieldList[j]) || fieldList[j] <= 0)
                        {
                            Console.WriteLine("Field list must contain valid positive integers.");
                            Environment.Exit(1);
                        }
                    }
                    return fieldList;
                }
            }
            return null;
        }

        /// <summary>
        /// Parses the command-line arguments and checks if the unique flag is specified.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>True if the unique flag is specified, otherwise false.</returns>
        public static bool ParseUniqueFlag(string[] args)
        {
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] == "-uniq")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
