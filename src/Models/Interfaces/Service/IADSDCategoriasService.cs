using ADS.Delivery.Cardapio.API.V1.Parametros;

namespace ADS.Delivery.Cardapio.API.V1;

public interface IADSDCategoriasService
{
    void InserirCategoria (ADSDAPIInserirCategoriaDTO categoria);
    D_CATEG ConsultarCategoriaPorNome(string categoriaNome);
    List<ADSDAPIInserirCategoriaDTO> ConsultarTodasCategorias();
}
