using Microsoft.AspNetCore.Mvc;
using TesteMottu.Models;
using TesteMottu.Repository.Interface;

namespace TesteMottu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotosController : ControllerBase
{

    private readonly IMotoRepository _motoRepository;

    public MotosController(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> PostMoto(Moto moto)
    {
        await _motoRepository.AddMoto(moto);
        return CreatedAtAction(nameof(GetMoto), new { id = moto.Id }, moto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Moto>>> GetMotos()
    {
        var motos = await _motoRepository.GetMotos();
        return Ok(motos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Moto>> GetMoto(int id)
    {
        var moto = await _motoRepository.GetMotoById(id);
        if (moto == null)
        {
            return NotFound();
        }
        return Ok(moto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMoto(int id, Moto moto)
    {
        if (moto == null)
        {
            return BadRequest();
        }

        moto.Id = id;

        var updated_moto = await _motoRepository.UpdateMoto(moto);
        if(updated_moto == null)
        {
            return NotFound();
        }

        return Ok(updated_moto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMoto(int id)
    {
        await _motoRepository.DeleteMoto(id);
        return NoContent();
    }

}
