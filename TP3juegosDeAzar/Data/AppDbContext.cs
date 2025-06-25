using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TP3juegosDeAzar.Models;

namespace TP3juegosDeAzar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=TP3Connection") { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Numero> Numeros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
