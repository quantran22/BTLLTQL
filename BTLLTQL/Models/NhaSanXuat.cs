namespace BTLLTQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        [Key]

        public string MaNhaSanXuat { get; set; }
        
        public string TenNhaSanXuat { get; set; }
        public ICollection<SanPham> sanPhams { get; set; }
    }
}