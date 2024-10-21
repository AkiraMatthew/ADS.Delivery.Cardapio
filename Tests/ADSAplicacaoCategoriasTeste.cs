using Xunit;
using Moq;
using ADS.Delivery.API.V1;
using ADS.Delivery.API.V1.Parametros;

namespace ADS.Delivery.API.Testes;

public class ADSAplicacaoCategoriasTestes
{
    private readonly  ADSDAplicacaoCategorias _aplicacaoCategoria;

    private readonly Mock<IADSDRepositorioCategorias> _categoriasRepositorioMock 
        = new Mock<IADSDRepositorioCategorias>();

    public ADSAplicacaoCategoriasTestes()
    {
        _aplicacaoCategoria 
            = new ADSDAplicacaoCategorias(_categoriasRepositorioMock.Object);
    }

    [Fact]
    public void ConsultarTodasCategorias_DeveRetornarTodasCategoria_QuandoExistir()
    {
        //Arrange
        var categoriasBD = new List<D_CATEG>
        {
            new D_CATEG
            {
                CategId = 1,
                CategNome = "Japonesa",
                Pratos = new List<D_PRATO>
                {
                    new D_PRATO{Categoria}
                },
            }
        };
        //Act
        //Assert
    }
}
