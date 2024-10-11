namespace ADS.Delivery.API.V1;

public class ADSDAPIParamInserirCategoria
{
    public int CategoriaAlimentoId { get; set; }
    public string NomeCategoria { get; set; }  
    public List<ADSDAPIParamInserirAlimento> Alimentos { get; set; }
}
