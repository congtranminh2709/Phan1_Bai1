using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan4_2.Data
{
    [Table("Luong")]
    public class Luong
    {
        public Luong()
        {
            nhansu = new HashSet<NhanSu>();
        }
        [Key]
        public int ID_Luong { get; set; }

        public decimal Bac_Luong { get; set; }
        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        public virtual ICollection<NhanSu> nhansu { get; set; }
    }
}
