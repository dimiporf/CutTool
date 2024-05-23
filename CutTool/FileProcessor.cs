using System;
using System.IO;

namespace CutTool
{
    public static class FileProcessor
    {
        public static bool ValidateFile(string filePath)
        {
            return File.Exists(filePath);
        }

        public static void ProcessFile(string filePath, int fieldNumber, string delimiter)
        {
            try
            {
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
