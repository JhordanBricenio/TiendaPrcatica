using Microsoft.EntityFrameworkCore;
using TiendaPrcatica.Models;
using TiendaPrcatica.Models.Mapping;

namespace TiendaPrcatica.DB
{
    public class DbEntities: DbContext
    {
        public DbEntities()
        {

        }
        public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProdutMapping());

        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }


    }
}
