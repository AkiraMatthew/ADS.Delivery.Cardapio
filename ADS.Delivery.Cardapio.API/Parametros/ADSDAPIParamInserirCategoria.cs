using ADS.Delivery.Cardapio.API.V1;

namespace ADS.Delivery.Cardapio.API.V1.Parametros;

public class ADSDAPIParamInserirCategoria
{
    public string CategoriaNome { get; set; } = string.Empty;

    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaCategoria()
    {
        var resultado = ADSValidadorCategoriaParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }
}
