using System;
using evidence_pojisteni_basic.Logging;
using evidence_pojisteni_basic.Services;
using Serilog;

namespace evidence_pojisteni_basic
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that starts the application.
        /// </summary>
        static void Main()
        {
            Logger.Initialize();

            try
            {
                var insuredService = new InsuredService();
                var menu = new MainMenu(insuredService);
                menu.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception occurred.");
                Console.WriteLine("A fatal error occurred. The application will now exit.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
