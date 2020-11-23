using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Usu_codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Usu_nome { get; set; }
        [MaxLength(50)]
        [Required]
        public string Usu_psw { get; set; }
        [MaxLength(50)]
        [Required]
        public string Usu_tipo { get; set; }

    }
}
