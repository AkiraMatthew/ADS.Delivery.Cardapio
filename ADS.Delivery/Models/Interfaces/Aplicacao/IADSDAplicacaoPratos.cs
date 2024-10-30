using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.V1;

public interface IADSDAplicacaoPratos
{
    void InserirPratoNaCategoria(ADSDAPIParamInserirPrato prato, string categoriaNome);
    void InserirListaPratosNaCategoria(List<ADSDAPIParamInserirPrato> pratos);
    ADSDAPIParamConsultarPrato ConsultarPratoPorNome(string pratoNome);
    ADSDAPIParamInserirPrato ConsultarPratoPorNomeECategoria(string pratoNome, string categoriaNome);
}
// eu estava verificando