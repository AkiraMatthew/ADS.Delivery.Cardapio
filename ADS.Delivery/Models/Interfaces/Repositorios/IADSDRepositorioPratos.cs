namespace ADS.Delivery.API.V1;

public interface IADSDRepositorioPratos
{
    void InserirPrato(D_PRATO prato, D_CATEG categoria);
    void ListaPratosInserir(List<D_PRATO> pratos, List<D_CATEG> categorias);
    D_PRATO ConsultarPratoPorNome(string nomePrato);
    D_PRATO ConsultarPratoComCategoria(string nomePrato);
    void InserirPrato(D_PRATO pratoBD);
}
