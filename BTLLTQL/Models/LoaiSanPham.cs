namespace BTLLTQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {

        public string MaLoaiSanPham { get; set; }
        [Key]
        public string TenLoaiSanPham { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
    }
}
