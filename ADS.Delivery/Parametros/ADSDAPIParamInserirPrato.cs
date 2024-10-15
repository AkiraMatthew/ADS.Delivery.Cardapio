namespace ADS.Delivery.API.V1.Parametros;

public class ADSDAPIParamInserirPrato
{
    #region Parametros
    public string PratoNome { get; set; } = string.Empty;
    public string PratoDescricao { get; set; } = string.Empty;
    public decimal PratoPreco { get; set; } = 0;

    /// TODO Este método precisa sair da API e é necessário adaptar as chamadas para chamar de dentro da API de categorias
    /// O client nao precisa saber da relaçao entre as tabelas de Prato e Categoria, o service faz esse trabalho ao enviar os dados para o repositório
    //public string CategoriaNome { get; set; } = string.Empty;
    #endregion
    public (bool Resultado, string? Mensagem) ValidarPropsDeEntradaPrato()
    {
        var resultado = ADSValidadorPratoParam.ValidarEntrada(this);

        return resultado.Resultado ? (true, string.Empty) : (false, resultado.Mensagem);
    }
}

