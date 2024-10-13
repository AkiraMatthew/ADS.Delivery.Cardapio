namespace ADS.Delivery.API.V1;

public interface IADSDRepositorioPratos
{
    void InserirPrato(D_PRATO prato, List<D_CATEG> categoria);
    void ListaPratosInserir(List<D_PRATO> pratos, List<D_CATEG>);
    D_PRATO? ConsultarPratoPorNome(string nomePrato);
    D_PRATO? ConsultarPratoComCategoria(string nomePrato);
}
