
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1;

public class ADSDRepositorioPratos(ADSBDEFContextoBaseInMemory _contextoADS) 
    : IADSDRepositorioPratos
{
    public D_PRATO ConsultarPratoComCategoria(string nomePrato)
    {
        var pratoComCategoria = _contextoADS.Pratos
            .Include(prato => prato.Categoria)
            .FirstOrDefault(prato => prato.PratoNome == nomePrato);

        if (pratoComCategoria is null)
            throw new Exception("O prato ou a categoria nao existem");

        return pratoComCategoria;
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
        //.1 Verificar se a categoria ja existe no BD
        var categoriaExistente = _contextoADS.Categorias
            .FirstOrDefault(c => c.CategNome == categoria.CategNome);

        //.2 Se nao existir, cria a categoria e associa o prato à essa categoria
        if (categoriaExistente is null)
        {
            _contextoADS.Categorias.Add(categoria);
            _contextoADS.SaveChanges();
            prato.CategId = categoria.CategId;
        } 
        else
        prato.CategId = categoriaExistente.CategId;

       //.3 Adicionar o prato ao contexto com a categoria já associada
       _contextoADS.Pratos.Add(prato);
        _contextoADS.SaveChanges();
    }

    public void ListaPratosInserir(List<D_PRATO> pratos, List<D_CATEG> categorias)
    {
        throw new NotImplementedException();
    }
}
