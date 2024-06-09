namespace Barangay_blotter
{
    partial class sample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            table = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            SuspendLayout();
            // 
            // table
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            table.ColumnHeadersHeight = 45;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            table.DefaultCellStyle = dataGridViewCellStyle3;
            table.GridColor = Color.FromArgb(231, 229, 255);
            table.Location = new Point(40, 83);
            table.Name = "table";
            table.RowHeadersVisible = false;
            table.RowTemplate.Height = 25;
            table.Size = new Size(721, 331);
            table.TabIndex = 0;
            table.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            table.ThemeStyle.AlternatingRowsStyle.Font = null;
            table.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            table.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            table.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            table.ThemeStyle.BackColor = Color.White;
            table.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            table.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            table.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            table.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            table.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            table.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            table.ThemeStyle.HeaderStyle.Height = 45;
            table.ThemeStyle.ReadOnly = false;
            table.ThemeStyle.RowsStyle.BackColor = Color.White;
            table.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            table.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            table.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            table.ThemeStyle.RowsStyle.Height = 25;
            table.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            table.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // sample
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(table);
            Name = "sample";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "sample";
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView table;
    }
}