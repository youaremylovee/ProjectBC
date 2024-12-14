namespace AdminUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuFood
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        [Required]
        [StringLength(100)]
        public string DishName { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        public string Image { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
