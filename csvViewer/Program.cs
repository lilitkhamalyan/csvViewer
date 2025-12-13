namespace csvViewer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Logger.LogTelemetry("Initializing application configuration.");
                ApplicationConfiguration.Initialize();
                Logger.LogTelemetry("Application configuration initialized successfully.");
            }
            catch (Exception ex)
            {
                // If ApplicationConfiguration fails, log to error log file.
                string errorMessage = $"Failed to initialize application configuration: {ex.Message}";
                Logger.LogError(errorMessage);
            }

            // Create main form and initialize logger.
            var mainForm = new formCsvViewer();
            Logger.Initialize(mainForm);
            Logger.LogTelemetry("Application started.");

            Logger.LogTelemetry("Launching main application form.");
            Application.Run(mainForm);
            Logger.LogTelemetry("Application exited.");
        }
    }
}