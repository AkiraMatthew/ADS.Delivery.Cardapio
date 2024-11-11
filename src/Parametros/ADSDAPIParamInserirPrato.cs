namespace ADS.Delivery.Cardapio.API.V1.Parametros;

public class ADSDAPIParamInserirPrato
{
    #region Parametros
    public string PratoNome { get; set; } = string.Empty;
    public string PratoDescricao { get; set; } = string.Empty;
    public decimal PratoPreco { get; set; } = 0;
    #endregion
    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaPrato()
    {
        var resultado = ADSValidadorPratoParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }
}

