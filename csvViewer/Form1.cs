using System.Data;
using System.Windows.Forms;

namespace csvViewer
{
    public partial class formCsvViewer : Form
    {
        public formCsvViewer()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = openFileDialog.FileName; // The selected file

            // Load CSV into DataTable
            DataTable dt = LoadCsvToDataTable(filePath);

            // Display in DataGridView
            dgvTable.DataSource = dt;

        }

        // Helper method that generates data set from CSV file
        private DataTable LoadCsvToDataTable(string filePath)
        {
            DataTable dt = new DataTable();

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

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            string cellValue = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            openDialog
                (
                  cellValue,
                 $"Cell [{e.RowIndex},{e.ColumnIndex}]"
                );
        }

        private void openDialog(string title, string message)
        {
            CustomMessageBox dialog = new CustomMessageBox(message, title);
            dialog.Location = new Point(
                Cursor.Position.X + 10,
                Cursor.Position.Y + 10
            );
            dialog.ShowDialog(this);
        }
    }
}