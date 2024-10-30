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
        var pratoNome = "Sushi";

        //Act -> things that I'm testing in the current scenario ConsultarPratoPorNome
        var prato = _pratosAplicacaoUnderTesting.ConsultarPratoPorNome(pratoNome);

        //Assert -> assert the values of the Act section
        Assert.Equal(pratoNome, prato.PratoNome);
    }
}
