namespace ADS.Delivery.Cardapio.API.V1;

public interface IADSDCategoriasRepository
{
    void InserirCategoria(D_CATEG categoria);
    List<string> ConsultarTodosNomesDeCategoria();
    List<D_CATEG> ConsultarTodasCategorias();
    D_CATEG ConsultarCategoriaPorNome(string nomePrato);
}
