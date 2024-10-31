using ADS.Delivery.API.V1;
using Moq;

namespace ADS.Delivery.API.Testes;

public class ADSAplicacaoPratosTestes
{
    private readonly ADSDAplicacaoPratos _pratosAplicacaoUnderTesting;
    private readonly Mock<IADSDRepositorioPratos> _pratosRepositorioMock = new Mock<IADSDRepositorioPratos>();
    private readonly Mock<IADSDRepositorioCategorias> _categoriasRepositorioMock = new Mock<IADSDRepositorioCategorias>();
    private readonly Mock<IADSDAplicacaoCategorias> _categoriasAplicacaoMock = new Mock<IADSDAplicacaoCategorias>();


    public ADSAplicacaoPratosTestes()
    {
        // With the .Object we get the repo interface
        _pratosAplicacaoUnderTesting = new ADSDAplicacaoPratos
            (
                _pratosRepositorioMock.Object, 
                _categoriasRepositorioMock.Object, 
                _categoriasAplicacaoMock.Object
            );

    }

    [Fact]
    public void ConsultarPratoPorNome_DeveRetornarPrato_QuandoPratoExistir() 
    {
        //Arrange -> things I'm expecting to see
        var pratoIdMock = 1;
        var pratoNomeMock = "Sushi";
        var pratoDescriçaoMock = "A comida japonesa mais difundida";
        var pratoPrecoMock = 39.99m;
        var categoriaMock = new D_CATEG
        {
            CategId = 1,
            CategNome = "japones"
        };

        var pratoDTOConsulta = new D_PRATO
        {
            PratoId = pratoIdMock,
            PratoNome = pratoNomeMock,
            PratoDesc = pratoDescriçaoMock,
            PratoPreco = pratoPrecoMock,
            Categoria = categoriaMock
        };

        _pratosRepositorioMock.Setup(p => p.ConsultarPratoPorNome(pratoNomeMock)).Returns(pratoDTOConsulta);

        //Act -> things that I'm testing in the current scenario ConsultarPratoPorNome
        var prato = _pratosAplicacaoUnderTesting.ConsultarPratoPorNome(pratoNomeMock);

        //Assert -> assert the values of the Act section
        Assert.Equal(pratoIdMock, prato.PratoId);
        Assert.Equal(pratoNomeMock, prato.PratoNome);
        Assert.Equal(pratoDescriçaoMock, prato.PratoDescricao);
        Assert.Equal(pratoPrecoMock, prato.PratoPreco);
        Assert.Equal(categoriaMock.CategId, prato.CategoriaId);
        Assert.Equal(categoriaMock.CategNome, prato.CategoriaNome);
    }
}
