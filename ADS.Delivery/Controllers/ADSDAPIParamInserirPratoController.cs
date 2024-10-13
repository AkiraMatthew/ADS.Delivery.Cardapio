using ADS.Delivery.API.V1.Parametros;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1.Controllers;


//[ApiVersion]
[Route("api/[controller]")]
[ApiController]
[ControllerName("cadastro-pratos")]
public class ADSDAPIParamInserirPratoController(IADSDAplicacaoPratos _adsAplicacaoDPratos) : ControllerBase
{
    // Passo 1: Criar um http POST para inserir e validar a inserçao dos alimentos
    [HttpPost("inserir-prato")]
    public IActionResult PostInserirPrato(ADSDAPIParamInserirPrato parametroPrato)
    {
        try
        {
            // Passo 1.1: Validar se os parametros que chegaram sao validos(prato e categorias)
            //Este passo se passa antes da inserçao do material
            var resultadoValidacaoDadosDeEntrada = parametroPrato.ValidarPropsDeEntradaPrato();
            if (!resultadoValidacaoDadosDeEntrada.Resultado)
                return BadRequest(resultadoValidacaoDadosDeEntrada.Mensagem);
            // Passo 1.2 desenvolver método para validar os parametros de categoria
            // Passo 1.3: Validar se o prato e a categoria que foram recebidos já existem no cardápio
            var pratoConsultado = _adsAplicacaoDPratos.ConsultarPratoPorNomeECategoria(parametroPrato.PratoNome, parametroPrato.CategoriaNome);
            if(pratoConsultado is not null)
                return BadRequest("Este prato já existe");
            // Passo 1.4: 

            return Ok();
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    // Passo 2: Criar um GET para receber os Dados inseridos através do nome do alimento, se o prato existir
    // Passo 3: Criar um PUT, verificar se o alimento existe antes de finalizar a requisiçao
    // Passo 4: Criar um DELETE que deleta através do nome passado caso o nome do prato exista
}
