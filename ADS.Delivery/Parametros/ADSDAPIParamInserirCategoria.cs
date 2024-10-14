namespace ADS.Delivery.API.V1.Parametros;

public class ADSDAPIParamInserirCategoria
{
    public required string CategoriaNome { get; set; } = string.Empty;
    public required List<ADSDAPIParamInserirPrato> Pratos { get; set; } = new List<ADSDAPIParamInserirPrato>();
}
