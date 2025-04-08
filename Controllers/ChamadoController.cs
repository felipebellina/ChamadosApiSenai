using ChamdosAPI.Data;
using ChamdosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChamadosAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ChamadoController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public ChamadoController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var chamados = _appDbContext.Chamados;
        return chamados == null ? NotFound() : Ok(chamados);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var chamado = await _appDbContext.Chamados.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        return chamado == null ? NotFound() : Ok(chamado);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> PostAsync([FromBody]Chamado chamado)
    {
        _appDbContext.Chamados.Add(chamado);
        await _appDbContext.SaveChangesAsync();
        
        return Ok(chamado);
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> PutAsync([FromBody]Chamado model, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var chamado = await _appDbContext.Chamados.FirstOrDefaultAsync(x => x.Id == id);

        if (chamado == null)
            return NotFound();

        try
        {
            chamado.Titulo = model.Titulo;
            chamado.Descricao = model.Descricao;
            chamado.Status = model.Status;
            chamado.DataFechamento = model.DataFechamento;

            _appDbContext.Chamados.Update(chamado);
            await _appDbContext.SaveChangesAsync();
            return Ok(chamado);
        }
        catch (Exception message)
        {
            return BadRequest();
        }
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var chamado = await _appDbContext.Chamados.FirstOrDefaultAsync(x => x.Id == id);

        try
        {
            _appDbContext.Chamados.Remove(chamado);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }
        catch (Exception message)
        {
            return BadRequest();
        }
    }
}
