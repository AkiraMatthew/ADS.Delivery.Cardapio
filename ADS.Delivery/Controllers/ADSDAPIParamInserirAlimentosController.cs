using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADS.Delivery.API.V1.Controllers;


[Route("api/[controller]")]
[ApiController]
//[ApiVersion]
public class ADSDAPIParamInserirAlimentosController : ControllerBase
{
    private readonly ADSBDEFContextoBaseInMemory _context;

    public ADSDAPIParamInserirAlimentosController(ADSBDEFContextoBaseInMemory context)
    {
        _context = context;
    }

    // GET: api/ADSDAPIParamInserirAlimentos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ADSDAPIParamInserirAlimento>>> GetADSDAPIParamInserirAlimento()
    {
        return await _context.ADSDAPIParamInserirAlimento.ToListAsync();
    }

    // GET: api/ADSDAPIParamInserirAlimentos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ADSDAPIParamInserirAlimento>> GetADSDAPIParamInserirAlimento(int id)
    {
        var aDSDAPIParamInserirAlimento = await _context.ADSDAPIParamInserirAlimento.FindAsync(id);

        if (aDSDAPIParamInserirAlimento == null)
        {
            return NotFound();
        }

        return aDSDAPIParamInserirAlimento;
    }

    // PUT: api/ADSDAPIParamInserirAlimentos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutADSDAPIParamInserirAlimento(int id, ADSDAPIParamInserirAlimento aDSDAPIParamInserirAlimento)
    {
        if (id != aDSDAPIParamInserirAlimento.IdAlimento)
        {
            return BadRequest();
        }

        _context.Entry(aDSDAPIParamInserirAlimento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ADSDAPIParamInserirAlimentoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/ADSDAPIParamInserirAlimentos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ADSDAPIParamInserirAlimento>> PostADSDAPIParamInserirAlimento(ADSDAPIParamInserirAlimento aDSDAPIParamInserirAlimento)
    {
        _context.ADSDAPIParamInserirAlimento.Add(aDSDAPIParamInserirAlimento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetADSDAPIParamInserirAlimento", new { id = aDSDAPIParamInserirAlimento.IdAlimento }, aDSDAPIParamInserirAlimento);
    }

    // DELETE: api/ADSDAPIParamInserirAlimentos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteADSDAPIParamInserirAlimento(int id)
    {
        var aDSDAPIParamInserirAlimento = await _context.ADSDAPIParamInserirAlimento.FindAsync(id);
        if (aDSDAPIParamInserirAlimento == null)
        {
            return NotFound();
        }

        _context.ADSDAPIParamInserirAlimento.Remove(aDSDAPIParamInserirAlimento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ADSDAPIParamInserirAlimentoExists(int id)
    {
        return _context.ADSDAPIParamInserirAlimento.Any(e => e.IdAlimento == id);
    }
}
