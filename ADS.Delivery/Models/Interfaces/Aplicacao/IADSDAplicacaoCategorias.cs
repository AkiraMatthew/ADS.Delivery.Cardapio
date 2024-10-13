using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public interface IADSDAplicacaoCategorias
{
    ADSDRepositorioCategorias ConsultarCategoriaPorNome(string categoria);
    List<ADSDAPIParamInserirCategoria> ConsultarTodasCategorias();
}
