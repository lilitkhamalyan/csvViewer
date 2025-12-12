namespace csvViewer
{
    partial class formCsvViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectFile = new Button();
            openFileDialog = new OpenFileDialog();
            dgvTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(713, 366);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 23);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Title = "Select a CSV file";
            openFileDialog.FileOk += openFileDialog_FileOk;
            // 
            // dgvTable
            // 
            dgvTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTable.Location = new Point(12, 12);
            dgvTable.Name = "dgvTable";
            dgvTable.Size = new Size(776, 348);
            dgvTable.TabIndex = 1;
            dgvTable.CellDoubleClick += dgvTable_CellDoubleClick;
            // 
            // formCsvViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 401);
            Controls.Add(dgvTable);
            Controls.Add(btnSelectFile);
            Name = "formCsvViewer";
            Text = "CSV Viewer";
            ((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectFile;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvTable;
    }
}
