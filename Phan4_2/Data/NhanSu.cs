using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan4_2.Data
{
    [Table("NhanSu")]
    public class NhanSu
    {
        [Key]
        public int MaNV { get; set; }
        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }
        [Required]
        [StringLength(50)]
        public string QueQuan { get; set; }

        public int GioiTinh { get; set; }

        public DateTime Ngay_BD { get; set; }

        public int MaPB { get; set; }

        public int ID_Luong { get; set; }

        public virtual PhongBan phongban { get; set; }
        public virtual Luong luong { get; set; }
    }
}
