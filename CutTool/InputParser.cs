namespace CutTool
{
    // Static class to handle parsing of command-line arguments
    public static class InputParser
    {
        // Method to parse the file path from the command-line arguments
        public static string ParseFilePath(string[] args)
        {
            // If there are arguments, the first one is assumed to be the file path
            return args.Length > 0 ? args[0] : null;
        }

        // Method to parse the delimiter from the command-line arguments
        public static string ParseDelimiter(string[] args)
        {
            // Iterate through the arguments to find the "-delim" option
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == "-delim")
                {
                    // Return the delimiter value following the "-delim" option
                    return args[i + 1];
                }
            }
            return "\t"; // Default to tab delimiter if not specified
        }

        // Method to parse the list of fields to extract from the command-line arguments
        public static int[] ParseFieldList(string[] args)
        {
            // Iterate through the arguments to find the "-field" option
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == "-field")
                {
                    // Split the field list string by commas and remove empty entries
                    string[] fieldListStr = args[i + 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] fieldList = new int[fieldListStr.Length];
                    // Convert each field number from string to integer
                    for (int j = 0; j < fieldListStr.Length; j++)
                    {
                        if (!int.TryParse(fieldListStr[j], out fieldList[j]) || fieldList[j] <= 0)
                        {
                            // If conversion fails or number is not positive, display an error
                            Console.WriteLine("Field list must contain valid positive integers.");
                            return null;
                        }
                    }
                    return fieldList; // Return the list of field numbers
                }
            }
            return null; // Return null if "-field" option is not found
        }

        // Method to check if the unique flag ("-uniq") is present in the command-line arguments
        public static bool ParseUniqueFlag(string[] args)
        {
            // Iterate through the arguments to find the "-uniq" option
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-uniq")
                {
                    // Return true if "-uniq" is found
                    return true;
                }
            }
            return false; // Return false if "-uniq" is not found
        }
    }
}
