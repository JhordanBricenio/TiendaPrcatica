using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TiendaPrcatica.Models.Mapping
{
    public class ProdutMapping : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.IdUsuario);
        }
    }
    
}
