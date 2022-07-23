namespace BillingSystem.CustomControl
{
    partial class ctl_SalesReport
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgInvoiceItem = new System.Windows.Forms.DataGridView();
            this.dgInvoice = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBrowes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pFromDate = new System.Windows.Forms.DateTimePicker();
            this.pToDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 102);
            this.panel1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(20, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(874, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "This is the basic horizontal form with labels on left and cost estimation form is" +
    " the default position";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 30);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgInvoiceItem);
            this.panel2.Controls.Add(this.dgInvoice);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnBrowes);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pFromDate);
            this.panel2.Controls.Add(this.pToDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 318);
            this.panel2.TabIndex = 27;
            // 
            // dgInvoiceItem
            // 
            this.dgInvoiceItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceItem.Location = new System.Drawing.Point(683, 216);
            this.dgInvoiceItem.Name = "dgInvoiceItem";
            this.dgInvoiceItem.Size = new System.Drawing.Size(288, 150);
            this.dgInvoiceItem.TabIndex = 28;
            // 
            // dgInvoice
            // 
            this.dgInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoice.Location = new System.Drawing.Point(365, 216);
            this.dgInvoice.Name = "dgInvoice";
            this.dgInvoice.Size = new System.Drawing.Size(295, 150);
            this.dgInvoice.TabIndex = 27;
            this.dgInvoice.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgInvoice_RowHeaderMouseDoubleClick);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoEllipsis = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(69, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 34);
            this.label5.TabIndex = 25;
            this.label5.Text = "TO :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(74, 241);
            this.button1.MaximumSize = new System.Drawing.Size(120, 35);
            this.button1.MinimumSize = new System.Drawing.Size(120, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 26;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnBrowes
            // 
            this.btnBrowes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowes.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBrowes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrowes.Location = new System.Drawing.Point(218, 241);
            this.btnBrowes.MaximumSize = new System.Drawing.Size(120, 35);
            this.btnBrowes.MinimumSize = new System.Drawing.Size(120, 40);
            this.btnBrowes.Name = "btnBrowes";
            this.btnBrowes.Size = new System.Drawing.Size(120, 40);
            this.btnBrowes.TabIndex = 25;
            this.btnBrowes.Text = "Browes";
            this.btnBrowes.UseVisualStyleBackColor = false;
            this.btnBrowes.Click += new System.EventHandler(this.btnBrowes_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(69, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 34);
            this.label4.TabIndex = 26;
            this.label4.Text = "FROM :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pFromDate
            // 
            this.pFromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pFromDate.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.pFromDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pFromDate.Location = new System.Drawing.Point(305, 109);
            this.pFromDate.MinimumSize = new System.Drawing.Size(642, 34);
            this.pFromDate.Name = "pFromDate";
            this.pFromDate.Size = new System.Drawing.Size(642, 34);
            this.pFromDate.TabIndex = 17;
            // 
            // pToDate
            // 
            this.pToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pToDate.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.pToDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pToDate.Location = new System.Drawing.Point(305, 176);
            this.pToDate.MinimumSize = new System.Drawing.Size(642, 34);
            this.pToDate.Name = "pToDate";
            this.pToDate.Size = new System.Drawing.Size(642, 34);
            this.pToDate.TabIndex = 17;
            // 
            // ctl_SalesReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ctl_SalesReport";
            this.Size = new System.Drawing.Size(1009, 318);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBrowes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker pFromDate;
        private System.Windows.Forms.DateTimePicker pToDate;
        private System.Windows.Forms.DataGridView dgInvoiceItem;
        private System.Windows.Forms.DataGridView dgInvoice;
    }
}
