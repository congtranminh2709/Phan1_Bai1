using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan4_2.Data
{
    [Table("PhongBan")]
    public class PhongBan
    {
        public PhongBan()
        {
            nhansu = new HashSet<NhanSu>();
        }
        [Key]
        public int MaPB { get; set; }
        [Required]
        [StringLength(50)]
        public string TenPB { get; set; }

        [Required]
        [StringLength(50)]
        public string MoTa { get; set; }

        [Required]
        public int STT_PB { get; set; }

        public int? Parent_ID { get; set; }

        public virtual ICollection<NhanSu> nhansu { get; set; }

    }
}
