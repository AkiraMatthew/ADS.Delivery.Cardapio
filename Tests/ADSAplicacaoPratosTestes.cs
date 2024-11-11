using ADS.Delivery.Cardapio.API.V1;
using ADS.Delivery.Cardapio.API.V1.Parametros;
using Moq;

namespace ADS.Delivery.API.Testes;

public class ADSPratosServiceTestes
{
    private readonly ADSDPratosService _pratosAplicacaoUnderTesting;
    private readonly Mock<IADSDPratosRepository> _pratosRepositorioMock = new Mock<IADSDPratosRepository>();
    private readonly Mock<IADSDCategoriasRepository> _categoriasRepositorioMock = new Mock<IADSDCategoriasRepository>();
    private readonly Mock<IADSDCategoriasService> _categoriasAplicacaoMock = new Mock<IADSDCategoriasService>();


    public ADSPratosServiceTestes()
    {
        // With the .Object we get the repo interface
        _pratosAplicacaoUnderTesting = new ADSDPratosService
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
        var pratoIdMockBD = 1;
        var pratoNomeMockBD = "sushi";
        var pratoDescriçaoMockBD = "A comida japonesa mais difundida";
        var pratoPrecoMockBD = 39.99m;
        var categoriaMockBD = new D_CATEG
        {
            CategId = 1,
            CategNome = "japones"
        };

        var pratoDTOConsulta = new ADSDAPIParamConsultarPrato
        {
            PratoId = pratoIdMockBD,
            PratoNome = pratoNomeMockBD,
            PratoDescricao = pratoDescriçaoMockBD,
            PratoPreco = pratoPrecoMockBD,
            CategoriaId = categoriaMockBD.CategId,
            CategoriaNome = categoriaMockBD.CategNome
        };

        _pratosRepositorioMock.Setup(p => p.ConsultarPratoPorNome(pratoNomeMockBD)).Returns(pratoDTOConsulta);

        //Act -> things that I'm testing in the current scenario ConsultarPratoPorNome
        var prato = _pratosAplicacaoUnderTesting.ConsultarPratoPorNome("SusHi".ToLower());

        //Assert -> assert the values of the Act section
        Assert.Equal(pratoIdMockBD, prato.PratoId);
        Assert.Equal(pratoNomeMockBD, prato.PratoNome);
        Assert.Equal(pratoDescriçaoMockBD, prato.PratoDescricao);
        Assert.Equal(pratoPrecoMockBD, prato.PratoPreco);
        Assert.Equal(categoriaMockBD.CategId, prato.CategoriaId);
        Assert.Equal(categoriaMockBD.CategNome, prato.CategoriaNome);
    }

    [Fact]
    public void ConsultarPratoPorNome_DeveRetornarErro_QuandoPratoNaoExistir() 
    { 
        
    }

    [Fact]
    public void InserirPratoNaCategoria_DeveRetornarObjetoPrato() 
    {
        //Arrange
        //Act
        //Assert
    }

    [Fact]
    public void AtualizarPratoPorNome_DeveAtualizarUmPrato_QuandoExistir() 
    { 

    }
}
