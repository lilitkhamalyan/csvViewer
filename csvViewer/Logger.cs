using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using csvViewer;

public static class Logger
{
    private static readonly string logFolder = Path.Combine(Application.StartupPath, "Logs");
    private static readonly string logFile = Path.Combine(logFolder, "ErrorLogs.txt");
    private static readonly string telemetryFile = Path.Combine(logFolder, "Telemetry.txt");

    // Call this once at app startup
    public static void Initialize(Form mainForm)
    {
        try
        {
            // Ensure folder exists
            Directory.CreateDirectory(logFolder);

            // Ensure files exist
            if (!File.Exists(logFile))
                File.Create(logFile).Close();

            if (!File.Exists(telemetryFile))
                File.Create(telemetryFile).Close();
        }
        catch (Exception ex)
        {
            string errorMessage = $"Failed to initialize log files: {ex.Message}";
            LogError(errorMessage);
            HelperMethods.openDialog(
                "Error",
                errorMessage,
                mainForm
            );
        }
    }

    // Log an error message
    public static void LogError(string message)
    {
        try
        {
            File.AppendAllText(logFile, $"[{DateTime.Now}] ERROR: {message}{Environment.NewLine}");
        }
        catch
        {
            // Fallback to Event Log if file write fails
            EventLog.WriteEntry("Application", "CsvViewer fallback logging - primary write failed", EventLogEntryType.Error);
        }
    }

    // Log telemetry data
    public static void LogTelemetry(string message)
    {
        try
        {
            File.AppendAllText(telemetryFile, $"[{DateTime.Now}] TELEMETRY: {message}{Environment.NewLine}");
        }
        catch
        {
            LogError("Failed to write telemetry.");
        }
    }
}
