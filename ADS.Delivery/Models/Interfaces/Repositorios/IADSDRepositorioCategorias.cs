namespace ADS.Delivery.API.V1;

public interface IADSDRepositorioCategorias
{
    List<D_CATEG> ConsultarTodasCategorias();
    D_CATEG ConsultarCategoriaPorNome(string nomePrato);
}
