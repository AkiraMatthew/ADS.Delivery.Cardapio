
using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public class ADSDAplicacaoPratos(IADSDRepositorioPratos _pratosRepositorio, IADSDRepositorioCategorias _categoriasRepositorio) : IADSDAplicacaoPratos
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
        var pratoBD = new D_PRATO
        {
            PratoNome = prato.PratoNome,
            PratoDesc = prato.PratoDescricao,
            PratoPreco = prato.PratoPreco,
            Categoria = prato.CategoriaNome
        };

        // 3. Verificar se a categoria já existe pelo nome
        var categoriaExistente = _categoriasRepositorio.ConsultarCategoriaPorNome(prato.CategoriaNome);
        if (categoriaExistente != null)
            pratoBD.CategId = categoriaExistente.CategId;

        var categBD = new D_CATEG
        {
            CategNome = prato.CategoriaNome,
            Pratos = new List<D_PRATO> { pratoBD }
        };

        _categoriasRepositorio.InserirCategoria(categBD);
        pratoBD.CategId = categBD.CategId;

        _pratosRepositorio.InserirPrato(pratoBD, categBD);
    }
    public void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos)
    {
        throw new NotImplementedException();
    }

}
