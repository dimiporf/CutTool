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
                Console.WriteLine("Usage: CutTool <file> -f<field_number>");
                return;
            }

            string filePath = args[0];
            string cutOption = args[1];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            if (!cutOption.StartsWith("-f") || !int.TryParse(cutOption.Substring(2), out int fieldNumber) || fieldNumber < 1)
            {
                Console.WriteLine("Invalid cut option. Use format '-f<field_number>' where field_number is an integer greater than 0.");
                return;
            }

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string result = ExtractField(line, fieldNumber);
                        if (result != null)
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        static string ExtractField(string line, int fieldNumber)
        {
            var fields = line.Split('\t');
            if (fields.Length >= fieldNumber)
            {
                return fields[fieldNumber - 1];
            }
            else
            {
                Console.WriteLine($"Line '{line}' does not have {fieldNumber} fields.");
                return null;
            }
        }
    }
}
