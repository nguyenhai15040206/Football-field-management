
namespace QuanLySanBongMini
{
    partial class frmGioiThieuSanBong
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
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGioiThieuSanBong));
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label8 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bunifuRating1 = new Bunifu.Framework.UI.BunifuRating();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlBangGiaGio1 = new QuanLySanBongMini.UserControlBangGiaGio();
            this.userControlGioiThieuSan1 = new QuanLySanBongMini.UserControlGioiThieuSan();
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Controls.Add(this.bunifuRating1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.bunifuTransition2.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 105);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // simpleButton2
            // 
            this.bunifuTransition2.SetDecoration(this.simpleButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.simpleButton2, BunifuAnimatorNS.DecorationType.None);
            this.simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(1260, 3);
            this.simpleButton2.LookAndFeel.SkinName = "The Bezier";
            this.simpleButton2.LookAndFeel.UseWindowsXPTheme = true;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton2.Size = new System.Drawing.Size(128, 96);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "Bảng giá giờ";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bunifuTransition1.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Location = new System.Drawing.Point(0, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1400, 4);
            this.label8.TabIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.bunifuTransition2.SetDecoration(this.simpleButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.simpleButton1, BunifuAnimatorNS.DecorationType.None);
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(1125, 2);
            this.simpleButton1.LookAndFeel.SkinName = "The Bezier";
            this.simpleButton1.LookAndFeel.UseWindowsXPTheme = true;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(137, 96);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Giới Thiệu Sân";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // bunifuRating1
            // 
            this.bunifuRating1.AllowDrop = true;
            this.bunifuRating1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuRating1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition2.SetDecoration(this.bunifuRating1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuRating1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuRating1.Enabled = false;
            this.bunifuRating1.ForeColor = System.Drawing.Color.Orange;
            this.bunifuRating1.Location = new System.Drawing.Point(155, 63);
            this.bunifuRating1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuRating1.Name = "bunifuRating1";
            this.bunifuRating1.Size = new System.Drawing.Size(163, 32);
            this.bunifuRating1.TabIndex = 3;
            this.bunifuRating1.Value = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLySanBongMini.Properties.Resources.kisspng_manchester_united_f_c_liverpool_f_c_football_man_attraktive_inspiration_manchester_united_wandtatto_5bf378129f3475_0136628415426826426521_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTransition1.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(25, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(716, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phần Mềm Quản Lý Sân Bóng Đá Mini Hiệp Phát";
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 1F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlBangGiaGio1);
            this.panel1.Controls.Add(this.userControlGioiThieuSan1);
            this.bunifuTransition2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 560);
            this.panel1.TabIndex = 2;
            // 
            // userControlBangGiaGio1
            // 
            this.userControlBangGiaGio1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControlBangGiaGio1.BackgroundImage")));
            this.userControlBangGiaGio1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTransition1.SetDecoration(this.userControlBangGiaGio1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.userControlBangGiaGio1, BunifuAnimatorNS.DecorationType.None);
            this.userControlBangGiaGio1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBangGiaGio1.Location = new System.Drawing.Point(0, 0);
            this.userControlBangGiaGio1.Name = "userControlBangGiaGio1";
            this.userControlBangGiaGio1.Size = new System.Drawing.Size(1400, 560);
            this.userControlBangGiaGio1.TabIndex = 1;
            this.userControlBangGiaGio1.Visible = false;
            // 
            // userControlGioiThieuSan1
            // 
            this.userControlGioiThieuSan1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControlGioiThieuSan1.BackgroundImage")));
            this.userControlGioiThieuSan1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTransition1.SetDecoration(this.userControlGioiThieuSan1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.userControlGioiThieuSan1, BunifuAnimatorNS.DecorationType.None);
            this.userControlGioiThieuSan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlGioiThieuSan1.Location = new System.Drawing.Point(0, 0);
            this.userControlGioiThieuSan1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userControlGioiThieuSan1.Name = "userControlGioiThieuSan1";
            this.userControlGioiThieuSan1.Size = new System.Drawing.Size(1400, 560);
            this.userControlGioiThieuSan1.TabIndex = 0;
            this.userControlGioiThieuSan1.Visible = false;
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic;
            this.bunifuTransition2.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 20;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuTransition2.DefaultAnimation = animation1;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // frmGioiThieuSanBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1400, 770);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGioiThieuSanBong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin giới thiệu Sân Bóng";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuRating bunifuRating1;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Panel panel1;
        private UserControlGioiThieuSan userControlGioiThieuSan1;
        private UserControlBangGiaGio userControlBangGiaGio1;
    }
}