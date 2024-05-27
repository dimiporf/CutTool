namespace CutTool
{
    // Static class to handle parsing of command-line arguments
    public static class InputParser
    {
        // Method to parse the file path from the command-line arguments
        public static string ParseFilePath(string[] args)
        {
            // If there are arguments, the first one is assumed to be the file path
            // Check if there are any arguments passed
            if (args.Length > 0)
            {
                // Return the first argument as the file path
                return args[0];
            }
            else
            {
                // If no arguments are passed, return null
                return null;
            }
        }

        // Method to parse the delimiter from the command-line arguments
        public static string ParseDelimiter(string[] args)
        {
            // Iterate through the arguments to find the "-delim" option
            for (int i = 0; i < args.Length - 1; i++)
            {
                // Check if the current argument is "-delim"
                if (args[i] == "-delim")
                {
                    // Return the delimiter value that follows the "-delim" option
                    return args[i + 1];
                }
            }
            // If no delimiter is specified, default to tab delimiter
            return "\t";
        }

        // Method to parse the list of fields to extract from the command-line arguments
        public static int[] ParseFieldList(string[] args)
        {
            // Iterate through the arguments to find the "-field" option
            for (int i = 0; i < args.Length - 1; i++)
            {
                // Check if the current argument is "-field"
                if (args[i] == "-field")
                {
                    // Split the field list string by commas and remove any empty entries
                    string[] fieldListStr = args[i + 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    // Create an integer array to store the field numbers
                    int[] fieldList = new int[fieldListStr.Length];
                    // Convert each field number from string to integer
                    for (int j = 0; j < fieldListStr.Length; j++)
                    {
                        // Try to parse the field number and check if it's a valid positive integer
                        if (!int.TryParse(fieldListStr[j], out fieldList[j]) || fieldList[j] <= 0)
                        {
                            // If conversion fails or number is not positive, display an error message
                            Console.WriteLine("Field list must contain valid positive integers.");
                            // Return null to indicate an error
                            return null;
                        }
                    }
                    // Return the list of field numbers
                    return fieldList;
                }
            }
            // If "-field" option is not found, return null
            return null;
        }

        // Method to check if the unique flag ("-uniq") is present in the command-line arguments
        public static bool ParseUniqueFlag(string[] args)
        {
            // Iterate through the arguments to find the "-uniq" option
            for (int i = 0; i < args.Length; i++)
            {
                // Check if the current argument is "-uniq"
                if (args[i] == "-uniq")
                {
                    // Return true if "-uniq" is found
                    return true;
                }
            }
            // If "-uniq" is not found, return false
            return false;
        }

        // Method to check if the count flag ("-count") is present in the command-line arguments
        public static bool ParseCountFlag(string[] args)
        {
            // Iterate through the arguments to find the "-count" option
            for (int i = 0; i < args.Length; i++)
            {
                // Check if the current argument is "-count"
                if (args[i] == "-count")
                {
                    // Return true if "-count" is found
                    return true;
                }
            }
            // If "-count" is not found, return false
            return false;
        }
    }
}
