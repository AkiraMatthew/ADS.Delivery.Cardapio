using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public interface IADSDAplicacaoPratos
{
    void InserirPratoNaCategoria(ADSDAPIParamInserirPrato prato, ADSDAPIParamInserirCategoria categoria);
    void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos);
    ADSDAPIParamInserirPrato ConsultarPratoPorNome(string pratoNome);
    ADSDAPIParamInserirPrato ConsultarPratoPorNomeECategoria(string pratoNome, string categoriaNome);
}
// eu estava verificando