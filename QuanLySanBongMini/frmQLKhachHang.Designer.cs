
namespace QuanLySanBongMini
{
    partial class frmQLKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLKhachHang));
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridContrrolKhachHang = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXoaKH = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLamMoi = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLuuDatSan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCapNhat = new System.Windows.Forms.ToolStripButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.numericUpDownDiemTL = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiKhachHang = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContrrolKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaKH)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiemTL)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.gridContrrolKhachHang);
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 247);
            this.panel2.TabIndex = 1;
            // 
            // gridContrrolKhachHang
            // 
            this.gridContrrolKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContrrolKhachHang.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContrrolKhachHang.Location = new System.Drawing.Point(0, 0);
            this.gridContrrolKhachHang.MainView = this.gridView2;
            this.gridContrrolKhachHang.Name = "gridContrrolKhachHang";
            this.gridContrrolKhachHang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnXoaKH});
            this.gridContrrolKhachHang.Size = new System.Drawing.Size(743, 247);
            this.gridContrrolKhachHang.TabIndex = 6;
            this.gridContrrolKhachHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.VertLine.Options.UseFont = true;
            this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView2.GridControl = this.gridContrrolKhachHang;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.FindNullPrompt = "Nhập thông tin cần tìm kiếm";
            this.gridView2.OptionsHint.ShowCellHints = false;
            this.gridView2.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView2_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.btnXoaKH;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // btnXoaKH
            // 
            this.btnXoaKH.AutoHeight = false;
            this.btnXoaKH.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.btnXoaKH.Name = "btnXoaKH";
            this.btnXoaKH.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã khách hàng";
            this.gridColumn2.FieldName = "MaKhachHang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 121;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Loại khách hàng";
            this.gridColumn6.FieldName = "TenLoai";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 153;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên khách hàng";
            this.gridColumn3.FieldName = "TenKhachHang";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 169;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số điện thoại";
            this.gridColumn4.FieldName = "SoDienThoai";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 160;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Điểm tích lũy";
            this.gridColumn5.FieldName = "DiemTichLuy";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 143;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(746, 44);
            this.panel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "QUẢN LÝ THÔNG TIN KHÁCH HÀNG";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(746, 512);
            this.panel4.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.numericUpDownDiemTL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboLoaiKhachHang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 221);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLamMoi,
            this.toolStripButtonLuuDatSan,
            this.toolStripButtonCapNhat});
            this.toolStrip1.Location = new System.Drawing.Point(3, 181);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(740, 37);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLamMoi
            // 
            this.toolStripButtonLamMoi.Image = global::QuanLySanBongMini.Properties.Resources.addpink_removebg_preview;
            this.toolStripButtonLamMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLamMoi.Name = "toolStripButtonLamMoi";
            this.toolStripButtonLamMoi.Size = new System.Drawing.Size(101, 34);
            this.toolStripButtonLamMoi.Text = "Làm mới";
            this.toolStripButtonLamMoi.Click += new System.EventHandler(this.toolStripButtonLamMoi_Click);
            // 
            // toolStripButtonLuuDatSan
            // 
            this.toolStripButtonLuuDatSan.Image = global::QuanLySanBongMini.Properties.Resources.add;
            this.toolStripButtonLuuDatSan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLuuDatSan.Name = "toolStripButtonLuuDatSan";
            this.toolStripButtonLuuDatSan.Size = new System.Drawing.Size(159, 34);
            this.toolStripButtonLuuDatSan.Text = "Thêm khách hàng";
            this.toolStripButtonLuuDatSan.Click += new System.EventHandler(this.toolStripButtonLuuDatSan_Click_1);
            // 
            // toolStripButtonCapNhat
            // 
            this.toolStripButtonCapNhat.Image = global::QuanLySanBongMini.Properties.Resources.savepink_removebg_preview1;
            this.toolStripButtonCapNhat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCapNhat.Name = "toolStripButtonCapNhat";
            this.toolStripButtonCapNhat.Size = new System.Drawing.Size(106, 34);
            this.toolStripButtonCapNhat.Text = "Cập nhập";
            this.toolStripButtonCapNhat.Click += new System.EventHandler(this.toolStripButtonCapNhat_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(391, 32);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 28);
            this.simpleButton1.TabIndex = 16;
            // 
            // numericUpDownDiemTL
            // 
            this.numericUpDownDiemTL.BackColor = System.Drawing.Color.White;
            this.numericUpDownDiemTL.Location = new System.Drawing.Point(158, 141);
            this.numericUpDownDiemTL.Name = "numericUpDownDiemTL";
            this.numericUpDownDiemTL.ReadOnly = true;
            this.numericUpDownDiemTL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDownDiemTL.Size = new System.Drawing.Size(270, 27);
            this.numericUpDownDiemTL.TabIndex = 4;
            this.numericUpDownDiemTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Điểm tích lũy:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(158, 105);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(270, 27);
            this.txtSDT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(158, 69);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(270, 27);
            this.txtTenKH.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên khách hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại khách hàng:";
            // 
            // cboLoaiKhachHang
            // 
            this.cboLoaiKhachHang.FormattingEnabled = true;
            this.cboLoaiKhachHang.Location = new System.Drawing.Point(158, 32);
            this.cboLoaiKhachHang.Name = "cboLoaiKhachHang";
            this.cboLoaiKhachHang.Size = new System.Drawing.Size(227, 28);
            this.cboLoaiKhachHang.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(-1, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(746, 4);
            this.label8.TabIndex = 4;
            // 
            // frmQLKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(746, 512);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQLKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQLKhachHang";
            this.Load += new System.EventHandler(this.frmQLKhachHang_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContrrolKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaKH)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiemTL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridContrrolKhachHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnXoaKH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLamMoi;
        private System.Windows.Forms.ToolStripButton toolStripButtonLuuDatSan;
        private System.Windows.Forms.ToolStripButton toolStripButtonCapNhat;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.NumericUpDown numericUpDownDiemTL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLoaiKhachHang;
        private System.Windows.Forms.Label label8;
    }
}