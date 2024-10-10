using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Delivery.API.V1;

[Table("D_ALI")]
public class D_CATEG
{
    [Key]
    [Column("CATEG_ID")]
    public int CategId { get; set; }

    [Column("CATEG_NOME")]
    public string CategNome { get; set; }

    public List<D_ALI> Alimentos { get; set; }
}
