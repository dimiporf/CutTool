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
            // Check if at least two arguments are provided
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: dotnet run <file_path> <field_number> [<delimiter>]");
                return;
            }

            string filePath = args[0];
            int fieldNumber;

            // Parse field number from second argument
            if (!int.TryParse(args[1], out fieldNumber) || fieldNumber <= 0)
            {
                Console.WriteLine("Field number must be a valid positive integer.");
                return;
            }

            // Use tab as default delimiter
            string delimiter = "\t";

            // Check if delimiter is provided as third argument
            if (args.Length >= 3)
            {
                delimiter = args[2];
            }
            else
            {
                // If no delimiter is provided, determine the delimiter based on the file content
                delimiter = FileProcessor.DetermineDelimiter(filePath);
            }

            // Process the file with the specified field number and delimiter
            FileProcessor.ProcessFile(filePath, fieldNumber, delimiter);
        }

    }
}
