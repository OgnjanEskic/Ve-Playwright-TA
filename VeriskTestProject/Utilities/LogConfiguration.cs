using Serilog;

namespace VeriskTestProject.Utilities
{
    /// <summary>
    /// Creation of the logger used throughout tests and application.
    /// </summary>
    public static class LogConfiguration
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public static ILogger Logger { get; private set; } = null!;

        /// <summary>
        /// Instantiate the logger if the logger is missing.
        /// </summary>
        public static void InitializeLogger()
        {
            Logger ??= new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
