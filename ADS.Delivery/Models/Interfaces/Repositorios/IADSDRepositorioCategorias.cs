namespace ADS.Delivery.API.V1;

public interface IADSDRepositorioCategorias
{
    List<string> ConsultarTodosNomesDeCategoria();
    List<D_CATEG> ConsultarTodasCategorias();
    D_CATEG ConsultarCategoriaPorNome(string nomePrato);
    D_CATEG InserirCategoria(D_CATEG nomeCategoria);
}
