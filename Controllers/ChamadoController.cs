using ChamdosAPI.Data;
using ChamdosAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody]Chamado chamado)
    {
        _appDbContext.Chamados.Add(chamado);
        await _appDbContext.SaveChangesAsync();
        
        return Ok(chamado);
    }
}
