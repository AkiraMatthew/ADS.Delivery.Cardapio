namespace ADS.Delivery.API.V1.Parametros;

public class ADSDAPIParamInserirPrato
{
    #region Parametros
    public required string PratoNome { get; set; } = string.Empty;
    public string PratoDescricao { get; set; } = string.Empty;
    public decimal PratoPreco { get; set; } = 0;
    public int CategoriaId { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;
    #endregion
    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaPrato()
    {
        var resultado = ADSValidadorPratoParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }

    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaCategoria()
    {
        var resultado = ADSValidadorPratoParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }
}

