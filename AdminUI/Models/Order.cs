namespace AdminUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int MenuID { get; set; }

        public DateTime OrderTime { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual User User { get; set; }
    }
}
