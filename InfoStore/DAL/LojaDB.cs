using InfoStore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InfoStore.DAL
{
    public class LojaDB : DbContext
    {
        public LojaDB() : base("LojaDB")
        {
        }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Config> Configs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<InfoStore.Models.Compra> Compras { get; set; }

        public System.Data.Entity.DbSet<InfoStore.Models.Factura> Facturas { get; set; }
    }
}