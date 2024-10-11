namespace ADS.Delivery.API.V1;

public interface IADSDRepositorioPratos
{
    void InserirPrato(D_PRATO prato, D_CATEG categoria);
    void ListaPratosInserir(List<D_PRATO> pratos);
    D_PRATO? ConsultarPratoPorNome(string nomePrato);
}
