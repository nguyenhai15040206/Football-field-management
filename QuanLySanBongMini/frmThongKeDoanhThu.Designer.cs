
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.pkThang = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnInTheoNam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInTheoThang = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnINHangNgay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.PeachPuff;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.chart1.Size = new System.Drawing.Size(703, 618);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.pkThang);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btnInTheoNam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnInTheoThang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnINHangNgay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(709, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 761);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê doanh thu ";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(38, 319);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(289, 27);
            this.dateTimePicker3.TabIndex = 3;
            // 
            // pkThang
            // 
            this.pkThang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pkThang.Location = new System.Drawing.Point(32, 190);
            this.pkThang.Name = "pkThang";
            this.pkThang.Size = new System.Drawing.Size(289, 27);
            this.pkThang.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(32, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(289, 27);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // btnInTheoNam
            // 
            this.btnInTheoNam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInTheoNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInTheoNam.Location = new System.Drawing.Point(167, 353);
            this.btnInTheoNam.Name = "btnInTheoNam";
            this.btnInTheoNam.Size = new System.Drawing.Size(160, 46);
            this.btnInTheoNam.TabIndex = 2;
            this.btnInTheoNam.Text = "In";
            this.btnInTheoNam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInTheoNam.UseCompatibleTextRendering = true;
            this.btnInTheoNam.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thống kê theo hàng năm>>";
            // 
            // btnInTheoThang
            // 
            this.btnInTheoThang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInTheoThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInTheoThang.Location = new System.Drawing.Point(161, 224);
            this.btnInTheoThang.Name = "btnInTheoThang";
            this.btnInTheoThang.Size = new System.Drawing.Size(160, 46);
            this.btnInTheoThang.TabIndex = 2;
            this.btnInTheoThang.Text = "In";
            this.btnInTheoThang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInTheoThang.UseCompatibleTextRendering = true;
            this.btnInTheoThang.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thống kê theo hàng Tháng>>";
            // 
            // btnINHangNgay
            // 
            this.btnINHangNgay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnINHangNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnINHangNgay.Location = new System.Drawing.Point(161, 96);
            this.btnINHangNgay.Name = "btnINHangNgay";
            this.btnINHangNgay.Size = new System.Drawing.Size(160, 46);
            this.btnINHangNgay.TabIndex = 2;
            this.btnINHangNgay.Text = "In";
            this.btnINHangNgay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnINHangNgay.UseCompatibleTextRendering = true;
            this.btnINHangNgay.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê theo hàng ngày >>";
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1082, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmThongKeDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThongKeDoanhThu";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker pkThang;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnInTheoNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInTheoThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnINHangNgay;
        private System.Windows.Forms.Label label1;
    }
}