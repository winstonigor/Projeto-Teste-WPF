using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        public Fornecedor()
        {
            Produto = new List<Produto>();
        }

        [Key]
        public int For_codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string For_nome { get; set; }
        [MaxLength(50)]
        [Required]
        public string For_cnpj { get; set; }
        [MaxLength(50)]
        [Required]
        public string For_endereco { get; set; }
        
        [Required]
        public bool For_ativ { get; set; }


      
        public virtual List<Produto> Produto { get; set; }
    }
}
