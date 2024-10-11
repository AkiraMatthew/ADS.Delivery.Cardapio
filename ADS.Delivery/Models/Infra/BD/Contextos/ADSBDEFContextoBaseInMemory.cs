using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1;

public class ADSBDEFContextoBaseInMemory: DbContext
{
    public ADSBDEFContextoBaseInMemory(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<D_PRT> Pratos { get; set; }
    public DbSet<D_CATEG> Categorias { get; set; }
    public DbSet<ADS.Delivery.API.V1.ADSDAPIParamInserirAlimento> ADSDAPIParamInserirPrato { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<D_PRT>().HasKey(alimento => alimento.PrtId);

        modelBuilder.Entity<D_PRT>()
            .HasOne(alimento => alimento.Categoria)
            .WithMany(categoria => categoria.Pratos)
            .HasForeignKey(alimento => alimento.CategId);
    }

}
