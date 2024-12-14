using AdminUI;
using NhaBepUI;
using ProjectAbstraction;
using ProjectBaoCom.Models;
using SinhVienUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectBaoCom
{
    public partial class FrmLogin : Form
    {
        private readonly MyEntitites _entities = new MyEntitites();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private bool IsValidEmail(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{1,}$";
            return new Regex(pattern).IsMatch(input);
        }
        private bool IsValidPassword(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            string pattern = @"^(?!.*\s).{5,}$";
            return new Regex(pattern).IsMatch(input);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = tk.Text;
            string password = mk.Text;
            string role = vaitro.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(username))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 5 ký tự và không chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (role.Trim())
            {
                case "Sinh viên / Giảng viên":
                    {
                        var listUser = _entities.Users.ToList();
                        var user = listUser
                            .FirstOrDefault(u => u.Email == username 
                            && u.Password == password 
                            && (u.Role == "student" || u.Role == "teacher"));
                        if (user != null)
                        {
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Session.SetSession(user.UserId, user.Role);
                            FrmMain frmMain = new FrmMain(this);
                            frmMain.Show();
                            mk.Text = "";
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "Nhà bếp":
                    {
                        var listUser = _entities.Users.ToList();
                        var user = listUser
                            .FirstOrDefault(u => u.Email == username
                            && u.Password == password
                            && u.Role == "kitchen");
                        if (user != null)
                        {
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Session.SetSession(user.UserId, user.Role);
                            FrmNhaBepMain frmNhaBepMain = new FrmNhaBepMain(this);
                            frmNhaBepMain.Show();
                            mk.Text = "";
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "Quản trị viên":
                    {
                        var listUser = _entities.Users.ToList();
                        var user = listUser
                            .FirstOrDefault(u => u.Email == username
                            && u.Password == password
                            && u.Role == "admin");
                        if (user != null)
                        {
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Session.SetSession(user.UserId, user.Role);
                            FrmMainAdmin frmAdminMain = new FrmMainAdmin(this);
                            frmAdminMain.Show();
                            mk.Text = "";
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            vaitro.SelectedIndex = 0;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogConfirm = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogConfirm == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
