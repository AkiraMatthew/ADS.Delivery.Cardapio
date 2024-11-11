namespace ADS.Delivery.Cardapio.API.V1.Parametros;

public class ADSAPIConsultarCategoriaDTO
{
    public int CategoriaId { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;
    public List<ADSDAPIInserirPratoDTO> Pratos { get; set; } = new List<ADSDAPIInserirPratoDTO>();
}
