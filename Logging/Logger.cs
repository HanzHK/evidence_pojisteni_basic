using Serilog;

namespace evidence_pojisteni_basic.Logging
{
    /// <summary>
    /// Provides centralized Serilog configuration.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Initializes Serilog with console and file sinks.
        /// </summary>
        public static void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
