using ADS.Delivery.API.V1.Parametros;
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1;

public class ADSBDEFContextoBaseInMemory: DbContext
{
    public ADSBDEFContextoBaseInMemory(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<D_PRATO> Pratos { get; set; }
    public DbSet<D_CATEG> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<D_PRATO>().HasKey(alimento => alimento.PratoId);

        modelBuilder.Entity<D_PRATO>()
            .HasOne(alimento => alimento.Categoria)
            .WithMany(categoria => categoria.Pratos)
            .HasForeignKey(alimento => alimento.CategId);
    }

}
