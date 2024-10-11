namespace ADS.Delivery.API.V1;

public interface IADSDAplicacaoCategorias
{
    ADSARepositorioCategorias ConsultarCategoriaPorNome(string categoria);
    List<ADSDAPIParamInserirCategoria> ConsultarTodasCategorias();
}
