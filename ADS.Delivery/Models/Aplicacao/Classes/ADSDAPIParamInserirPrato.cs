namespace ADS.Delivery.API.V1;

public class ADSDAPIParamInserirPrato
{
    public string PratoNome { get; set; }
    public string PratoDescricao { get; set; }
    public decimal PratoPreco { get; set; }
    public string CategoriaNome { get; set; }
}

internal static class ADSValidadorPratoParam
{
    internal static (bool Resultado, string? Mensagem) ValidarEntrada(ADSDAPIParamInserirPrato prato, ADSDAPIParamInserirCategoria categoria)
    {
        var validacaoNome = VerificacaoString(prato.PratoNome);
        if(!validacaoNome.Resultado)
            return validacaoNome;

        var validacaoDescricao = VerificacaoString(prato.PratoDescricao);
        if(!validacaoDescricao.Resultado) 
            return validacaoDescricao;

        static (bool Resultado, string? Mensagem) VerificacaoString(string? parametro)
        {
            if (string.IsNullOrWhiteSpace(parametro))
                return (false, $"O campo {nameof(parametro)}");

            return (true, null);
        }
    }
}