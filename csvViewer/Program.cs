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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Create main form and initialize logger.
            var mainForm = new formCsvViewer();
            Logger.Initialize(mainForm);
            Application.Run(mainForm);
        }
    }
}