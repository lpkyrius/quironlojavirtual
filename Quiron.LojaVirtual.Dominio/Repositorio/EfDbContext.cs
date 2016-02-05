
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Quiron.LojaVirtual.Dominio.Entidades; // Exigiu esta declaração para reconhecer DbSet<Produto>

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove a pluralidade que faria com que o Entity procurasse automaticamente o nome da tabela conforme o nome do DbSet acima. No caso Produtos
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            
            // Uma vez removida a pluralidade, agora eu mesmo informo qual o nome da tabela no banco
            modelBuilder.Entity<Produto>().ToTable("Produtos");
        }

    }
}
