namespace Phan4_2
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NhanSu = new System.Windows.Forms.ToolStripMenuItem();
            this.PhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.Luong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.NhanSu,
            this.PhongBan,
            this.Luong});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            this.hệThốngToolStripMenuItem.Click += new System.EventHandler(this.hệThốngToolStripMenuItem_Click);
            // 
            // NhanSu
            // 
            this.NhanSu.Name = "NhanSu";
            this.NhanSu.Size = new System.Drawing.Size(64, 20);
            this.NhanSu.Text = "Nhân Sự";
            this.NhanSu.Click += new System.EventHandler(this.NhanSu_Click);
            // 
            // PhongBan
            // 
            this.PhongBan.Name = "PhongBan";
            this.PhongBan.Size = new System.Drawing.Size(77, 20);
            this.PhongBan.Text = "Phòng Ban";
            this.PhongBan.Click += new System.EventHandler(this.PhongBan_Click);
            // 
            // Luong
            // 
            this.Luong.Name = "Luong";
            this.Luong.Size = new System.Drawing.Size(53, 20);
            this.Luong.Text = "Lương";
            this.Luong.Click += new System.EventHandler(this.Luong_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 545);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NhanSu;
        private System.Windows.Forms.ToolStripMenuItem PhongBan;
        private System.Windows.Forms.ToolStripMenuItem Luong;
    }
}

