using ADS.Delivery.Cardapio.API.V1.Parametros;

namespace ADS.Delivery.Cardapio.API.V1;

public interface IADSDPratosService
{
    void InserirPratoNaCategoria(ADSDAPIInserirPratoDTO prato, string categoriaNome);
    void InserirListaPratosNaCategoria(List<ADSDAPIInserirPratoDTO> pratos);
    ADSDAPIParamConsultarPrato ConsultarPratoPorNome(string pratoNome);
    //ADSDAPIParamInserirPrato ConsultarPratoPorNomeECategoria(string pratoNome, string categoriaNome);
}
// eu estava verificando