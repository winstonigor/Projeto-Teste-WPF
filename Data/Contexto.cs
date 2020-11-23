
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public class Contexto : DbContext
    {   // Inicializa o da Base de dados
        public Contexto() 
            : base("Name=BDTESTE")
        {
            Database.SetInitializer<Contexto>(
                new CreateDatabaseIfNotExists<Contexto>()); // cria a base se não existir de acordo com a estrutura definida no Damain
            Database.Initialize(false); //força inicialização*/ 
        }

        

        public virtual DbSet<Fornecedor> Fornecedor { get; set; } // conjunto de dados
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
