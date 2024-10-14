using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Delivery.API.V1;

[Table("D_PRATO")]
public class D_PRATO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //geracao automatica do Id
    [Column("PRATO_ID")]
    public int PratoId { get; set; }

    [Column("PRATO_NOME")]
    public required string PratoNome { get; set; }

    [Column("PRATO_DESC")]
    public required string PratoDesc { get; set; }

    [Column("PRATO_PRECO")]
    public decimal PratoPreco { get; set; }

    [Column("CATEG_ID")]
    public int CategId { get; set; }

    //propriedade de navegaçao para a tabela categoria
    public required D_CATEG Categoria { get; set; }
}
