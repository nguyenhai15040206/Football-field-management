
namespace QuanLySanBongMini
{
    partial class UserControlSanBong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenSan = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuanLySanBongMini.Properties.Resources._4595_jpg_wh860;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblTenSan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 62);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblTenSan
            // 
            this.lblTenSan.BackColor = System.Drawing.Color.Transparent;
            this.lblTenSan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTenSan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSan.ForeColor = System.Drawing.Color.White;
            this.lblTenSan.Location = new System.Drawing.Point(0, 32);
            this.lblTenSan.Name = "lblTenSan";
            this.lblTenSan.Size = new System.Drawing.Size(112, 30);
            this.lblTenSan.TabIndex = 2;
            this.lblTenSan.Text = "Sân";
            this.lblTenSan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlSanBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlSanBong";
            this.Size = new System.Drawing.Size(112, 62);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTenSan;
    }
}
