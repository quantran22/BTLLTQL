namespace BTLLTQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class Khachhang
    {
        [Key]
        public int MaKH { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(50)]
        public string Sđt { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string Hinh1 { get; set; }

        public ICollection<DanhGia> DanhGias { get; set; }
    }
}
