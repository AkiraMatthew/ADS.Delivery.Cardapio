
namespace ADS.Delivery.API.V1;

public class ADSDRepositorioCategorias(ADSBDEFContextoBaseInMemory _contextoADS)
    : IADSDRepositorioCategorias
{
    public void InserirCategoria(D_CATEG categoria)
    {
        var categoriaExistente = _contextoADS.Categorias
            .FirstOrDefault(c => c.CategNome == categoria.CategNome);

        if (categoriaExistente is not null)
            throw new Exception($"A categoria {categoria.CategNome} já existe no Banco de Dados");

        _contextoADS.Categorias.Add(categoria);
        _contextoADS.SaveChanges();
    }

    public List<D_CATEG> ConsultarTodasCategorias()
    {
        var listaDeCategorias = _contextoADS.Categorias.ToList();

        return listaDeCategorias;
    }

    public List<string> ConsultarTodosNomesDeCategoria()
    {
        var listaDeCategoriasPorNome = _contextoADS.Categorias.Select(c => c.CategNome).ToList();

        return listaDeCategoriasPorNome;
    }

    D_CATEG IADSDRepositorioCategorias.ConsultarCategoriaPorNome(string nomeCategoria)
    {
        var categoria = _contextoADS.Categorias.FirstOrDefault(c => c.CategNome == nomeCategoria);

        Console.WriteLine(categoria);

        return categoria;
    }
}
