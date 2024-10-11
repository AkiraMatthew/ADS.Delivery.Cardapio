using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Delivery.API.V1;

[Table("D_PRT")]
public class D_PRT
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //geracao automatica do Id
    [Column("PRT_ID")]
    public int PrtId { get; set; }

    [Column("PRT_NOME")]
    public string PrtNome { get; set; }

    [Column("PRT_DESC")]
    public string PrtDesc { get; set; }

    [Column("PRT_PRECO")]
    public decimal PrtPreco { get; set; }

    [Column("CATEG_ID")]
    public int CategId { get; set; }

    //propriedade de navegaçao para a tabela categoria
    public D_CATEG Categoria { get; set; }
}
