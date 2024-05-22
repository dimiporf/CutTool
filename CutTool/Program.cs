using System;
using System.IO;

namespace CutTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CutTool <file> <cut-options>");
                return;
            }

            string filePath = args[0];
            string cutOption = args[1];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string result = ProcessLine(line, cutOption);
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        static string ProcessLine(string line, string cutOption)
        {
            // This is a very basic implementation, assuming cutOption is something like "1-5" to extract characters from 1 to 5.
            // You will need to handle different options based on the `cut` command specification.

            var parts = cutOption.Split('-');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int start) || !int.TryParse(parts[1], out int end))
            {
                Console.WriteLine("Invalid cut option. Use format 'start-end' where start and end are integers.");
                return line;
            }

            if (start < 1 || end < start || end > line.Length)
            {
                Console.WriteLine("Invalid range.");
                return line;
            }

            return line.Substring(start - 1, end - start + 1);
        }
    }
}
