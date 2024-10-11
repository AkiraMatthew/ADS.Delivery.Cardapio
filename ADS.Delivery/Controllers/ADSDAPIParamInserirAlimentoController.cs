using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1.Controllers;


[Route("api/[controller]")]
[ApiController]
//[ApiVersion]
public class ADSDAPIParamInserirAlimentosController : ControllerBase
{
    private readonly D_PRT _context;
    public ADSDAPIParamInserirAlimentosController(D_PRT context)
    {
        _context = context;
    }
    // Passo 1: Criar um http POST para inserir e validar a inserçao dos alimentos
    [HttpPost("inserir-prato")]

    // Passo 2: Criar um GET para receber os Dados inseridos através do nome do alimento, se o prato existir
    // Passo 3: Criar um PUT, verificar se o alimento existe antes de finalizar a requisiçao
    // Passo 4: Criar um DELETE que deleta através do nome passado caso o nome do prato exista
}
