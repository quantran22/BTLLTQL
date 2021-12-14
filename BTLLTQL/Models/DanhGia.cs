namespace BTLLTQL.Models
{
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;


    [Table("DanhGias")]
    public class DanhGia
    {

        [Key]
        public int MaDanhGia { get; set; }
        public int MaSanPham { get; set; }
        public SanPham SanPham { get; set; }
        public int MaKH { get; set; }
        public Khachhang khachhang { get; set; }

        [Required, DisplayName("Ngày đánh giá")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay_Gio { get; set; }
        [Required, DisplayName("Nội dung đánh giá")]
        [AllowHtml]
        public string NoiDung { get; set; }
        public string Sđt { get; set; }
    }
}