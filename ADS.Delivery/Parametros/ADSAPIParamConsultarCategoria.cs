namespace ADS.Delivery.Cardapio.API.V1.Parametros;

public class ADSAPIParamConsultarCategoria
{
    public int CategoriaId { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;
    public List<ADSDAPIParamInserirPrato> Pratos { get; set; } = new List<ADSDAPIParamInserirPrato>();
}
