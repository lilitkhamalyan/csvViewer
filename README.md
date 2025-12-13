# csvViewer

Small WinForms CSV viewer (C# / .NET 8).

A lightweight application that loads a CSV file into a `DataGridView`, shows file/parse errors via a custom dialog, and writes logs/telemetry to `./Logs`. Intended for quick inspection of CSV data.

## Features
- Open a single `.csv` file from an __OpenFileDialog__.
- Display CSV content in a `DataGridView`.
- Double-click a cell to show its value in a dialog.
- Error and telemetry logging to `Logs\ErrorLogs.txt` and `Logs\Telemetry.txt`.

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or newer (recommended)
- Windows (WinForms)

## Usage
1. Click `Select File`.
2. Choose a `.csv` file (the dialog is filtered to `.csv`).
3. The file is parsed and presented in the grid.
4. Double-click any cell to view the value.

If an invalid file is selected or parsing fails, the app logs the error and displays a dialog.

## Important files
- `csvViewer\MainForm.cs` — main form logic and CSV loading.
- `csvViewer\MainForm.Designer.cs` — layout and `DataGridView` configuration.
- `csvViewer\CustomMessageBox.cs` — custom dialog used for messages.
- `csvViewer\HelperMethods.cs` — helper that shows the custom dialog.
- `csvViewer\Logger.cs` — simple file-based logger / telemetry.
- `csvViewer\Program.cs` — application entry (calls `Logger.Initialize`).

## Logging
Logs are written to the application startup folder under `Logs`:
- `Logs\ErrorLogs.txt` — error messages
- `Logs\Telemetry.txt` — telemetry messages

If logging fails, `Logger` should fallback silently (check `Logger.cs` implementation).