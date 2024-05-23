using System;

namespace CutTool
{
    /// <summary>
    /// Simple logger class for logging messages to the console.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logs the specified message to the console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message)
        {
            Console.WriteLine($"[ERROR] {message}");
        }
    }
}
