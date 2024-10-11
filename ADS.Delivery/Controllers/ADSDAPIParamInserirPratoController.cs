using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1.Controllers;


[Route("api/[controller]")]
[ApiController]
//[ApiVersion]
public class ADSDAPIParamInserirPratoController : ControllerBase
{
    private readonly D_PRATO _context;
    public ADSDAPIParamInserirPratoController(D_PRATO context)
    {
        _context = context;
    }
    // Passo 1: Criar um http POST para inserir e validar a inserçao dos alimentos
    [HttpPost("inserir-prato")]
    public IActionResult PostInserirPrato(ADSDAPIParamInserirPrato parametroPrato, ADSDAPIParamInserirCategoria parametroCategoria)
    {
        //Passo 1.1: Validar se os parametros que chegaram sao validos(prato e categorias)
        //Passo 1.2: Validar se o prato e a categorias já existem no cardápio
        //Passo 1.3: 
    }

    // Passo 2: Criar um GET para receber os Dados inseridos através do nome do alimento, se o prato existir
    // Passo 3: Criar um PUT, verificar se o alimento existe antes de finalizar a requisiçao
    // Passo 4: Criar um DELETE que deleta através do nome passado caso o nome do prato exista
}
