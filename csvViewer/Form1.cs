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

            // Create column headers
            int colCount = lines[0].Split(',').Length;

            for (int i = 0; i < colCount; i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }


            // All lines = data rows
            foreach (string line in lines)
            {
                dt.Rows.Add(line.Split(','));
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

            MessageBox.Show(
                this,
                cellValue,
                $"Cell [{e.RowIndex},{e.ColumnIndex}]"
            );
        }
    }
}

