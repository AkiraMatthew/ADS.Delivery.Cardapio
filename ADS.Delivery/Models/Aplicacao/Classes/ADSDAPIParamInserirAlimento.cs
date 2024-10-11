using System.ComponentModel.DataAnnotations;

namespace ADS.Delivery.API.V1;

public class ADSDAPIParamInserirAlimento
{
    [Key]
    public int IdAlimento{ get; set; }
    public string AlimentoNome { get; set; }
    public string AlimentoDescricao { get; set; }
    public decimal AlimentoPreco { get; set; }
    public int CategoriaAlimentoId { get; set; }
}
