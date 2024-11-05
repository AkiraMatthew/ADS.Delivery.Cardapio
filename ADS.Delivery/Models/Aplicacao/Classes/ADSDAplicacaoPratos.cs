
using ADS.Delivery.Cardapio.API.V1.Parametros;

namespace ADS.Delivery.Cardapio.API.V1;

public class ADSDAplicacaoPratos(
    IADSDRepositorioPratos _pratosRepositorio,
    IADSDRepositorioCategorias _categoriasRepositorio,
    IADSDAplicacaoCategorias _categoriasAplicacao) 
    : IADSDAplicacaoPratos
{
    public ADSDAPIParamConsultarPrato ConsultarPratoPorNome(string pratoNome)
    {
        var prato = _pratosRepositorio.ConsultarPratoPorNome(pratoNome);

        if(prato is null)
            throw new Exception("O prato que você procura nao existe");

        var pratoResultadoAPI = new ADSDAPIParamConsultarPrato
        { 
            PratoId = prato.PratoId,
            PratoNome = pratoNome,
            PratoDescricao = prato.PratoDesc,
            PratoPreco = prato.PratoPreco,
            CategoriaNome = prato.Categoria.CategNome
        };

        return pratoResultadoAPI;
    }

    public void InserirPratoNaCategoria(ADSDAPIParamInserirPrato prato, string categoriaNome)
    {
        var categoriaExistente = _categoriasRepositorio.ConsultarCategoriaPorNome(categoriaNome);
        if (categoriaExistente is null)
        {
            var categoriaBD = new ADSDAPIParamInserirCategoria
            {
                CategoriaNome = categoriaNome
            };
            _categoriasAplicacao.InserirCategoria(categoriaBD);
            categoriaExistente = _categoriasRepositorio.ConsultarCategoriaPorNome(categoriaNome);
        }

        var pratoBD = new D_PRATO
        {
            PratoNome = prato.PratoNome,
            PratoDesc = prato.PratoDescricao,
            PratoPreco = prato.PratoPreco,
            Categoria = categoriaExistente
        };
        Console.WriteLine(pratoBD);
        _pratosRepositorio.InserirPrato(pratoBD, categoriaExistente);
    }
    public void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos)
    {
        throw new NotImplementedException();
    }

}

/*public ADSDAPIParamInserirPrato ConsultarPratoPorNomeECategoria(string pratoNome, string categoriaNome)
{
    var prato = _pratosRepositorio.ConsultarPratoComCategoria(pratoNome);

    if (prato is null)
        throw new Exception("O prato que você procura nao existe");

    ADSDAPIParamInserirPrato pratoResultadoAPI = new ADSDAPIParamInserirPrato { PratoNome = pratoNome };

    return pratoResultadoAPI;
}*/