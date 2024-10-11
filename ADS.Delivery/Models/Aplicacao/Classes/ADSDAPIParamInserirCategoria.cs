namespace ADS.Delivery.API.V1;

public class ADSDAPIParamInserirCategoria
{
    public string CategoriaNome { get; set; }  
    public List<ADSDAPIParamInserirPrato> Pratos { get; set; }
}
