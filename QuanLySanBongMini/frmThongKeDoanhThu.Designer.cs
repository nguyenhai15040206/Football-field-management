
namespace QuanLySanBongMini
{
    partial class frmThongKeDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnINHangNgay = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pkThang = new System.Windows.Forms.DateTimePicker();
            this.btnInTheoThang = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInTheoNam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 44);
            this.panel1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(1, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1384, 4);
            this.label8.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "THỐNG KÊ DOANH THU VÀ TỒN KHO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1384, 697);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(425, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 697);
            this.panel2.TabIndex = 15;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.PeachPuff;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Thống kê tiền\\n theo hàng tháng";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(959, 697);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnINHangNgay);
            this.panel4.Controls.Add(this.dateTimePicker3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.pkThang);
            this.panel4.Controls.Add(this.btnInTheoThang);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnInTheoNam);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(425, 697);
            this.panel4.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thống kê theo hàng ngày >>";
            // 
            // btnINHangNgay
            // 
            this.btnINHangNgay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnINHangNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnINHangNgay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINHangNgay.Location = new System.Drawing.Point(175, 94);
            this.btnINHangNgay.Name = "btnINHangNgay";
            this.btnINHangNgay.Size = new System.Drawing.Size(160, 46);
            this.btnINHangNgay.TabIndex = 1;
            this.btnINHangNgay.Text = "In";
            this.btnINHangNgay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnINHangNgay.UseCompatibleTextRendering = true;
            this.btnINHangNgay.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(52, 327);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(289, 29);
            this.dateTimePicker3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thống kê theo hàng Tháng>>";
            // 
            // pkThang
            // 
            this.pkThang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkThang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pkThang.Location = new System.Drawing.Point(46, 198);
            this.pkThang.Name = "pkThang";
            this.pkThang.Size = new System.Drawing.Size(289, 29);
            this.pkThang.TabIndex = 2;
            // 
            // btnInTheoThang
            // 
            this.btnInTheoThang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInTheoThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInTheoThang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInTheoThang.Location = new System.Drawing.Point(175, 232);
            this.btnInTheoThang.Name = "btnInTheoThang";
            this.btnInTheoThang.Size = new System.Drawing.Size(160, 46);
            this.btnInTheoThang.TabIndex = 3;
            this.btnInTheoThang.Text = "In";
            this.btnInTheoThang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInTheoThang.UseCompatibleTextRendering = true;
            this.btnInTheoThang.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(43, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(289, 29);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thống kê theo hàng năm>>";
            // 
            // btnInTheoNam
            // 
            this.btnInTheoNam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInTheoNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInTheoNam.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInTheoNam.Location = new System.Drawing.Point(181, 361);
            this.btnInTheoNam.Name = "btnInTheoNam";
            this.btnInTheoNam.Size = new System.Drawing.Size(160, 46);
            this.btnInTheoNam.TabIndex = 5;
            this.btnInTheoNam.Text = "In";
            this.btnInTheoNam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInTheoNam.UseCompatibleTextRendering = true;
            this.btnInTheoNam.UseVisualStyleBackColor = true;
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1384, 741);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmThongKeDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThongKeDoanhThu";
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnINHangNgay;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker pkThang;
        private System.Windows.Forms.Button btnInTheoThang;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInTheoNam;
    }
}