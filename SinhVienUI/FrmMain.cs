using ProjectBaoCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVienUI
{
    public partial class FrmMain : Form
    {
        private readonly QuanLyComTruaEntities context = new QuanLyComTruaEntities();
        private Menu currentDayMeal = null;
        private Menu currentNightMeal = null;
        private Session _session;
        private int currentPageNotification = 1;
        public FrmMain(Session session)
        {
            _session = session;
            InitializeComponent();
        }
        private void loadMenus()
        {
            //Clear old menus 
            btnBaoComTrua.Visible = false;
            btnBaoComToi.Visible = false;

            dgvDay.Rows.Clear();
            dgvNight.Rows.Clear();
            currentDayMeal = null;
            currentNightMeal = null;
            // Get menus for date value
            var dateString = date.Value.ToString("yyyy-MM-dd");
            var lstMenus = context.Menus.ToList();
            var currentMenu = lstMenus
                      .Where(x => x.Date.ToString("yyyy-MM-dd") == dateString)
                      .ToList();
            if (currentMenu.Count() == 0)
            {
                MessageBox.Show("Chưa có thực đơn cho ngày hôm nay");
                return;
            }
            foreach (var item in currentMenu)
            {
                if (item != null && item.MenuFoods != null)
                {
                    var dgv = item.MealType == "Trưa" ? dgvDay : dgvNight;
                    var btn = item.MealType == "Trưa" ? btnBaoComTrua : btnBaoComToi;
                    // validate button
                    if (item.MealType == "Trưa")
                    {
                        currentDayMeal = item;
                    }
                    else
                    {
                        currentNightMeal = item;
                    }
                    // validate order
                    var order = context.Orders
                        .Where(x => x.UserID == _session.UserId
                        && x.MenuID == item.MenuID)
                        .FirstOrDefault();
                    if(order != null)
                    {
                        btn.Image = Properties.Resources.cancel;
                        btn.Text = "Hủy báo cơm";
                    }
                    else
                    {
                        btn.Image = Properties.Resources.add;
                        btn.Text = "Báo cơm";
                    }
                    foreach (var menuFood in item.MenuFoods)
                    {
                        if(item.Date.Date >= DateTime.Now.Date)
                        {
                            btn.Visible = true;
                        }
                        dgv.Rows.Add(menuFood.DishName, menuFood.Category, menuFood.Note);
                    }
                }
            }
        }
        private void loadOrdered()
        {
            //Clear old orders
            monthCalendar.RemoveAllBoldedDates();
            monthCalendar.UpdateBoldedDates();
            var orders = context.Orders
                .Where(x => x.UserID == _session.UserId)
                .ToList();
            foreach (var order in orders)
            {
                var orderTime = order.OrderTime.Date;
                monthCalendar.AddBoldedDate(orderTime);
            }
            monthCalendar.UpdateBoldedDates();
        }
        private void loadHistory()
        {
            //Clear
            dgvHDay.Rows.Clear();
            dgvHNight.Rows.Clear();
            // Load
            var date = monthCalendar.SelectionStart;
            var listMenus = context.Menus.ToList();
            var menus = listMenus.Where(m => m.Date.Date == date.Date);
            foreach (var menu in menus)
            {
                var dgv = menu.MealType == "Trưa" ? dgvHDay : dgvHNight;
                foreach(var MealItems in menu.MenuFoods)
                {
                    dgv.Rows.Add(MealItems.DishName, MealItems.Note);
                }
            }
        }
        private void loadNotification()
        {
            if(currentPageNotification < 1)
            {
                currentPageNotification = 1;
            }
            var notis = context.Notifications.OrderByDescending(m => m.CreatedAt).AsQueryable();
            notis = notis.Where(m => m.UserID ==  _session.UserId);
            var lst = notis.ToList();
            var p = lst.Count / 3;
            var q = lst.Count % 3 != 0 ? 1 : 0;
            int total = p + q ;
            if(currentPageNotification > total)
            {
                currentPageNotification = 1;
            }
            notis = notis.Skip((currentPageNotification - 1) * 3).Take(3);
            List<Notification> notifications = notis.ToList();
            TextBox[] tbs = new TextBox[] { tb1, tb2, tb3};
            foreach(var tb  in tbs)
            {
                tb.Text = "";
            }
            int index = 0;
            foreach (var notification in notifications)
            {

                tbs[index].Text = notification.Message;
                if (!notification.IsRead)
                {
                    tbs[index].Font = new Font("Arial", 12, FontStyle.Bold);
                    notification.IsRead = true;
                    context.Notifications.Attach(notification);
                    context.Entry(notification).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    tbs[index].Font = new Font("Arial", 12, FontStyle.Regular);
                }
                index++;
            }
            labelPaging.Text = $"{currentPageNotification} / {total}";
        }
        private void loadUser()
        {
            var user = context.Users.Find(_session.UserId);
            if(user != null)
            {
                txtHoTen.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtSdt.Text = user.Phone;
                txtChuyenNganh.Text = user.Major;
                txtChucVu.Text = user.Role;
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            date.Value = DateTime.Now;
            typeForm.SelectedIndex = 0;
            formMeal.SelectedIndex = 0;
            loadMenus();
            loadOrdered();
            loadHistory();
            loadUser();
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            var dt = date.Value;
            var today = DateTime.Now;
            if(dt.Date < today.Date)
            {
                btnBaoComToi.Visible = false;
                btnBaoComTrua.Visible = false;
            }
            else
            {
                btnBaoComToi.Visible = true;
                btnBaoComTrua.Visible = true;
            }
            loadMenus();
        }

        private void btnBaoComTrua_Click(object sender, EventArgs e)
        {
            if (currentDayMeal == null)
            {
                MessageBox.Show("Chưa có thực đơn cho bữa trưa ngày đã chọn");
                return;
            }
            else
            {
                var exist = context.Orders
                    .Where(x => x.UserID == _session.UserId
                    && x.MenuID == currentDayMeal.MenuID)
                    .FirstOrDefault() != null;
                if (!exist)
                {
                    context.Orders.Add(new Order
                    {
                        MenuID = currentDayMeal.MenuID,
                        UserID = _session.UserId,
                        OrderTime = DateTime.Now
                    });
                    btnBaoComTrua.Image = Properties.Resources.cancel;
                    btnBaoComTrua.Text = "Hủy báo cơm";
                }
                else
                {
                    var old = context.Orders
                        .Where(x => x.UserID == _session.UserId
                        && x.MenuID == currentDayMeal.MenuID)
                        .FirstOrDefault();
                    context.Orders.Remove(old);
                    btnBaoComTrua.Image = Properties.Resources.add;
                    btnBaoComTrua.Text = "Báo cơm";

                }
                context.SaveChanges();
            }
        }

        private void btnBaoComToi_Click(object sender, EventArgs e)
        {
            if (currentNightMeal == null)
            {
                MessageBox.Show("Chưa có thực đơn cho bữa tối ngày đã chọn");
                return;
            }
            else
            {
                var exist = context.Orders
                    .Where(x => x.UserID == _session.UserId
                    && x.MenuID == currentNightMeal.MenuID)
                    .FirstOrDefault() != null;
                if (!exist)
                {
                    context.Orders.Add(new Order
                    {
                        MenuID = currentNightMeal.MenuID,
                        UserID = _session.UserId,
                        OrderTime = DateTime.Now
                    });
                    btnBaoComToi.Image = Properties.Resources.cancel;
                    btnBaoComToi.Text = "Hủy báo cơm";
                }
                else
                {
                    var old = context.Orders
                        .Where(x => x.UserID == _session.UserId
                        && x.MenuID == currentNightMeal.MenuID)
                        .FirstOrDefault();
                    context.Orders.Remove(old);
                    btnBaoComToi.Image = Properties.Resources.add;
                    btnBaoComToi.Text = "Báo cơm";
                }
                context.SaveChanges();
            }
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            loadHistory();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if(index == 2)
            {
                loadNotification();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentPageNotification--;
            loadNotification();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPageNotification++;
            loadNotification();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string subject = formSubject.Text;
            string content = formContent.Text;
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return;
            }
            DateTime dateSubmit = formDate.Value;
            if (dateSubmit.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày phản ánh không được quá hôm nay !");
                return;
            }
            int menuId = -1;
            int formTypeSelected = typeForm.SelectedIndex;
            if (formTypeSelected == 1) 
            {
                string mealType = formMeal.Text;
                var lst = context.Menus.ToList();
                var menu = lst
                    .Where(x => x.Date.Date == dateSubmit.Date && x.MealType == mealType)
                    .FirstOrDefault();
                if (menu != null)
                {
                    menuId = menu.MenuID;
                }
                else
                {
                    MessageBox.Show("Ngày hôm đó không có bữa " + mealType + " !");
                    return;
                }
            }
            context.Feedbacks.Add(new Feedback
            {
                Message = subject + " - " + content,
                CreatedAt = DateTime.Now,
                UserID = _session.UserId,
                MenuID = menuId
            });
            context.SaveChanges();
            MessageBox.Show("Gửi phản hồi thành công","Thành công",MessageBoxButtons.OK,MessageBoxIcon.Information);
            formContent.Text = "";
            formSubject.Text = "";
        }

        private void typeForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            formMeal.Enabled = typeForm.SelectedIndex == 1;
        }
        private bool isValidEmail(string email)
        {
            var pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        private bool isValidPhone(string phone)
        {
            var pattern = @"^0[0-9]{9,10}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phone, pattern);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSdt.Text) || string.IsNullOrEmpty(txtChuyenNganh.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return;
            }
            if (!isValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }
            if (!isValidPhone(txtSdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            var old = context.Users.Find(_session.UserId);
            if (old != null) 
            {
                old.FullName = txtHoTen.Text;
                old.Email = txtEmail.Text;
                old.Phone = txtSdt.Text;
                old.Major = txtChuyenNganh.Text;
                context.Users.Attach(old);
                context.Entry(old).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
