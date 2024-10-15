using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public static class ADSVerificacaoString
{
    static (bool Resultado, string? Mensagem) VerificacaoString(string parametro)
    {
        if (string.IsNullOrWhiteSpace(parametro))
            return (false, $"O campo {nameof(parametro)} nao pode estar vazio ou em branco");

        return (true, null);
    }
}
