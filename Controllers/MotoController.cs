// MotoController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MotoController : ControllerBase
{
    private readonly MotoService _motoService;

    public MotoController(MotoService motoService)
    {
        _motoService = motoService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMoto([FromBody] MotoDTO motoDto)
    {
        var result = await _motoService.AddMotoAsync(motoDto);
        return CreatedAtAction(nameof(GetMotoById), new { id = result.Identificador }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMotoById(int id)
    {
        var moto = await _motoService.GetByIdAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        return Ok(moto);
    }

    // Métodos para Update, Delete e GetByPlaca
}
