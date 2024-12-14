using iTextSharp.text;
using iTextSharp.text.pdf;
using ProjectAbstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
namespace NhaBepUI
{
    public partial class FrmNhaBepMain : Form
    {
        private class ReportDTO
        {
            public string Time { get; set; }
            public int TongSuatAn { get; set; }
            public int MonMan { get; set; }
            public int MonChay { get; set; }
            public int MonDacBiet { get; set; }
            public static ReportDTO FromReport(Report report, string time)
            {
                return new ReportDTO
                {
                    Time = time,
                    TongSuatAn = report.TongSuatAn,
                    MonMan = report.MonMan,
                    MonChay = report.MonChay,
                    MonDacBiet = report.MonDacBiet
                };
            }
        }
        private class Report
        {
            public int TongSuatAn { get; set; }
            public int TotalSV { get; private set; }
            public int TotalGV { get; private set; }
            public int MonMan { get; private set; }
            public int MonChay { get; private set; }
            public int MonDacBiet { get; private set; }
            public bool TrangThai { get; private set; }
            private DateTime dateTime;

            public void SetTotal(int totalSV, int totalGV)
            {
                this.TotalSV = totalSV;
                this.TotalGV = totalGV;
            }
            public void SetCount(int MonMan, int MonChay, int MonDacBiet)
            {
                this.MonMan = MonMan;
                this.MonChay = MonChay;
                this.MonDacBiet = MonDacBiet;
            }
            public void SetTrangThai(bool trangThai)
            {
                this.TrangThai = trangThai;
            }
            public void SetDateTime(DateTime dateTime)
            {
                this.dateTime = dateTime;
            }
            public string ToReport()
            {
                return "Báo cáo ngày " + dateTime.ToString("dd/MM/yyyy") + "\n" +
                    "Món mặn: " + MonMan + "\n" +
                    "Món chay: " + MonChay + "\n" +
                    "Món đặc biệt: " + MonDacBiet + "\n" +
                    "Trạng thái: " + (TrangThai ? "Đã chốt" : "Chưa chốt");
            }
        }
        private DBEntities db = new DBEntities();
        private List<MenuFood> menuFoods = new List<MenuFood>();
        private Report buaTruaReport = new Report();
        private Report buaToiReport = new Report();
        private readonly Form _frmLogin;

        public FrmNhaBepMain()
        {
            InitializeComponent();
        }

        public FrmNhaBepMain(Form frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectMeal.SelectedIndex = 0;
            comboDoiTuong.SelectedIndex = 0;
            RefreshCalendar();
        }

        internal bool addMeal(int menuId, ItemTable item)
        {
            try
            {
                db.MenuFoods.Add(new MenuFood
                {
                    MenuId = menuId,
                    DishName = item.DishName,
                    Category = item.DishType,
                    Note = item.Note,
                    Image = item.ImagePath
                });
                db.SaveChanges();
                RefreshCalendar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool updateMeal(int menuId, ItemTable item)
        {
            var menuFood = db.MenuFoods.Where(mf => mf.MenuId == menuId && mf.Id == item.Id).FirstOrDefault();
            if (menuFood != null)
            {
                menuFood.DishName = item.DishName;
                menuFood.Category = item.DishType;
                menuFood.Note = item.Note;
                menuFood.Image = item.ImagePath;
                db.SaveChanges();
            }
            return menuFood != null;
        }

        private void deleteMeal(MenuFood mf)
        {
            var menuFood = db.MenuFoods.FirstOrDefault(m => m.Id == mf.Id);
            if (menuFood != null)
            {
                db.MenuFoods.Remove(menuFood);
                db.SaveChanges();
                MessageBox.Show("Xóa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCalendar();
            }
            else
            {
                MessageBox.Show("Xóa món thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            var listMenu = db.Menus.ToList();
            var menu = listMenu
                .FirstOrDefault(m => m.MealType == selectMeal.SelectedItem.ToString() && m.Date.Date == monthCalendar.SelectionStart.Date);
            if (menu == null)
            {
                Menu newMenu = new Menu
                {
                    MealType = selectMeal.SelectedItem.ToString(),
                    Date = monthCalendar.SelectionStart.Date
                };
                menu = db.Menus.Add(newMenu);
                db.SaveChanges();
            }
            var pathDirectory = db.Configurations.Where(c => c.Name == "PathImage").FirstOrDefault().Value;
            FrmThemMon frmThemMon = new FrmThemMon(this, db, pathDirectory, menu.MenuID);
            this.Hide();
            frmThemMon.Show();
        }

        private void buttonSuaMon_Click(object sender, EventArgs e)
        {
            var pathDirectory = db.Configurations.Where(c => c.Name == "PathImage").FirstOrDefault().Value;
            var listMenu = db.Menus.ToList();
            var menu = listMenu
                .FirstOrDefault(m => m.MealType == selectMeal.SelectedItem.ToString() && m.Date.Date == monthCalendar.SelectionStart.Date);
            if (menu == null)
            {
                return;
            }
            var listMenuFood = db.MenuFoods.Where(mf => mf.MenuId == menu.MenuID).ToList();
            //Get current selected row
            int selectedRowIndex = dgvData.CurrentRow.Index;
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MenuFood menuFood = listMenuFood[selectedRowIndex];
            FrmThemMon frmThemMon = new FrmThemMon(this, db, menu.MenuID, menuFood, pathDirectory);
            this.Hide();
            frmThemMon.Show();
        }

        private void selectMeal_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMeal();
        }
        public void loadMeal()
        {
            dgvData.Rows.Clear();
            pictureImage.Image = null;
            string mealType = selectMeal.SelectedItem.ToString();
            var date = monthCalendar.SelectionStart.Date;
            var listMenu = db.Menus.ToList();
            var menu = listMenu
                .FirstOrDefault(m => m.MealType == mealType && m.Date.Date == date);
            if (menu != null)
            {
                var listMenuFood = db.MenuFoods.Where(mf => mf.MenuId == menu.MenuID).ToList();
                menuFoods = listMenuFood;
                foreach (var menuFood in listMenuFood)
                {
                    dgvData.Rows.Add(menuFood.DishName, menuFood.Category, menuFood.Note, menuFood.Image);
                }
            }
        }
        public void loadFood()
        {
            if (dgvData.CurrentRow.Index < 0)
            {
                return;
            }
            int selectedRowIndex = dgvData.CurrentRow.Index;
            var menuFood = menuFoods[selectedRowIndex];
            var pathDirectory = db.Configurations.Where(c => c.Name == "PathImage").FirstOrDefault().Value;
            var path = System.IO.Path.Combine(pathDirectory, menuFood.Image);
            pictureImage.Image = System.Drawing.Image.FromFile(path);
        }

        private void RefreshCalendar()
        {
            monthCalendar.RemoveAllBoldedDates();
            var listMenu = db.Menus.ToList();
            foreach (var menu in listMenu)
            {
                monthCalendar.AddBoldedDate(menu.Date);
            }
            monthCalendar.UpdateBoldedDates();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            loadMeal();
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            loadFood();
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvData.CurrentRow.Index;
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MenuFood menuFood = menuFoods[selectedRowIndex];
                deleteMeal(menuFood);
            }
        }

        private void baocaoCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadReport();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0:
                    RefreshCalendar();
                    break;
                case 1:
                    LoadReport();
                    break;
                case 2:
                    LoadFeedBack();
                    break;
                case 4:
                    LoadConfiguration();
                    break;
            }
        }

        private void LoadConfiguration()
        {
            int GioComTrua = int.Parse(db.Configurations.FirstOrDefault(c => c.Name == "TimeLunch").Value);
            int GioComToi = int.Parse(db.Configurations.FirstOrDefault(c => c.Name == "TimeDinner").Value);
            numberGioComTrua.Value = GioComTrua;
            numberGioComToi.Value = GioComToi;
        }

        private void LoadFeedBack()
        {
            dgvThongBao.Rows.Clear();
            var listFeedback = db.Feedbacks.ToList();
            foreach (var feedback in listFeedback)
            {
                string note = "";
                string dateFormat = feedback.CreatedAt.ToString("HH:mm:ss dd/MM/yyyy");
                if (feedback.MenuID != -1)
                {
                    var menu = db.Menus.FirstOrDefault(m => m.MenuID == feedback.MenuID);
                    note = "Bữa " + menu.MealType.ToLower() + " " + menu.Date.ToString("dd/MM/yyyy");
                }
                dgvThongBao.Rows.Add(feedback.Message, dateFormat, note);
            }
        }

        private void LoadReport()
        {
            var date = baocaoCalendar.SelectionStart.Date;
            buaToiReport.SetDateTime(date);
            buaTruaReport.SetDateTime(date);
            var totalSinhVien = db.Users.Where(u => u.Role == "student").Count();
            var totalGiaoVien = db.Users.Where(u => u.Role == "teacher").Count();
            // Bữa trưa
            var menuTrua = db.Menus.ToList().FirstOrDefault(m => m.MealType == "Trưa" && m.Date.Date == date);
            buaTruaReport.SetTotal(totalSinhVien, totalGiaoVien);
            if (menuTrua != null)
            {
                int countOrders = db.Orders.Where(o => o.MenuID == menuTrua.MenuID).Count();
                var listMenuFood = db.MenuFoods.Where(mf => mf.MenuId == menuTrua.MenuID).ToList();
                int monMan = listMenuFood.Where(mf => mf.Category == "Ăn mặn").Count();
                int monChay = listMenuFood.Where(mf => mf.Category == "Ăn chay").Count();
                int monDacBiet = listMenuFood.Where(mf => mf.Category == "Đặc biệt").Count();
                buaTruaReport.TongSuatAn = countOrders;
                buaTruaReport.SetCount(monMan * countOrders, monChay * countOrders, monDacBiet * countOrders);
                int GioComTrua = int.Parse(db.Configurations.FirstOrDefault(c => c.Name == "TimeLunch").Value);
                // Trạng thái
                bool daChot = date.Date != DateTime.Now.Date 
                    || (date.Date == DateTime.Now.Date && DateTime.Now.Hour >= GioComTrua);
                buaTruaReport.SetTrangThai(daChot);
                lbTrangThaiTrua.Text = daChot ? "Đã chốt" : "Chưa chốt";
                lbTrangThaiTrua.ForeColor = daChot ? Color.Green : Color.Red;
                // Tính số lượng sinh viên đặt & giảng viên đặt
                var listOrder = db.Orders.Where(o => o.MenuID == menuTrua.MenuID).ToList();
                int totalSV = listOrder.Where(o => o.User.Role == "student").Count();
                int totalGV = listOrder.Where(o => o.User.Role == "teacher").Count();
                ReportSVTrua.Text = $"{totalSV}/{totalSinhVien}";
                ReportGVTrua.Text = $"{totalGV}/{totalGiaoVien}";
            }
            else
            {
                lbTrangThaiTrua.Text = "Chưa có thực đơn";
                lbTrangThaiTrua.ForeColor = Color.Black;
                ReportSVTrua.Text = $"{0}/{totalSinhVien}";
                ReportGVTrua.Text = $"{0}/{totalGiaoVien}";
            }
            // Bữa tối
            var menuToi = db.Menus.ToList().FirstOrDefault(m => m.MealType == "Tối" && m.Date.Date == date);
            buaToiReport.SetTotal(totalSinhVien, totalGiaoVien);
            if (menuToi != null)
            {
                int countOrders = db.Orders.Where(o => o.MenuID == menuToi.MenuID).Count();
                var listMenuFood = db.MenuFoods.Where(mf => mf.MenuId == menuToi.MenuID).ToList();
                int monMan = listMenuFood.Where(mf => mf.Category == "Ăn mặn").Count();
                int monChay = listMenuFood.Where(mf => mf.Category == "Ăn chay").Count();
                int monDacBiet = listMenuFood.Where(mf => mf.Category == "Đặc biệt").Count();
                buaToiReport.TongSuatAn = countOrders;
                buaToiReport.SetCount(monMan * countOrders, monChay * countOrders, monDacBiet * countOrders);
                int GioComToi = int.Parse(db.Configurations.FirstOrDefault(c => c.Name == "TimeDinner").Value);
                // Trạng thái
                bool daChot = date.Date != DateTime.Now.Date
                    || (date.Date == DateTime.Now.Date && DateTime.Now.Hour >= GioComToi);
                buaToiReport.SetTrangThai(daChot);
                lbTrangThaiToi.Text = daChot ? "Đã chốt" : "Chưa chốt";
                lbTrangThaiToi.ForeColor = daChot ? Color.Green : Color.Red;
                // Tính số lượng sinh viên đặt & giảng viên đặt
                var listOrder = db.Orders.Where(o => o.MenuID == menuToi.MenuID).ToList();
                int totalSV = listOrder.Where(o => o.User.Role == "student").Count();
                int totalGV = listOrder.Where(o => o.User.Role == "teacher").Count();
                ReportSVToi.Text = $"{totalSV}/{totalSinhVien}";
                ReportGVToi.Text = $"{totalGV}/{totalGiaoVien}";
            }
            else
            {
                lbTrangThaiToi.Text = "Chưa có thực đơn";
                lbTrangThaiToi.ForeColor = Color.Black;
                ReportSVToi.Text = $"{0}/{totalSinhVien}";
                ReportGVToi.Text = $"{0}/{totalGiaoVien}";
            }
        }

        private void btnChiTietReportTrua_Click(object sender, EventArgs e)
        {
            MessageBox.Show(buaTruaReport.ToReport(), "Báo cáo bữa trưa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChiTietReportToi_Click(object sender, EventArgs e)
        {
            MessageBox.Show(buaToiReport.ToReport(), "Báo cáo bữa tối", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuiThongBao_Click(object sender, EventArgs e)
        {
            var thongbao = txtThongBao.Text;
            if (string.IsNullOrEmpty(thongbao))
            {
                MessageBox.Show("Vui lòng nhập thông báo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thongbao = "[NHÀ BẾP THÔNG BÁO]: " + thongbao.Trim();
            int selectedIndex = comboDoiTuong.SelectedIndex;
            var listUser = db.Users.ToList();
            switch (selectedIndex)
            {
                case 1:
                    {
                        listUser = db.Users.Where(u => u.Role == "student").ToList();
                        break;
                    }
                case 2:
                    {
                        listUser = db.Users.Where(u => u.Role == "teacher").ToList();
                        break;
                    }
            }
            foreach (var user in listUser)
            {
                db.Notifications.Add(new Notification
                {
                    Message = thongbao,
                    UserID = user.UserId,
                    CreatedAt = DateTime.Now,
                    IsRead = false
                });
            }
            db.SaveChanges();
            MessageBox.Show("Gửi thông báo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuuCauHinh_Click(object sender, EventArgs e)
        {
            int GioComTrua = (int)numberGioComTrua.Value;
            int GioComToi = (int)numberGioComToi.Value;
            db.Configurations.FirstOrDefault(c => c.Name == "TimeLunch").Value = GioComTrua.ToString();
            db.Configurations.FirstOrDefault(c => c.Name == "TimeDinner").Value = GioComToi.ToString();
            db.SaveChanges();
            MessageBox.Show("Lưu cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Session.ClearSession();
                this.Close();
            }
        }

        private void FrmNhaBepMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmLogin.Show();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var date = baocaoCalendar.SelectionStart.Date.ToString("dd/MM/yyyy");
            var buaTruaDTO = ReportDTO.FromReport(buaTruaReport, "Bữa trưa - " + date);
            var buaToiDTO = ReportDTO.FromReport(buaToiReport, "Bữa tối - " + date);
            var listReport = new List<ReportDTO> { buaTruaDTO, buaToiDTO };
            var excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Cells[1, 1] = "Thời gian";
            worksheet.Cells[1, 2] = "Tổng suất ăn";
            worksheet.Cells[1, 3] = "Món mặn";
            worksheet.Cells[1, 4] = "Món chay";
            worksheet.Cells[1, 5] = "Món đặc biệt";
            Excel.Range headerRange = worksheet.get_Range("A1", "E1");
            headerRange.Font.Bold = true;
            headerRange.Font.Size = 12;
            headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            for (int i = 0; i < listReport.Count; i++)
            {
                worksheet.Cells[i + 2, 1] = listReport[i].Time;                    ;
                worksheet.Cells[i + 2, 2] = listReport[i].TongSuatAn;
                worksheet.Cells[i + 2, 3] = listReport[i].MonMan;
                worksheet.Cells[i + 2, 4] = listReport[i].MonChay;
                worksheet.Cells[i + 2, 5] = listReport[i].MonDacBiet;
            }
            worksheet.Columns.AutoFit();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx"; // Chỉ cho phép chọn file Excel
            saveFileDialog.Title = "Lưu File Excel";
            string guid = Guid.NewGuid().ToString();
            saveFileDialog.FileName = "BaoCao_" + date + "_" + guid + ".xlsx";
            if(saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filePath = saveFileDialog.FileName;
            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();
            MessageBox.Show("Dữ liệu đã được xuất ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            var date = baocaoCalendar.SelectionStart.Date.ToString("dd/MM/yyyy");
            var buaTruaDTO = ReportDTO.FromReport(buaTruaReport, "Bữa trưa - " + date);
            var buaToiDTO = ReportDTO.FromReport(buaToiReport, "Bữa tối - " + date);
            var listReport = new List<ReportDTO> { buaTruaDTO, buaToiDTO };
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Lưu File PDF";
            string guid = Guid.NewGuid().ToString();
            saveFileDialog.FileName = "BaoCao_" + date + "_" + guid + ".pdf";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filePath = saveFileDialog.FileName;
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                string fontPath = @"C:\Windows\Fonts\times.ttf"; 
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);

                var title = new Paragraph("Báo cáo cơm ngày: " + date, font)
                {
                    Alignment = Element.ALIGN_CENTER,
                    Font = font
                };
                document.Add(title);
                document.Add(new Paragraph(" "));  
                document.Add(new Paragraph(" "));
                var table = new PdfPTable(5) { WidthPercentage = 100 }; 
                table.AddCell(new PdfPCell(new Phrase("Thời gian", font)));
                table.AddCell(new PdfPCell(new Phrase("Tổng suất ăn", font)));
                table.AddCell(new PdfPCell(new Phrase("Món mặn", font)));
                table.AddCell(new PdfPCell(new Phrase("Món chay", font)));
                table.AddCell(new PdfPCell(new Phrase("Món đặc biệt", font)));
                foreach (var report in listReport)
                {
                    table.AddCell(new PdfPCell(new Phrase(report.Time.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(report.TongSuatAn.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(report.MonMan.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(report.MonChay.ToString(), font)));
                    table.AddCell(new PdfPCell(new Phrase(report.MonDacBiet.ToString(), font)));
                }

                document.Add(table);
                document.Close();
                writer.Close();
            }
            MessageBox.Show("Dữ liệu đã được xuất ra PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
