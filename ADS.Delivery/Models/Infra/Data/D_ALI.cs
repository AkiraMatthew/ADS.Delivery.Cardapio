using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Delivery.API.V1;

[Table("D_ALI")]
public class D_ALI
{
    [Key]
    [Column("ALI_ID")]
    public int AliId { get; set; }

    [Column("ALI_NOME")]
    public string AliNome { get; set; }

    [Column("ALI_DESC")]
    public string AliDesc { get; set; }

    [Column("ALI_PRECO")]
    public decimal AliPreco { get; set; }

    [Column("CATEG_ID")]
    public int CategId { get; set; }

    //propriedade de navegaçao para a tabela categoria
    public D_CATEG Categoria { get; set; }
}
