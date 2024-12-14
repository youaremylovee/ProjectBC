namespace NhaBepUI
{
    partial class FrmNhaBepMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhaBepMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSuaMon = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            this.selectMeal = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnChiTietReportToi = new System.Windows.Forms.Button();
            this.btnChiTietReportTrua = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lbTrangThaiToi = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbTrangThaiTrua = new System.Windows.Forms.Label();
            this.ReportGVToi = new System.Windows.Forms.Label();
            this.ReportSVToi = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ReportGVTrua = new System.Windows.Forms.Label();
            this.ReportSVTrua = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.baocaoCalendar = new System.Windows.Forms.MonthCalendar();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayPhanAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnGuiThongBao = new System.Windows.Forms.Button();
            this.comboDoiTuong = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtThongBao = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnLuuCauHinh = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numberGioComToi = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numberGioComTrua = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.listImageTabs = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberGioComToi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberGioComTrua)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.ImageList = this.listImageTabs;
            this.tabControl1.Location = new System.Drawing.Point(29, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(996, 470);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonSuaMon);
            this.tabPage1.Controls.Add(this.btnXoaMon);
            this.tabPage1.Controls.Add(this.btnThemMon);
            this.tabPage1.Controls.Add(this.pictureImage);
            this.tabPage1.Controls.Add(this.selectMeal);
            this.tabPage1.Controls.Add(this.dgvData);
            this.tabPage1.Controls.Add(this.monthCalendar);
            this.tabPage1.ImageKey = "meal.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(988, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thực đơn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSuaMon
            // 
            this.buttonSuaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuaMon.Image = global::NhaBepUI.Properties.Resources.edit;
            this.buttonSuaMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSuaMon.Location = new System.Drawing.Point(681, 21);
            this.buttonSuaMon.Name = "buttonSuaMon";
            this.buttonSuaMon.Size = new System.Drawing.Size(135, 32);
            this.buttonSuaMon.TabIndex = 7;
            this.buttonSuaMon.Text = "Sửa";
            this.buttonSuaMon.UseVisualStyleBackColor = true;
            this.buttonSuaMon.Click += new System.EventHandler(this.buttonSuaMon_Click);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMon.Image = global::NhaBepUI.Properties.Resources.cancel;
            this.btnXoaMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaMon.Location = new System.Drawing.Point(822, 20);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(135, 32);
            this.btnXoaMon.TabIndex = 6;
            this.btnXoaMon.Text = "Xóa";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Image = global::NhaBepUI.Properties.Resources.add;
            this.btnThemMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMon.Location = new System.Drawing.Point(540, 20);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(135, 32);
            this.btnThemMon.TabIndex = 5;
            this.btnThemMon.Text = "Thêm";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // pictureImage
            // 
            this.pictureImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureImage.Location = new System.Drawing.Point(43, 20);
            this.pictureImage.Name = "pictureImage";
            this.pictureImage.Size = new System.Drawing.Size(262, 177);
            this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureImage.TabIndex = 4;
            this.pictureImage.TabStop = false;
            // 
            // selectMeal
            // 
            this.selectMeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectMeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectMeal.FormattingEnabled = true;
            this.selectMeal.Items.AddRange(new object[] {
            "Trưa",
            "Tối"});
            this.selectMeal.Location = new System.Drawing.Point(356, 20);
            this.selectMeal.Name = "selectMeal";
            this.selectMeal.Size = new System.Drawing.Size(121, 33);
            this.selectMeal.TabIndex = 3;
            this.selectMeal.SelectedIndexChanged += new System.EventHandler(this.selectMeal_SelectedIndexChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenMon,
            this.LoaiMon,
            this.GhiChu});
            this.dgvData.Location = new System.Drawing.Point(356, 72);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(601, 344);
            this.dgvData.TabIndex = 2;
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // tenMon
            // 
            this.tenMon.HeaderText = "Tên món";
            this.tenMon.MinimumWidth = 6;
            this.tenMon.Name = "tenMon";
            this.tenMon.ReadOnly = true;
            this.tenMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoaiMon
            // 
            this.LoaiMon.HeaderText = "Loại món";
            this.LoaiMon.MinimumWidth = 6;
            this.LoaiMon.Name = "LoaiMon";
            this.LoaiMon.ReadOnly = true;
            this.LoaiMon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LoaiMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GhiChu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(43, 209);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportPDF);
            this.tabPage2.Controls.Add(this.btnExportExcel);
            this.tabPage2.Controls.Add(this.btnChiTietReportToi);
            this.tabPage2.Controls.Add(this.btnChiTietReportTrua);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.lbTrangThaiToi);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.lbTrangThaiTrua);
            this.tabPage2.Controls.Add(this.ReportGVToi);
            this.tabPage2.Controls.Add(this.ReportSVToi);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.ReportGVTrua);
            this.tabPage2.Controls.Add(this.ReportSVTrua);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.baocaoCalendar);
            this.tabPage2.ImageKey = "report.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(988, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Báo cáo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Image = global::NhaBepUI.Properties.Resources.pdf;
            this.btnExportPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPDF.Location = new System.Drawing.Point(64, 378);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(262, 45);
            this.btnExportPDF.TabIndex = 23;
            this.btnExportPDF.Text = "Xuất ra PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::NhaBepUI.Properties.Resources.excel;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(64, 327);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(262, 45);
            this.btnExportExcel.TabIndex = 22;
            this.btnExportExcel.Text = "Xuất ra Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnChiTietReportToi
            // 
            this.btnChiTietReportToi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietReportToi.Image = global::NhaBepUI.Properties.Resources.view;
            this.btnChiTietReportToi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChiTietReportToi.Location = new System.Drawing.Point(696, 308);
            this.btnChiTietReportToi.Name = "btnChiTietReportToi";
            this.btnChiTietReportToi.Size = new System.Drawing.Size(209, 44);
            this.btnChiTietReportToi.TabIndex = 21;
            this.btnChiTietReportToi.Text = "Chi tiết";
            this.btnChiTietReportToi.UseVisualStyleBackColor = true;
            this.btnChiTietReportToi.Click += new System.EventHandler(this.btnChiTietReportToi_Click);
            // 
            // btnChiTietReportTrua
            // 
            this.btnChiTietReportTrua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietReportTrua.Image = global::NhaBepUI.Properties.Resources.view;
            this.btnChiTietReportTrua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChiTietReportTrua.Location = new System.Drawing.Point(696, 131);
            this.btnChiTietReportTrua.Name = "btnChiTietReportTrua";
            this.btnChiTietReportTrua.Size = new System.Drawing.Size(209, 44);
            this.btnChiTietReportTrua.TabIndex = 20;
            this.btnChiTietReportTrua.Text = "Chi tiết";
            this.btnChiTietReportTrua.UseVisualStyleBackColor = true;
            this.btnChiTietReportTrua.Click += new System.EventHandler(this.btnChiTietReportTrua_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(691, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 25);
            this.label15.TabIndex = 19;
            this.label15.Text = "Trạng thái:";
            // 
            // lbTrangThaiToi
            // 
            this.lbTrangThaiToi.AutoSize = true;
            this.lbTrangThaiToi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangThaiToi.ForeColor = System.Drawing.Color.Red;
            this.lbTrangThaiToi.Location = new System.Drawing.Point(803, 249);
            this.lbTrangThaiToi.Name = "lbTrangThaiToi";
            this.lbTrangThaiToi.Size = new System.Drawing.Size(102, 25);
            this.lbTrangThaiToi.TabIndex = 18;
            this.lbTrangThaiToi.Text = "Chưa chốt";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(691, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 25);
            this.label20.TabIndex = 17;
            this.label20.Text = "Trạng thái:";
            // 
            // lbTrangThaiTrua
            // 
            this.lbTrangThaiTrua.AutoSize = true;
            this.lbTrangThaiTrua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangThaiTrua.ForeColor = System.Drawing.Color.Red;
            this.lbTrangThaiTrua.Location = new System.Drawing.Point(803, 72);
            this.lbTrangThaiTrua.Name = "lbTrangThaiTrua";
            this.lbTrangThaiTrua.Size = new System.Drawing.Size(102, 25);
            this.lbTrangThaiTrua.TabIndex = 15;
            this.lbTrangThaiTrua.Text = "Chưa chốt";
            // 
            // ReportGVToi
            // 
            this.ReportGVToi.AutoSize = true;
            this.ReportGVToi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportGVToi.Location = new System.Drawing.Point(593, 327);
            this.ReportGVToi.Name = "ReportGVToi";
            this.ReportGVToi.Size = new System.Drawing.Size(73, 25);
            this.ReportGVToi.TabIndex = 14;
            this.ReportGVToi.Text = "1/1000";
            // 
            // ReportSVToi
            // 
            this.ReportSVToi.AutoSize = true;
            this.ReportSVToi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSVToi.Location = new System.Drawing.Point(593, 287);
            this.ReportSVToi.Name = "ReportSVToi";
            this.ReportSVToi.Size = new System.Drawing.Size(73, 25);
            this.ReportSVToi.TabIndex = 13;
            this.ReportSVToi.Text = "1/1000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(446, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Giảng viên: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(446, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 25);
            this.label11.TabIndex = 11;
            this.label11.Text = "Sinh viên: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(380, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 25);
            this.label12.TabIndex = 10;
            this.label12.Text = "Số lượng suất ăn báo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(380, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 25);
            this.label13.TabIndex = 9;
            this.label13.Text = "Bữa tối";
            // 
            // ReportGVTrua
            // 
            this.ReportGVTrua.AutoSize = true;
            this.ReportGVTrua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportGVTrua.Location = new System.Drawing.Point(593, 150);
            this.ReportGVTrua.Name = "ReportGVTrua";
            this.ReportGVTrua.Size = new System.Drawing.Size(73, 25);
            this.ReportGVTrua.TabIndex = 8;
            this.ReportGVTrua.Text = "1/1000";
            // 
            // ReportSVTrua
            // 
            this.ReportSVTrua.AutoSize = true;
            this.ReportSVTrua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSVTrua.Location = new System.Drawing.Point(593, 110);
            this.ReportSVTrua.Name = "ReportSVTrua";
            this.ReportSVTrua.Size = new System.Drawing.Size(73, 25);
            this.ReportSVTrua.TabIndex = 7;
            this.ReportSVTrua.Text = "1/1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(446, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giảng viên: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sinh viên: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(380, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số lượng suất ăn báo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(380, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bữa trưa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thời gian";
            // 
            // baocaoCalendar
            // 
            this.baocaoCalendar.Location = new System.Drawing.Point(64, 72);
            this.baocaoCalendar.Name = "baocaoCalendar";
            this.baocaoCalendar.TabIndex = 1;
            this.baocaoCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.baocaoCalendar_DateChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvThongBao);
            this.tabPage3.ImageKey = "feedback.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(988, 441);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Phản ánh";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvThongBao
            // 
            this.dgvThongBao.AllowUserToAddRows = false;
            this.dgvThongBao.AllowUserToDeleteRows = false;
            this.dgvThongBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongBao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoiDung,
            this.NgayPhanAnh,
            this.GC});
            this.dgvThongBao.Location = new System.Drawing.Point(0, 0);
            this.dgvThongBao.MultiSelect = false;
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.ReadOnly = true;
            this.dgvThongBao.RowHeadersWidth = 51;
            this.dgvThongBao.RowTemplate.Height = 24;
            this.dgvThongBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongBao.Size = new System.Drawing.Size(988, 438);
            this.dgvThongBao.TabIndex = 0;
            // 
            // NoiDung
            // 
            this.NoiDung.HeaderText = "Nội dung phản ánh";
            this.NoiDung.MinimumWidth = 6;
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            // 
            // NgayPhanAnh
            // 
            this.NgayPhanAnh.HeaderText = "Ngày phản ánh";
            this.NgayPhanAnh.MinimumWidth = 6;
            this.NgayPhanAnh.Name = "NgayPhanAnh";
            this.NgayPhanAnh.ReadOnly = true;
            // 
            // GC
            // 
            this.GC.HeaderText = "Ghi chú";
            this.GC.MinimumWidth = 6;
            this.GC.Name = "GC";
            this.GC.ReadOnly = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnGuiThongBao);
            this.tabPage4.Controls.Add(this.comboDoiTuong);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.txtThongBao);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.ImageKey = "notification.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(988, 441);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Thông báo";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnGuiThongBao
            // 
            this.btnGuiThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiThongBao.Image = global::NhaBepUI.Properties.Resources.check;
            this.btnGuiThongBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuiThongBao.Location = new System.Drawing.Point(65, 372);
            this.btnGuiThongBao.Name = "btnGuiThongBao";
            this.btnGuiThongBao.Size = new System.Drawing.Size(150, 40);
            this.btnGuiThongBao.TabIndex = 9;
            this.btnGuiThongBao.Text = "Gửi";
            this.btnGuiThongBao.UseVisualStyleBackColor = true;
            this.btnGuiThongBao.Click += new System.EventHandler(this.btnGuiThongBao_Click);
            // 
            // comboDoiTuong
            // 
            this.comboDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDoiTuong.FormattingEnabled = true;
            this.comboDoiTuong.Items.AddRange(new object[] {
            "Tất cả",
            "Sinh viên",
            "Giảng viên"});
            this.comboDoiTuong.Location = new System.Drawing.Point(65, 292);
            this.comboDoiTuong.Name = "comboDoiTuong";
            this.comboDoiTuong.Size = new System.Drawing.Size(379, 33);
            this.comboDoiTuong.TabIndex = 5;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(60, 252);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 25);
            this.label24.TabIndex = 4;
            this.label24.Text = "Đối tượng";
            // 
            // txtThongBao
            // 
            this.txtThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongBao.Location = new System.Drawing.Point(65, 90);
            this.txtThongBao.Multiline = true;
            this.txtThongBao.Name = "txtThongBao";
            this.txtThongBao.Size = new System.Drawing.Size(893, 140);
            this.txtThongBao.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(60, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(155, 25);
            this.label23.TabIndex = 2;
            this.label23.Text = "Thêm thông báo";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnDangXuat);
            this.tabPage5.Controls.Add(this.btnLuuCauHinh);
            this.tabPage5.Controls.Add(this.pictureBox2);
            this.tabPage5.Controls.Add(this.pictureBox1);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.numberGioComToi);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.numberGioComTrua);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.ImageKey = "setting.png";
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(988, 441);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cài đặt";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.Image = global::NhaBepUI.Properties.Resources.logout;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(711, 360);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(209, 56);
            this.btnDangXuat.TabIndex = 9;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnLuuCauHinh
            // 
            this.btnLuuCauHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuCauHinh.Image = global::NhaBepUI.Properties.Resources.save;
            this.btnLuuCauHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuCauHinh.Location = new System.Drawing.Point(57, 360);
            this.btnLuuCauHinh.Name = "btnLuuCauHinh";
            this.btnLuuCauHinh.Size = new System.Drawing.Size(172, 56);
            this.btnLuuCauHinh.TabIndex = 8;
            this.btnLuuCauHinh.Text = "Lưu";
            this.btnLuuCauHinh.UseVisualStyleBackColor = true;
            this.btnLuuCauHinh.Click += new System.EventHandler(this.btnLuuCauHinh_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NhaBepUI.Properties.Resources.night;
            this.pictureBox2.Location = new System.Drawing.Point(23, 119);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NhaBepUI.Properties.Resources.day;
            this.pictureBox1.Location = new System.Drawing.Point(23, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(621, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 25);
            this.label19.TabIndex = 5;
            this.label19.Text = "giờ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(621, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 25);
            this.label18.TabIndex = 4;
            this.label18.Text = "giờ";
            // 
            // numberGioComToi
            // 
            this.numberGioComToi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberGioComToi.Location = new System.Drawing.Point(402, 144);
            this.numberGioComToi.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numberGioComToi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberGioComToi.Name = "numberGioComToi";
            this.numberGioComToi.ReadOnly = true;
            this.numberGioComToi.Size = new System.Drawing.Size(192, 30);
            this.numberGioComToi.TabIndex = 3;
            this.numberGioComToi.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(116, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(269, 25);
            this.label17.TabIndex = 2;
            this.label17.Text = "Thời gian đặt cơm tối:    Trước";
            // 
            // numberGioComTrua
            // 
            this.numberGioComTrua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberGioComTrua.Location = new System.Drawing.Point(402, 67);
            this.numberGioComTrua.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numberGioComTrua.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberGioComTrua.Name = "numberGioComTrua";
            this.numberGioComTrua.ReadOnly = true;
            this.numberGioComTrua.Size = new System.Drawing.Size(192, 30);
            this.numberGioComTrua.TabIndex = 1;
            this.numberGioComTrua.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(116, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(267, 25);
            this.label16.TabIndex = 0;
            this.label16.Text = "Thời gian đặt cơm trưa: Trước";
            // 
            // listImageTabs
            // 
            this.listImageTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImageTabs.ImageStream")));
            this.listImageTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.listImageTabs.Images.SetKeyName(0, "feedback.png");
            this.listImageTabs.Images.SetKeyName(1, "meal.png");
            this.listImageTabs.Images.SetKeyName(2, "notification.png");
            this.listImageTabs.Images.SetKeyName(3, "report.png");
            this.listImageTabs.Images.SetKeyName(4, "setting.png");
            // 
            // FrmNhaBepMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmNhaBepMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cơm trưa - Nhà Bếp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNhaBepMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberGioComToi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberGioComTrua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.ComboBox selectMeal;
        private System.Windows.Forms.PictureBox pictureImage;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button buttonSuaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.MonthCalendar baocaoCalendar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ReportGVToi;
        private System.Windows.Forms.Label ReportSVToi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ReportGVTrua;
        private System.Windows.Forms.Label ReportSVTrua;
        private System.Windows.Forms.Label lbTrangThaiTrua;
        private System.Windows.Forms.DataGridView dgvThongBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayPhanAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC;
        private System.Windows.Forms.ImageList listImageTabs;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.NumericUpDown numberGioComTrua;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numberGioComToi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLuuCauHinh;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnChiTietReportTrua;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbTrangThaiToi;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnChiTietReportToi;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnGuiThongBao;
        private System.Windows.Forms.ComboBox comboDoiTuong;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtThongBao;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportPDF;
    }
}

