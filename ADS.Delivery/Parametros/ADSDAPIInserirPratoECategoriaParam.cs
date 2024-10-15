namespace ADS.Delivery.API.V1.Parametros;

public class ADSAPIInserirPratoECategoriaParam
{
    public ADSDAPIParamInserirPrato Prato { get; set; } = new ADSDAPIParamInserirPrato();
    public ADSDAPIParamInserirCategoria Categoria { get; set; } = new ADSDAPIParamInserirCategoria();
}

