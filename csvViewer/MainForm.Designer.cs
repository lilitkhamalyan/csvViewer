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
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectFile.Location = new Point(497, 326);
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
            dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTable.Location = new Point(0, 0);
            dgvTable.Name = "dgvTable";
            dgvTable.Size = new Size(584, 310);
            dgvTable.TabIndex = 1;
            dgvTable.CellDoubleClick += dgvTable_CellDoubleClick;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(416, 326);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // formCsvViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(btnClear);
            Controls.Add(dgvTable);
            Controls.Add(btnSelectFile);
            MinimumSize = new Size(600, 400);
            Name = "formCsvViewer";
            Text = "CSV Viewer";
            ((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectFile;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvTable;
        private Button btnClear;
    }
}
