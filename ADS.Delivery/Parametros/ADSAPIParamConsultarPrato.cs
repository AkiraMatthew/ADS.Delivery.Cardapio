namespace ADS.Delivery.API.V1.Parametros;

public class ADSDAPIParamConsultarPrato
{
    public int PratoId { get; set; }
    public string PratoNome { get; set; } = string.Empty;
    public string PratoDescricao { get; set; } = string.Empty;
    public decimal PratoPreco { get; set; } = 0;
    public string CategoriaNome { get; set; } = string.Empty; 
}
