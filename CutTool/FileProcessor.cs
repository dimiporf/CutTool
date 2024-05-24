using System;
using System.Collections.Generic;
using System.IO;

namespace CutTool
{
    // Static class to handle file processing
    public static class FileProcessor
    {
        // Method to process the file with specified delimiter and unique flag, without specifying fields
        public static void ProcessFile(string filePath, string delimiter, bool unique)
        {
            // Call the overloaded ProcessFile method with null for fieldNumbers
            ProcessFile(filePath, null, delimiter, unique);
        }

        // Overloaded method to process the file with specified fields, delimiter, and unique flag
        public static void ProcessFile(string filePath, int[] fieldNumbers, string delimiter, bool unique)
        {
            try
            {
                // HashSet to keep track of seen values if unique flag is true
                var seenValues = new HashSet<string>();

                // StreamReader to read the file line by line
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    // Read each line from the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into fields based on the specified delimiter
                        string[] fields = line.Split(new string[] { delimiter }, StringSplitOptions.None);

                        // Construct the output line with the specified fields
                        string outputLine = "";
                        if (fieldNumbers != null)
                        {
                            // If specific fields are specified, concatenate them
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
                            // If no specific fields are specified, use the whole line
                            outputLine = string.Join(delimiter, fields);
                        }

                        // Remove the trailing delimiter from the output line
                        if (!string.IsNullOrEmpty(outputLine))
                        {
                            outputLine = outputLine.TrimEnd(delimiter.ToCharArray());

                            // If unique flag is true, print only unique lines
                            if (unique)
                            {
                                if (seenValues.Add(outputLine))
                                {
                                    Console.WriteLine(outputLine);
                                }
                            }
                            else
                            {
                                Console.WriteLine(outputLine);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and print any exceptions that occur
                Logger.Log($"Error reading file: {ex.Message}");
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        // Method to determine the delimiter based on the first line of the file or a specified delimiter
        public static string DetermineDelimiter(string filePath, string specifiedDelimiter = null)
        {
            // If a delimiter is specified, use it
            if (!string.IsNullOrEmpty(specifiedDelimiter))
            {
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
                    // Default to tab delimiter if neither comma nor tab is found
                    Console.WriteLine("Neither comma nor tab delimiter found. Defaulting to tab delimiter.");
                    return "\t";
                }
            }
        }
    }
}
