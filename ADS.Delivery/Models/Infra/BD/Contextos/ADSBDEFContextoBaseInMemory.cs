using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1;

public class ADSBDEFContextoBaseInMemory: DbContext
{
    public ADSBDEFContextoBaseInMemory(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<D_ALI> Alimentos { get; set; }
    public DbSet<D_CATEG> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<D_ALI>()
            .HasOne(alimento => alimento.Categoria)
            .WithMany(categoria => categoria.Alimentos)
            .HasForeignKey(alimento => alimento.CategId);
    }
}
