
using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public class ADSDAplicacaoPratos(IADSDRepositorioPratos _pratosRepositorio) : IADSDAplicacaoPratos
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

    public void InserirPratoNaCategoria(ADSDAPIParamInserirPrato prato, ADSDAPIParamInserirCategoria categoria, D_PRATO pratoBD, D_CATEG categoriaBD)
    {
        pratoBD.PratoNome = prato.PratoNome;
        pratoBD.PratoDesc = prato.PratoDescricao;
        pratoBD.PratoPreco = prato.PratoPreco;
        categoriaBD.CategNome = categoria.CategoriaNome;

        _pratosRepositorio.InserirPrato(pratoBD, categoriaBD);
    }
    public void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos)
    {
        throw new NotImplementedException();
    }

}
