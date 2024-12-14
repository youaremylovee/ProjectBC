namespace AdminUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cloud")]
    public partial class Cloud
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageName { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
