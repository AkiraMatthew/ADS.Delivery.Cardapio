
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
        var categoriaExistente = _categoriasRepositorio.ConsultarCategoriaPorNome(prato.CategoriaNome);
        //D_CATEG categBD;
        if (categoriaExistente is null)
            throw new Exception("Categoria nao encontrada");
            //categBD = categoriaExistente;

        //categBD = new D_CATEG
        //{
        //    CategNome = prato.CategoriaNome,
        //    Pratos = new List<D_PRATO>()
        //};

        //_categoriasRepositorio.InserirCategoria(categBD);

        var pratoBD = new D_PRATO
        {
            PratoNome = prato.PratoNome,
            PratoDesc = prato.PratoDescricao,
            PratoPreco = prato.PratoPreco,
            CategId = categoriaExistente!.CategId,
            Categoria = categoriaExistente
        };

        //categBD.Pratos.Add(pratoBD);

        _pratosRepositorio.InserirPrato(pratoBD, categoriaExistente);
    }
    public void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos)
    {
        throw new NotImplementedException();
    }

}
