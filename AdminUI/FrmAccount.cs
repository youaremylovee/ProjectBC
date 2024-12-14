using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminUI
{
    public partial class FrmAccount : Form
    {
        private readonly FrmMainAdmin _parent;
        private readonly MyDB _db = new MyDB();
        private readonly bool _isAdd = true;
        private readonly bool _isSameAccount = false;
        private readonly User _user = new User();
        public FrmAccount()
        {
            InitializeComponent();
        }

        public FrmAccount(MyDB db, bool isAdd, bool isSameAccount, User user, FrmMainAdmin parent) : this()
        {
            _db = db;
            _isAdd = isAdd;
            _isSameAccount = isSameAccount;
            _user = user;
            _parent = parent;
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            if (_isAdd)
            {
                labelTitle.Text = "Thêm tài khoản";
                btnSave.Text = "Thêm";
            }
            else
            {
                labelTitle.Text = "Cập nhật tài khoản";
                btnSave.Text = "Lưu";
            }
            if (_user != null)
            {
                txtHoten.Text = _user.FullName;
                txtEmail.Text = _user.Email;
                txtSDT.Text = _user.Phone;
                txtChuyenNganh.Text = _user.Major;
                if (_isSameAccount)
                {
                    txtChucVu.Enabled = false;
                }
                txtChucVu.Text = _user.Role;
                txtMatKhau.Text = _user.Password;
            }
            else
            {
                txtChucVu.SelectedIndex = 0;
                txtChuyenNganh.SelectedIndex = 0;
            }
        }

        private void FrmAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.LoadUsers();
            _parent.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsValidEmail(string input)
        {
            try 
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(input, pattern);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool IsValidPhone(string input)
        {
            try
            {
                string pattern = @"^0\d{9,10}$";
                return Regex.IsMatch(input, pattern);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool IsValidPassword(string input)
        {
            try
            {
                string pattern = @"^[^\s]{5,}$";
                return Regex.IsMatch(input, pattern);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Verify input
            var fullName = txtHoten.Text.Trim();
            var email = txtEmail.Text.Trim();
            var phone = txtSDT.Text.Trim();
            var major = txtChuyenNganh.Text.Trim();
            var role = txtChucVu.Text.Trim();
            var password = txtMatKhau.Text.Trim();
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(major) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!IsValidPassword(password))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 5 ký tự và không chứa khoảng trắng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if email is existed or phone existed
            var userEmailExisted = _db.Users.FirstOrDefault(u => u.Email == email);
            if (userEmailExisted != null)
            {
                MessageBox.Show("Email đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var userPhoneExisted = _db.Users.FirstOrDefault(u => u.Phone == phone);
            if (userPhoneExisted != null)
            {
                MessageBox.Show("Số điện thoại đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Add or update user
            if (_isAdd)
            {
                
                User user = new User
                {
                    FullName = txtHoten.Text,
                    Email = txtEmail.Text,
                    Phone = txtSDT.Text,
                    Major = txtChuyenNganh.Text,
                    Role = txtChucVu.Text,
                    Password = txtMatKhau.Text
                };
                _db.Users.Add(user);
                _db.SaveChanges();
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                var user = _db.Users.FirstOrDefault(u => u.UserId == _user.UserId);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    user.FullName = txtHoten.Text;
                    user.Email = txtEmail.Text;
                    user.Phone = txtSDT.Text;
                    user.Major = txtChuyenNganh.Text;
                    user.Role = txtChucVu.Text;
                    user.Password = txtMatKhau.Text;
                    _db.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }
    }
}
