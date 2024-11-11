
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.Cardapio.API.V1;

public class ADSDPratosRepository(ADSBDEFContextoBaseInMemory _contextoADS) 
    : IADSDPratosRepository
{
    public D_PRATO ConsultarPratoComCategoria(string nomePrato)
    {
        return _contextoADS.Pratos
            .Include(prato => prato.Categoria)
            .FirstOrDefault(prato => prato.PratoNome == nomePrato)
            ?? throw new Exception("O prato ou a categoria nao existem"); ;
    }

    public D_PRATO ConsultarPratoPorNome(string nomePrato)
    {
        var prato = _contextoADS.Pratos.FirstOrDefault(p => p.PratoNome == nomePrato);

        if (prato is null)
            throw new Exception("O prato nao existe.");

        return prato;
    }

    public void InserirPrato(D_PRATO prato, D_CATEG categoria)
    {
        var categoriaExistente = _contextoADS.Categorias
            .FirstOrDefault(c => c.CategNome == categoria.CategNome);

        if (categoriaExistente is null)
        {
            _contextoADS.Categorias.Add(categoria);
            prato.CategId = categoria.CategId;
        } 
        else
        {
            prato.CategId = categoriaExistente.CategId;
            prato.Categoria = categoriaExistente;
        }
        
        _contextoADS.Pratos.Add(prato);
        _contextoADS.SaveChanges();
    }

    public void ListaPratosInserir(List<D_PRATO> pratos, List<D_CATEG> categorias)
    {
        throw new NotImplementedException();
    }
}
