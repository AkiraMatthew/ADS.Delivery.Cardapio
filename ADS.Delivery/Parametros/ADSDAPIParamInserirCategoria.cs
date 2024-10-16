namespace ADS.Delivery.API.V1.Parametros;

public class ADSDAPIParamInserirCategoria
{
    public string CategoriaNome { get; set; } = string.Empty;
    //public List<ADSDAPIParamInserirPrato> Pratos { get; set; } = new List<ADSDAPIParamInserirPrato>();

    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaCategoria()
    {
        var resultado = ADSValidadorCategoriaParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }
}
