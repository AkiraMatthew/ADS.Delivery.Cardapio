using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public interface IADSDAplicacaoCategorias
{
    void InserirCategoria (ADSDAPIParamInserirCategoria categoria);
    D_CATEG ConsultarCategoriaPorNome(string categoriaNome);
    List<ADSDAPIParamInserirCategoria> ConsultarTodasCategorias();
}
