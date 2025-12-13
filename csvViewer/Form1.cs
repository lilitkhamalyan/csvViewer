using System.Data;
using System.Windows.Forms;

namespace csvViewer
{
    public partial class formCsvViewer : Form
    {
        public formCsvViewer()
        {
            try
            {
                Logger.LogTelemetry("Initializing the main form.");
                InitializeComponent();
                Logger.LogTelemetry("Main form successfully initialized.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to initialize form: {ex.Message}");
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            // Restrict dialog to CSV and make selection safer
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ValidateNames = true;

            // Show the dialog
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                // User X-ed out of the dialog
                return; 
            }

            if (dgvTable.DataSource == null)
            {
                HelperMethods.openDialog(
                    "Error",
                    $"Failed to load CSV file. Check the ErrorLog file for details.",
                    this
                );
            }
            else if (((DataTable)dgvTable.DataSource).Rows.Count == 0)
            {
                HelperMethods.openDialog(
                    "Warning",
                    $"Selected file contains no data.",
                    this
                );
            }

        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = openFileDialog.FileName; // The selected file

            // Validate extension before attempting to load
            while (!string.Equals(Path.GetExtension(filePath), ".csv", StringComparison.OrdinalIgnoreCase))
            {
                HelperMethods.openDialog(
                    "Invalid file",
                    "Please select a file with the .csv extension.",
                    this
                );
                e.Cancel = true;
                return;
            }

            // Load CSV into DataTable
            Logger.LogTelemetry("Attempting to load CSV file.");
            DataTable dt = LoadCsvToDataTable(filePath);
            Logger.LogTelemetry("CSV file successfully loaded.");

            // Display in DataGridView
            dgvTable.DataSource = dt;
        }

        // Helper method that generates data set from CSV file
        private DataTable LoadCsvToDataTable(string filePath)
        {
            DataTable dt = new DataTable();

            try
            {
                // Read all lines from the CSV
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    return dt; // Empty CSV
                }

                // Define row valiable to be used inside the loop
                string[] row = null;

                foreach (string line in lines)
                {
                    // Handle rows with different column counts
                    row = line.Split(",");
                    if (row.Length > dt.Columns.Count)
                    {
                        for (int i = dt.Columns.Count; i < row.Length; i++)
                        {
                            dt.Columns.Add("Column" + (i + 1));
                        }
                    }

                    // Add the row
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to load CSV file: {ex.Message}");
            }

            return null;
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            string cellValue = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            HelperMethods.openDialog(
                $"Cell [{e.RowIndex},{e.ColumnIndex}]",
                String.IsNullOrEmpty(cellValue) ? "No data" : cellValue,
                this
            );
        }
    }
}