using System;
using System.IO;

namespace CutTool
{
    /// <summary>
    /// Static class responsible for file processing operations.
    /// </summary>
    public static class FileProcessor
    {
        /// <summary>
        /// Validates if the specified file exists.
        /// </summary>
        /// <param name="filePath">The path to the file to be validated.</param>
        /// <returns>True if the file exists, otherwise false.</returns>
        public static bool ValidateFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Processes the specified file, extracting the specified field (column) for each line and printing it to the console.
        /// </summary>
        /// <param name="filePath">The path to the file to be processed.</param>
        /// <param name="fieldNumber">The number of the field (column) to be extracted.</param>
        /// <param name="delimiter">The delimiter used to separate fields (columns) in the file.</param>
        public static void ProcessFile(string filePath, int fieldNumber, string delimiter = null)
        {
            try
            {
                // If delimiter is not provided, use tab or comma based on the file content
                if (delimiter == null)
                {
                    delimiter = DetermineDelimiter(filePath);
                }

                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string result = ExtractField(line, fieldNumber, delimiter);
                        if (result != null)
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error reading file: {ex.Message}");
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        /// <summary>
        /// Determines the delimiter used in the file based on its contents.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>The delimiter used in the file.</returns>
        public static string DetermineDelimiter(string filePath)
        {
            // Read the first line of the file to determine the delimiter
            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                if (line.Contains(","))
                {
                    return ",";
                }
                else if (line.Contains("\t"))
                {
                    return "\t";
                }
                else
                {
                    // If neither comma nor tab found, default to tab delimiter
                    Console.WriteLine("Neither comma nor tab delimiter found. Defaulting to tab delimiter.");
                    return "\t";
                }
            }
        }



        /// <summary>
        /// Extracts the specified field (column) from the given line using the specified delimiter.
        /// </summary>
        /// <param name="line">The line from which the field is to be extracted.</param>
        /// <param name="fieldNumber">The number of the field (column) to be extracted.</param>
        /// <param name="delimiter">The delimiter used to separate fields (columns) in the line.</param>
        /// <returns>The extracted field, or null if the line does not have enough fields.</returns>
        private static string ExtractField(string line, int fieldNumber, string delimiter)
        {
            var fields = line.Split(new string[] { delimiter }, StringSplitOptions.None);
            if (fields.Length >= fieldNumber)
            {
                return fields[fieldNumber - 1];
            }
            else
            {
                Logger.Log($"Line '{line}' does not have {fieldNumber} fields.");
                return null;
            }
        }
    }
}
