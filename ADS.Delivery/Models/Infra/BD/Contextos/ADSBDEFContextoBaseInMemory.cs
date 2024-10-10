using ADS.Delivery.API.Models.Aplicacao.Classes;
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1.Models.Infra.BD.Bases
{
    public class ADSBDEFContextoBaseInMemory: DbContext
    {
        public ADSBDEFContextoBaseInMemory(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ADSDAPIParamInserirAlimento> Alimentos { get; set; }
        public DbSet<ADSDAPIParamInserirCategoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADSDAPIParamInserirAlimento>()
                .HasOne(a => a.ALI_ID)
                .WithMany(char => char.A)
        }
    }
}
