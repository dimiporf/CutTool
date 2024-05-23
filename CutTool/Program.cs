using System;

namespace CutTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log("Application started");

            if (args.Length < 2 || args.Length > 3)
            {
                Logger.Log("Invalid number of arguments");
                Console.WriteLine("Usage: CutTool <file> -f<field_number> [-d<delimiter>]");
                return;
            }

            string filePath = args[0];
            string cutOption = args[1];
            string delimiter = ","; // Default to comma

            if (args.Length == 3 && args[2].StartsWith("-d"))
            {
                delimiter = args[2].Substring(2);
            }

            if (!FileProcessor.ValidateFile(filePath))
            {
                Logger.Log($"File not found: {filePath}");
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            if (!cutOption.StartsWith("-f") || !int.TryParse(cutOption.Substring(2), out int fieldNumber) || fieldNumber < 1)
            {
                Logger.Log("Invalid cut option");
                Console.WriteLine("Invalid cut option. Use format '-f<field_number>' where field_number is an integer greater than 0.");
                return;
            }

            FileProcessor.ProcessFile(filePath, fieldNumber, delimiter);
            Logger.Log("Application finished");
        }
    }
}
