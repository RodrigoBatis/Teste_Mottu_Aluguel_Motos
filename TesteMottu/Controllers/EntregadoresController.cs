using Microsoft.AspNetCore.Mvc;
using TesteMottu.Models;
using TesteMottu.Repository.Interface;

namespace TesteMottu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregadoresController : ControllerBase
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadoresController(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostEntregador(Entregador entregador)
        { 
            await _entregadorRepository.AddEntregador(entregador);
            return CreatedAtAction(nameof(GetEntregador), new { id = entregador.Id }, entregador);
        }

        [HttpPost("{id}/cnh")]
        public async Task<IActionResult> UploadCNH(int id, IFormFile cnhFile)
        {
            if (cnhFile == null || (cnhFile.ContentType != "image/png" && cnhFile.ContentType != "image/bmp"))
            {
                return BadRequest("Formato de arquivo inválido. Use PNG ou BMP.");
            }

            var path = Path.Combine("path/to/storage", $"{id}_CNH.{Path.GetExtension(cnhFile.FileName)}");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await cnhFile.CopyToAsync(stream);
            }

            return Ok("CNH atualizada com sucesso.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entregador>>> GetEntregadores()
        {
            var entregadores = await _entregadorRepository.GetEntregadores();
            return Ok(entregadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entregador>> GetEntregador(int id)
        {
            var entregador = await _entregadorRepository.GetEntregadorById(id);
            if (entregador == null)
            {
                return NotFound();
            }
            return Ok(entregador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntregador(int id, [FromBody] Entregador entregador)
        {
            if (entregador == null)
            {
                return BadRequest();
            }
            entregador.Id = id;

            var updated_entregador = await _entregadorRepository.UpdateEntregador(entregador);
            if(updated_entregador == null)
            {
                return NotFound();
            }
            return Ok(updated_entregador);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntregador(int id)
        {
            await _entregadorRepository.DeleteEntregador(id);
            return NoContent();
        }
    }
}
