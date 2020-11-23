using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Pro_codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Pro_descricao { get; set; }
        
        [Required]
        public decimal Pro_saldo { get; set; }
        [ForeignKey("Fornecedor")]
        public int For_codigo { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}
