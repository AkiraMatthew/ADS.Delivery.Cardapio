using ADS.Delivery.Cardapio.API.V1.Parametros;
using Microsoft.AspNetCore.Http.HttpResults;
using System.IO;

namespace ADS.Delivery.Cardapio.API.V1;

public class ADSDCategoriasService(IADSDCategoriasRepository _categoriasRepositorio) : IADSDCategoriasService
{
    public void InserirCategoria(ADSDAPIInserirCategoriaDTO categoria)
    {
        // 1. Verificar se a categoria já existe no banco de dados
        var categoriaExistente = ConsultarCategoriaPorNome(categoria.CategoriaNome);
        var categoriaBD = new D_CATEG
        {
            CategNome = categoria.CategoriaNome,
            Pratos = new List<D_PRATO>()
        };

        _categoriasRepositorio.InserirCategoria(categoriaBD);

    }
    public D_CATEG ConsultarCategoriaPorNome(string categoriaNome)
    {
        if (categoriaNome is null)
            throw new Exception("Categoria nao existente");

        return _categoriasRepositorio.ConsultarCategoriaPorNome(categoriaNome);
    }

    public List<ADSDAPIInserirCategoriaDTO> ConsultarTodasCategorias()
    {
        var categoriaBD = _categoriasRepositorio.ConsultarTodasCategorias();

        var categoriasAPI = categoriaBD.Select(categoria => 
        new ADSDAPIInserirCategoriaDTO 
        { 
            CategoriaNome = categoria.CategNome 
        }).ToList();

        return categoriasAPI;
    }

}
