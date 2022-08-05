namespace Chola
{
    partial class frmMain
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuTran = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScanning = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTran,
            this.WindowsMenu,
            this.mnuExit});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.MdiWindowListItem = this.WindowsMenu;
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // mnuTran
            // 
            this.mnuTran.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScanning,
            this.imageAttachmentToolStripMenuItem});
            this.mnuTran.Name = "mnuTran";
            this.mnuTran.Size = new System.Drawing.Size(86, 20);
            this.mnuTran.Text = "Transaction";
            // 
            // mnuScanning
            // 
            this.mnuScanning.Name = "mnuScanning";
            this.mnuScanning.Size = new System.Drawing.Size(152, 22);
            this.mnuScanning.Text = "Scanning";
            this.mnuScanning.Click += new System.EventHandler(this.mnuScanning_Click);
            // 
            // WindowsMenu
            // 
            this.WindowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CascadeToolStripMenuItem,
            this.TileVerticalToolStripMenuItem,
            this.TileHorizontalToolStripMenuItem,
            this.CloseAllToolStripMenuItem,
            this.ArrangeIconsToolStripMenuItem});
            this.WindowsMenu.Name = "WindowsMenu";
            this.WindowsMenu.Size = new System.Drawing.Size(69, 20);
            this.WindowsMenu.Text = "&Windows";
            // 
            // CascadeToolStripMenuItem
            // 
            this.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem";
            this.CascadeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.CascadeToolStripMenuItem.Text = "&Cascade";
            // 
            // TileVerticalToolStripMenuItem
            // 
            this.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem";
            this.TileVerticalToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.TileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            // 
            // TileHorizontalToolStripMenuItem
            // 
            this.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem";
            this.TileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            // 
            // CloseAllToolStripMenuItem
            // 
            this.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem";
            this.CloseAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.CloseAllToolStripMenuItem.Text = "C&lose All";
            // 
            // ArrangeIconsToolStripMenuItem
            // 
            this.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem";
            this.ArrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(40, 20);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 239);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip.TabIndex = 3;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Status";
            // 
            // imageAttachmentToolStripMenuItem
            // 
            this.imageAttachmentToolStripMenuItem.Name = "imageAttachmentToolStripMenuItem";
            this.imageAttachmentToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.imageAttachmentToolStripMenuItem.Text = "Image Attachment";
            this.imageAttachmentToolStripMenuItem.Click += new System.EventHandler(this.imageAttachmentToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Arms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MenuStrip;
        internal System.Windows.Forms.ToolStripMenuItem mnuTran;
        internal System.Windows.Forms.ToolStripMenuItem mnuScanning;
        internal System.Windows.Forms.ToolStripMenuItem WindowsMenu;
        internal System.Windows.Forms.ToolStripMenuItem CascadeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TileVerticalToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TileHorizontalToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CloseAllToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ArrangeIconsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.StatusStrip StatusStrip;
        internal System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem imageAttachmentToolStripMenuItem;
    }
}