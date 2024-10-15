
using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public class ADSDAplicacaoPratos(
    IADSDRepositorioPratos _pratosRepositorio, 
    IADSDRepositorioCategorias _categoriasRepositorio, 
    IADSDAplicacaoCategorias _categoriasAplicacao) 
    : IADSDAplicacaoPratos
{
    public ADSDAPIParamInserirPrato ConsultarPratoPorNome(string pratoNome)
    {
        var prato = _pratosRepositorio.ConsultarPratoPorNome(pratoNome);
        // verificar se o prato nao existe
        if(prato is null)
            return null;

        ADSDAPIParamInserirPrato pratoResultadoAPI = new ADSDAPIParamInserirPrato { PratoNome = pratoNome };

        return pratoResultadoAPI;
    }

    public ADSDAPIParamInserirPrato ConsultarPratoPorNomeECategoria(string pratoNome, string categoriaNome)
    {
        var prato = _pratosRepositorio.ConsultarPratoComCategoria(pratoNome);
        // verificar se o prato nao existe
        if (prato is null)
            return null;

        ADSDAPIParamInserirPrato pratoResultadoAPI = new ADSDAPIParamInserirPrato { PratoNome = pratoNome, CategoriaNome = categoriaNome };

        return pratoResultadoAPI;
    }

    public void InserirPratoNaCategoria(ADSDAPIParamInserirPrato prato, ADSDAPIParamInserirCategoria categoria)
    {
        var categoriaExistente = _categoriasAplicacao.ConsultarCategoriaPorNome(prato.CategoriaNome);
        if (categoriaExistente is null)
            _categoriasAplicacao.InserirCategoria(categoria);

        var pratoBD = new D_PRATO
        {
            PratoNome = prato.PratoNome,
            PratoDesc = prato.PratoDescricao,
            PratoPreco = prato.PratoPreco,
            CategId = categoriaExistente!.CategId,
            Categoria = categoriaExistente
        };

        _pratosRepositorio.InserirPrato(pratoBD, categoriaExistente);
    }
    public void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos)
    {
        throw new NotImplementedException();
    }

}
