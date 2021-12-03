namespace BTLLTQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [StringLength(10)]
        public string TenLoaiSanPham { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }

        [StringLength(10)]
        public string TenNhaSanXuat { get; set; }
        public NhaSanXuat NhaSanXuat { get; set; }

        public string TenSanPham { get; set; }
        [AllowHtml]
        [Column(TypeName = "text")]
        public string CauHinh { get; set; }

        [StringLength(50)]
        public string HinhChinh { get; set; }

        public int? Gia { get; set; }

        public int? SoLuongBan { get; set; }

        [StringLength(10)]
        public string TinhTrang { get; set; }
    }
}
