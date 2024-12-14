using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaBepUI
{
    internal class ItemTable
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string DishType { get; set; }
        public string Note { get; set; }
        public Image Image { get; set; }
        public string ImagePath { get; set; }
    }
}
