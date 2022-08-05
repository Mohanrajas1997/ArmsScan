namespace Chola
{
    partial class frmPacketQue
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.GnsaRefNo_Txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Inward_Todate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Inward_Fromdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.Inward_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GnsaRef_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agreement_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packet_Mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packet_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtLotNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtContractNo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtContractNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtLotNo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnref);
            this.panel1.Controls.Add(this.GnsaRefNo_Txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Inward_Todate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Inward_Fromdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 81);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1028, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(542, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Lot No";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(944, 41);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(860, 41);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 5;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // GnsaRefNo_Txt
            // 
            this.GnsaRefNo_Txt.Location = new System.Drawing.Point(986, 10);
            this.GnsaRefNo_Txt.Name = "GnsaRefNo_Txt";
            this.GnsaRefNo_Txt.Size = new System.Drawing.Size(122, 21);
            this.GnsaRefNo_Txt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(924, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cover No";
            // 
            // Inward_Todate
            // 
            this.Inward_Todate.Checked = false;
            this.Inward_Todate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Todate.Location = new System.Drawing.Point(410, 10);
            this.Inward_Todate.Name = "Inward_Todate";
            this.Inward_Todate.ShowCheckBox = true;
            this.Inward_Todate.Size = new System.Drawing.Size(122, 21);
            this.Inward_Todate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(281, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Packet Recv To Date";
            // 
            // Inward_Fromdate
            // 
            this.Inward_Fromdate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Fromdate.Location = new System.Drawing.Point(152, 10);
            this.Inward_Fromdate.Name = "Inward_Fromdate";
            this.Inward_Fromdate.ShowCheckBox = true;
            this.Inward_Fromdate.Size = new System.Drawing.Size(122, 21);
            this.Inward_Fromdate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Packet Recv From Date";
            // 
            // gvscanlist
            // 
            this.gvscanlist.AllowUserToAddRows = false;
            this.gvscanlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvscanlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Inward_Date,
            this.GnsaRef_No,
            this.Agreement_No,
            this.Packet_Mode,
            this.Status_desc,
            this.Packet_Status});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvscanlist.Location = new System.Drawing.Point(0, 81);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(1134, 324);
            this.gvscanlist.TabIndex = 2;
            this.gvscanlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellClick);
            // 
            // Inward_Date
            // 
            this.Inward_Date.HeaderText = "Received Date";
            this.Inward_Date.Name = "Inward_Date";
            this.Inward_Date.ReadOnly = true;
            // 
            // GnsaRef_No
            // 
            this.GnsaRef_No.HeaderText = "Gnsa Ref No";
            this.GnsaRef_No.Name = "GnsaRef_No";
            this.GnsaRef_No.ReadOnly = true;
            // 
            // Agreement_No
            // 
            this.Agreement_No.HeaderText = "Agreement No";
            this.Agreement_No.Name = "Agreement_No";
            this.Agreement_No.ReadOnly = true;
            // 
            // Packet_Mode
            // 
            this.Packet_Mode.HeaderText = "Packet Mode";
            this.Packet_Mode.Name = "Packet_Mode";
            this.Packet_Mode.ReadOnly = true;
            // 
            // Status_desc
            // 
            this.Status_desc.HeaderText = "Status Desc";
            this.Status_desc.Name = "Status_desc";
            this.Status_desc.ReadOnly = true;
            // 
            // Packet_Status
            // 
            this.Packet_Status.HeaderText = "Packet Remarks";
            this.Packet_Status.Name = "Packet_Status";
            this.Packet_Status.ReadOnly = true;
            // 
            // TxtLotNo
            // 
            this.TxtLotNo.Location = new System.Drawing.Point(590, 10);
            this.TxtLotNo.Name = "TxtLotNo";
            this.TxtLotNo.Size = new System.Drawing.Size(122, 21);
            this.TxtLotNo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(718, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Contract No";
            // 
            // TxtContractNo
            // 
            this.TxtContractNo.Location = new System.Drawing.Point(796, 10);
            this.TxtContractNo.Name = "TxtContractNo";
            this.TxtContractNo.Size = new System.Drawing.Size(122, 21);
            this.TxtContractNo.TabIndex = 3;
            // 
            // frmPacketQue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 405);
            this.Controls.Add(this.gvscanlist);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPacketQue";
            this.Text = "Packet Queue";
            this.Load += new System.EventHandler(this.frmPacketQue_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnref;
        private System.Windows.Forms.TextBox GnsaRefNo_Txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Inward_Todate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Inward_Fromdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvscanlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inward_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn GnsaRef_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agreement_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packet_Mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packet_Status;
        private System.Windows.Forms.TextBox TxtLotNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtContractNo;

    }
}