namespace ADS.Delivery.API.V1.Parametros;

public class ADSDAPIParamInserirPrato
{
    #region Parametros
    public required string PratoNome { get; set; } = string.Empty;
    public required string PratoDescricao { get; set; } = string.Empty;
    public required decimal PratoPreco { get; set; } = 0;
    public required string CategoriaNome { get; set; } = string.Empty;
    #endregion
    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaPrato()
    {
        var resultado = ADSValidadorPratoParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }
}

internal static class ADSValidadorPratoParam
{
    internal static (bool Resultado, string? Mensagem) ValidarEntrada(ADSDAPIParamInserirPrato prato)
    {
        #region Verificacoes
        var validacaoNome = VerificacaoString(prato.PratoNome);
        if (!validacaoNome.Resultado)
            return validacaoNome;

        var validacaoDescricao = VerificacaoString(prato.PratoDescricao);
        if (!validacaoDescricao.Resultado)
            return validacaoDescricao;

        var validacaoCategoria = VerificacaoString(prato.CategoriaNome);
        if (!validacaoCategoria.Resultado)
            return validacaoCategoria;

        if (prato.PratoPreco < 0)
            return (false, $"O preço do prato deve ser maior ou igual a 0");
        #endregion

        static (bool Resultado, string? Mensagem) VerificacaoString(string parametro)
        {
            if (string.IsNullOrWhiteSpace(parametro))
                return (false, $"O campo {nameof(parametro)} nao pode estar vazio ou em branco");

            return (true, null);
        }

        return (true, null);
    }
}