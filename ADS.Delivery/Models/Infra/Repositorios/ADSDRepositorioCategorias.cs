
namespace ADS.Delivery.API.V1;

public class ADSDRepositorioCategorias(ADSBDEFContextoBaseInMemory _contextoADS): IADSDRepositorioCategorias
{
    public List<D_CATEG> ConsultarTodasCategorias()
    {
        var listaDeCategorias = _contextoADS.Categorias.ToList();

        return listaDeCategorias;
    }

    public List<string> ConsultarTodasCategoriasNome()
    {
        var listaDeCategoriasPorNome = _contextoADS.Categorias.Select(c => c.CategNome).ToList();

        return listaDeCategoriasPorNome;
    }

    D_CATEG IADSDRepositorioCategorias.ConsultarCategoriaPorNome(string nomeCategoria)
    {
        var categoria = _contextoADS.Categorias.FirstOrDefault(c => c.CategNome == nomeCategoria);

        if (categoria == null)
            throw new Exception("A categoria nao existe.");

        return categoria;
    }
}
