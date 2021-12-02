namespace BTLLTQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "PassWord is required")]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
        [Display(Name = "Phân Quyền")]
        [Required(ErrorMessage = "Phân Quyền không được để trống !!!")]
        public string RoleID { get; set; }
    }
}
