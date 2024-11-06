using Microsoft.AspNetCore.Mvc;
using TesteMottu.Models;
using TesteMottu.Repository.Interface;

namespace TesteMottu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocacoesController : ControllerBase
{
    private readonly ILocacaoRepository _locacaoRepository;
    private readonly IMotoRepository _motoRepository;
    private readonly IEntregadorRepository _entregadorRepository;

    public LocacoesController(ILocacaoRepository locacaoRepository, IMotoRepository motoRepository, IEntregadorRepository entregadoresRepository)
    {
        _locacaoRepository = locacaoRepository;
        _motoRepository = motoRepository;
        _entregadorRepository = entregadoresRepository;
    }

    [HttpPost]
    public async Task<IActionResult> PostLocacao(Locacao locacao)
    {
        // Verificar se o entregador existe e se é da categoria A
        var entregador = await _entregadorRepository.GetEntregadorById(locacao.EntregadorId);
        if (entregador == null || entregador.TipoCNH != "A")
        {
            return BadRequest("Entregador não habilitado para locação.");
        }

        // Verificar se a moto existe
        var moto = await _motoRepository.GetMotoById(locacao.MotoId);
        if (moto == null)
        {
            return NotFound("Moto não encontrada.");
        }

        await _locacaoRepository.AddLocacao(locacao);
        return CreatedAtAction(nameof(GetLocacao), new { id = locacao.Id }, locacao);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacoes()
    {
        var locacoes = await _locacaoRepository.GetLocacoes();
        return Ok(locacoes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Locacao>> GetLocacao(int id)
    {
        var locacao = await _locacaoRepository.GetLocacaoById(id);
        if (locacao == null)
        {
            return NotFound();
        }
        return Ok(locacao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLocacao(int id, Locacao locacao)
    {
        if (locacao == null)
        {
            return BadRequest();
        }

        locacao.Id = id;

        var updated_locacao = await _locacaoRepository.UpdateLocacao(locacao);
        if(updated_locacao == null)
        {
            return NotFound();
        }
        return Ok(updated_locacao);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocacao(int id)
    {
        await _locacaoRepository.DeleteLocacao(id);
        return NoContent();
    }
}
