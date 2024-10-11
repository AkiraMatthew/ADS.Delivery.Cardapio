namespace ADS.Delivery.API.V1;

public interface IADSDAplicacaoPratos
{
    void InserirPratoNaCategoria(ADSDAPIParamInserirPrato prato, ADSDAPIParamInserirCategoria categoria);
    void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos);
}
