//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NhaBepUI
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuFood
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string DishName { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
    
        public virtual Menu Menu { get; set; }
    }
}
