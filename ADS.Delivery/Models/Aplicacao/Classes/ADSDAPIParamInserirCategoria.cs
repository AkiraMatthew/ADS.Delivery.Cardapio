namespace ADS.Delivery.API.Models.Aplicacao.Classes;

public class ADSDAPIParamInserirCategoria
{
    public int IdAlimentoCategoria { get; set; }
    public string NomeCategoria { get; set; }  
    public List<ADSDAPIParamInserirAlimento> Alimentos { get; set; }
}
