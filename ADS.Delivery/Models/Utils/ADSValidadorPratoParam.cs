using ADS.Delivery.Cardapio.API.V1.Parametros;

namespace ADS.Delivery.Cardapio.API.V1;

public static class ADSValidadorPratoParam
{
    public static (bool Resultado, string? Mensagem) ValidarEntrada(ADSDAPIParamInserirPrato prato)
    {
        #region Verificacoes
        var validacaoNome = VerificacaoString(prato.PratoNome);
        if (!validacaoNome.Resultado)
            return validacaoNome;

        var validacaoDescricao = VerificacaoString(prato.PratoDescricao);
        if (!validacaoDescricao.Resultado)
            return validacaoDescricao;

        /*var validacaoCategoria = VerificacaoString(prato.CategoriaNome);
        if (!validacaoCategoria.Resultado)
            return validacaoCategoria;*/

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