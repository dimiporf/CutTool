using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CutTool
{
    /// <summary>
    /// Static class responsible for file processing operations.
    /// </summary>
    public static class FileProcessor
    {
        /// <summary>
        /// Processes the specified file, extracting the specified fields (columns) for each line and printing them to the console.
        /// </summary>
        /// <param name="filePath">The path to the file to be processed.</param>
        /// <param name="fieldNumbers">The numbers of the fields (columns) to be extracted.</param>
        /// <param name="delimiter">The delimiter used to separate fields (columns) in the file.</param>
        /// <param name="unique">Whether to output only unique lines.</param>
        public static void ProcessFile(string filePath, int[] fieldNumbers, string delimiter, bool unique = false)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var lines = new List<string>();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(new string[] { delimiter }, StringSplitOptions.None);

                        // Construct the output line with the specified fields
                        string outputLine = "";
                        if (fieldNumbers != null)
                        {
                            foreach (int fieldNumber in fieldNumbers)
                            {
                                if (fieldNumber > 0 && fieldNumber <= fields.Length)
                                {
                                    outputLine += fields[fieldNumber - 1] + delimiter;
                                }
                            }
                        }
                        else
                        {
                            outputLine = string.Join(delimiter, fields);
                        }

                        // Remove the trailing delimiter and add to lines list
                        if (!string.IsNullOrEmpty(outputLine))
                        {
                            outputLine = outputLine.TrimEnd(delimiter.ToCharArray());
                            lines.Add(outputLine);
                        }
                    }

                    if (unique)
                    {
                        lines = lines.Distinct().ToList();
                    }

                    foreach (var outputLine in lines)
                    {
                        Console.WriteLine(outputLine);
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
        /// Processes the specified file, extracting all fields (columns) for each line and printing them to the console.
        /// </summary>
        /// <param name="filePath">The path to the file to be processed.</param>
        /// <param name="delimiter">The delimiter used to separate fields (columns) in the file.</param>
        /// <param name="unique">Whether to output only unique lines.</param>
        public static void ProcessFile(string filePath, string delimiter, bool unique = false)
        {
            ProcessFile(filePath, null, delimiter, unique);
        }

        /// <summary>
        /// Determines the delimiter used in the file based on its contents.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <param name="specifiedDelimiter">The delimiter specified by the user.</param>
        /// <returns>The delimiter used in the file.</returns>
        public static string DetermineDelimiter(string filePath, string specifiedDelimiter = null)
        {
            // Check if a specified delimiter is provided
            if (!string.IsNullOrEmpty(specifiedDelimiter))
            {
                // Return the specified delimiter
                return specifiedDelimiter;
            }

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
    }
}
