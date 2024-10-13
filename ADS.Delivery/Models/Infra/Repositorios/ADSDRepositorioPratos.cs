
namespace ADS.Delivery.API.V1;

public class ADSDRepositorioPratos : IADSDRepositorioPratos
{
    private readonly ADSBDEFContextoBaseInMemory _contextoADS;

    public ADSDRepositorioPratos(ADSBDEFContextoBaseInMemory contextoADS)
    {
        _contextoADS = contextoADS;
    }

    public D_PRATO? ConsultarPratoPorNome(string nomePrato)
    {
        var prato = _contextoADS.Pratos.FirstOrDefault(p => p.PratoNome == nomePrato);

        if (prato == null)
            throw new Exception("O prato nao existe.");

        return prato;
    }

    public void InserirPrato(D_PRATO prato, List<D_CATEG> categorias)
    {
        _contextoADS.Add(prato);

        if (categorias != null && categorias.Count > 0)
            for (int i = 0; i < categorias.Count; i++)
                _contextoADS.Add(categorias[i]);

        _contextoADS.SaveChanges();
    }

    public void ListaPratosInserir(List<D_PRATO> pratos, List<D_CATEG> categorias)
    {
        for (int i = 0; i < pratos.Count; i++)
            _contextoADS.Add(pratos);

        if (categorias != null && categorias.Count > 0)
            for (int i = 0; i < categorias.Count; i++)
                _contextoADS.Add(categorias[i]);

        _contextoADS.SaveChanges();
    }
}
