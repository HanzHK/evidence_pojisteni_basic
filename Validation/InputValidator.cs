using System;

namespace evidence_pojisteni_basic.Validation
{
    /// <summary>
    /// Provides input validation methods for user data.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Reads a non-empty string from console input.
        /// </summary>
        /// <param name="prompt">Prompt message to display.</param>
        /// <returns>Validated non-empty string.</returns>
        public static string ReadNonEmptyString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        /// <summary>
        /// Reads a valid integer from console input.
        /// </summary>
        /// <param name="prompt">Prompt message to display.</param>
        /// <returns>Validated integer value.</returns>
        public static int ReadValidInt(string prompt)
        {
            int value;
            bool valid;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                valid = int.TryParse(input, out value);

                if (!valid)
                {
                    Console.WriteLine("Invalid number. Please enter a valid integer.");
                }

            } while (!valid);

            return value;
        }
    }
}
