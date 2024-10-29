namespace ADS.Delivery.API.V1.Parametros;

public class ADSAPIParamConsultarCategoria
{
    public string CategoriaNome { get; set; } = string.Empty;
    public List<ADSDAPIParamInserirPrato> Pratos { get; set; } = new List<ADSDAPIParamInserirPrato>();
}
