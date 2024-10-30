using ADS.Delivery.API.V1.Parametros;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ADS.Delivery.API.V1.Controllers;


//[ApiVersion]
[Route("api/[controller]")]
[ApiController]
[ControllerName("cadastro-pratos")]
public class ADSDAPIPratosController(
    IADSDAplicacaoPratos _adsAplicacaoDPratos,
    IADSDAplicacaoCategorias _adsAplicacaoDCategorias)
    : ControllerBase
{
    // Passo 1: Criar um http POST para inserir e validar a inserçao dos alimentos
    [HttpPost]
    public IActionResult PostInserirPrato([FromBody] ADSDAPIParamInserirPrato prato, [FromQuery] string categoriaNome)
    {
        try
        {
            // Passo 1: Validar os pratos
            var resultadoValidacaoDadosDeEntradaPrato = prato.ValidarPropsDeEntradaPrato();
            if (!resultadoValidacaoDadosDeEntradaPrato.Resultado)
                return BadRequest(resultadoValidacaoDadosDeEntradaPrato.Mensagem);

            /*var resultadoValidacaoDadosDeEntradaCategoria = prato.ValidarPropsDeEntradaCategoria();
            if (!resultadoValidacaoDadosDeEntradaCategoria.Resultado)
                return BadRequest(resultadoValidacaoDadosDeEntradaCategoria.Mensagem);*/

            // Passo 2: Validar se o prato e a categoria que foram recebidos já existem no cardápio
            //var pratoConsultado = _adsAplicacaoDPratos.ConsultarPratoPorNomeECategoria(prato.Prato.PratoNome, prato.Categoria.CategoriaNome);
            //if(pratoConsultado is not null)
            // return BadRequest("Este prato já existe");

            // Passo 3: Se a categoria nao existir, criar uma nova

            // Passo 4: Inserir prato dentro da categoria no cardápio
            _adsAplicacaoDPratos.InserirPratoNaCategoria(prato, categoriaNome);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Passo 2: Criar um GET para receber os Dados inseridos através do nome do alimento, se o prato existir
    [HttpGet]
    public IActionResult GetTodasCategorias()
    {
        try
        {
            var categoriasAPI = _adsAplicacaoDCategorias.ConsultarTodasCategorias();

            return Ok(categoriasAPI);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //[HttpGet("consultar-prato/{pratoNome}")]
    //[HttpGet("consultar-categoria/{categoriaNome}")]
    // Passo 3: Criar um PUT, verificar se o alimento existe antes de finalizar a requisiçao
    // Passo 4: Criar um DELETE que deleta através do nome passado caso o nome do prato exista
}
