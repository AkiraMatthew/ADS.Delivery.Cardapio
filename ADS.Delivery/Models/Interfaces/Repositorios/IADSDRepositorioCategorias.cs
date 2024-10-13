namespace ADS.Delivery.API.V1;

public interface IADSDRepositorioCategorias
{
    void InserirCategoria(D_CATEG categoria);
    List<string> ConsultarTodosNomesDeCategoria();
    List<D_CATEG> ConsultarTodasCategorias();
    D_CATEG ConsultarCategoriaPorNome(string nomePrato);
}
