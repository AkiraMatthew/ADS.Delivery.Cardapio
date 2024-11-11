
using ADS.Delivery.Cardapio.API.V1.Parametros;

namespace ADS.Delivery.Cardapio.API.V1;

public class ADSDPratosService(
    IADSDPratosRepository _pratosRepositorio,
    IADSDCategoriasRepository _categoriasRepositorio,
    IADSDCategoriasService _categoriasAplicacao) 
    : IADSDPratosService
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

    public void InserirPratoNaCategoria(ADSDAPIInserirPratoDTO prato, string categoriaNome)
    {
        var categoriaExistente = _categoriasRepositorio.ConsultarCategoriaPorNome(categoriaNome);
        if (categoriaExistente is null)
        {
            var categoriaBD = new ADSDAPIInserirCategoriaDTO
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
    public void InserirListaPratosNaCategoria(List<ADSDAPIInserirPratoDTO> pratos)
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