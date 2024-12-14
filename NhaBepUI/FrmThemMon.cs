using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaBepUI
{
    public partial class FrmThemMon : Form
    {
        private readonly FrmNhaBepMain _parent;
        private readonly DBEntities _context;
        private readonly string _dir;
        private readonly bool _isUpdate = false;
        private readonly int _menuId;
        private readonly int _menuFoodId = -1;
        private class ItemImage
        {
            public string ImagePath { get; set; } = string.Empty;
            public bool IsFromCloud { get; set; } = false;
        }
        private ItemImage _itemImage = new ItemImage();

        public FrmThemMon(FrmNhaBepMain parent, DBEntities context, string pathDirectory, int menuId)
        {
            _parent = parent;
            _context = context;
            _dir = pathDirectory;
            _menuId = menuId;
            InitializeComponent();
            listImageCloud.DataSource = _context.Clouds.ToList();
            listImageCloud.Columns[0].Visible = false;
            listImageCloud.Columns[2].Visible = false;
            listImageCloud.Columns[1].HeaderText = "Tên ảnh";
        }
        public FrmThemMon(FrmNhaBepMain parent,DBEntities context, int menuId, MenuFood item, string pathDirectory) : this(parent, context, pathDirectory, menuId)
        {
            txtTenMon.Text = item.DishName;
            txtLoaiMon.Text = item.Category;
            txtGhiChu.Text = item.Note;
            if (!string.IsNullOrEmpty(item.Image))
            {
                string pathImage = Path.Combine(pathDirectory, item.Image);
                pictureBox.Image = Image.FromFile(pathImage);
            }
            _isUpdate = true;
            _menuFoodId = item.Id;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectFromCloud_Click(object sender, EventArgs e)
        {
            List<Cloud> clouds = _context.Clouds.ToList();
        }

        private void btnSelectFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Lọc chỉ cho phép chọn file ảnh
                openFileDialog.Title = "Chọn ảnh";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        pictureBox.Image = Image.FromFile(filePath);
                        _itemImage.ImagePath = filePath;
                        _itemImage.IsFromCloud = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void listImageCloud_SelectionChanged(object sender, EventArgs e)
        {
            if (listImageCloud.CurrentRow != null) // Kiểm tra xem có dòng nào được chọn không
            {
                int selectedRowIndex = listImageCloud.CurrentRow.Index;
                var path = Path.Combine(_dir, _context.Clouds.ToArray()[selectedRowIndex].ImagePath);
                pictureBox.Image = Image.FromFile(path);
                _itemImage.ImagePath = _context.Clouds.ToArray()[selectedRowIndex].ImagePath;
                _itemImage.IsFromCloud = true;
            }
        }

        private void FrmThemMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.loadMeal();
            _parent.loadFood();
            _parent.Show();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtLoaiMon.Text))
            {
                MessageBox.Show("Tên món và loại món không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(pictureBox.Image == null)
            {
                MessageBox.Show("Chưa chọn ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_itemImage.IsFromCloud)
            {
                var uuid = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(_itemImage.ImagePath);
                var fileName = uuid + extension;
                var path = Path.Combine(_dir, fileName);
                File.Copy(_itemImage.ImagePath, path);
                _itemImage.ImagePath = fileName;

                // add to cloud
                _context.Clouds.Add(new Cloud
                {
                    ImageName = txtTenMon.Text,
                    ImagePath = fileName
                });
                _context.SaveChanges();
            }
            ItemTable item = new ItemTable
            {
                DishName = txtTenMon.Text,
                DishType = txtLoaiMon.Text,
                Note = txtGhiChu.Text,
                ImagePath = _itemImage.ImagePath,
                Id = _menuFoodId
            };
            if (_isUpdate)
            {
                if (_parent.updateMeal(_menuId, item))
                {
                    MessageBox.Show("Cập nhật món ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật món ăn thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (_parent.addMeal(_menuId, item))
                {
                    MessageBox.Show("Thêm món ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm món ăn thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmThemMon_Load(object sender, EventArgs e)
        {
            if(_isUpdate)
            {
                btnThemMon.Text = "Gửi";
            }
            else
            {
                txtLoaiMon.SelectedIndex = 0;
                btnThemMon.Text = "Thêm";
            }
        }
    }
}
