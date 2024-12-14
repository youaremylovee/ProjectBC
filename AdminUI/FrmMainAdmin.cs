using ProjectAbstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminUI
{
    public partial class FrmMainAdmin : Form
    {
        private readonly MyDB db = new MyDB();
        private List<Feedback> feedbacks = new List<Feedback>();
        private Session session = Session.Instance;
        private readonly Form _frmLogin;

        public FrmMainAdmin()
        {
            InitializeComponent();
        }

        public FrmMainAdmin(Form frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        internal void LoadUsers()
        {
            dgvAccounts.Rows.Clear();
            foreach (var item in db.Users)
            {
                dgvAccounts.Rows.Add(item.UserId, item.FullName, item.Email,
                    item.Phone, item.Major, item.Role);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            switch(index)
            {
                case 0:
                    LoadUsers();
                    break;
                case 1:
                    LoadFeedBacks();
                    break;
                case 2:
                    LoadInformation();
                    break;
            }
        }

        private void LoadInformation()
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == session.UserId);
            if(user != null)
            {
                txtHoTen.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
            }
            else
            {
                txtHoTen.Text = "Unknown";
                txtEmail.Text = "Unknown";
                txtPhone.Text = "Unknown";
            }
        }

        private void LoadFeedBacks()
        {
            dgvThongBao.Rows.Clear();
            feedbacks.Clear();
            var listFeedback = db.Feedbacks.ToList();
            feedbacks.AddRange(listFeedback);
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

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            btnSuaThongTin.Enabled = dgvAccounts.CurrentRow != null;
            btnXoaTaiKhoan.Enabled = dgvAccounts.CurrentRow != null;
        }

        private void dgvThongBao_SelectionChanged(object sender, EventArgs e)
        {
            txtPhanHoi.Enabled = dgvThongBao.CurrentRow != null;
            btnPhanHoi.Enabled = dgvThongBao.CurrentRow != null;
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            if(txtPhanHoi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập phản hồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var replyMsg = "Bạn đã viết: \"" + dgvThongBao.CurrentRow.Cells[0].Value.ToString() + "\"" + Environment.NewLine;
            replyMsg += "[ADMIN]: " + txtPhanHoi.Text;
            var notification = new Notification()
            {
                UserID = feedbacks[dgvThongBao.CurrentRow.Index].UserID,
                Message = replyMsg,
                CreatedAt = DateTime.Now,
                IsRead = false
            };
            db.Notifications.Add(notification);
            db.SaveChanges();
            MessageBox.Show("Đã gửi trả lời thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtPhanHoi.Text = "";
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(dgvAccounts.CurrentRow.Cells[0].Value.ToString());
            if (userId == session.UserId)
            {
                MessageBox.Show("Không thể xóa tài khoản của chính mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                var dialogConfirm = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogConfirm == DialogResult.No) return;
                db.Users.Remove(user);
                db.SaveChanges();
                MessageBox.Show("Đã xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadUsers();
        }

        private void buttonThemTaiKhoan_Click(object sender, EventArgs e)
        {
            FrmAccount frmAccount = new FrmAccount(db, isAdd: true, isSameAccount: false, user: null, parent: this);
            frmAccount.Show();
            this.Hide();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(dgvAccounts.CurrentRow.Cells[0].Value.ToString());
            var isSameAccount = session.UserId == userId;
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if(user == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmAccount frmAccount = new FrmAccount(db, isAdd: false, isSameAccount: isSameAccount, user: user, parent: this);
            frmAccount.Show();
            this.Hide();
        }

        private void FrmMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmLogin.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var dialogConfirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogConfirm == DialogResult.Yes)
            {
                Session.ClearSession();
                this.Close();
            }
        }
    }
}
