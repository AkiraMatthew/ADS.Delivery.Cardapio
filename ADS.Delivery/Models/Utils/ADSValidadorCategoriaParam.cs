using ADS.Delivery.Cardapio.API.V1.Parametros;

namespace ADS.Delivery.Cardapio.API.V1.V1;

internal static class ADSValidadorCategoriaParam
{
    internal static (bool Resultado, string? Mensagem) ValidarEntrada(ADSDAPIParamInserirCategoria categoria)
    {
        #region Verificacoes
        var validacaoNome = VerificacaoString(categoria.CategoriaNome);
        if (!validacaoNome.Resultado)
            return validacaoNome;

        /*if (categoria.Pratos.Count < 0 && categoria.Pratos is null)
            return (false, $"O número de pratos dentro da categoria nao pode ser nulo e nem menor que 0");*/
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