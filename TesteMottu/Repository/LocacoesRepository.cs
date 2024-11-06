using Microsoft.EntityFrameworkCore;
using TesteMottu.Data;
using TesteMottu.Models;
using TesteMottu.Repository.Interface;


namespace TesteMottu.Repository;

public class LocacaoRepository : ILocacaoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LocacaoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Locacao>> GetLocacoes()
    {
        return await _dbContext.Locacoes.ToListAsync();
    }

    public async Task<Locacao> GetLocacaoById(int locacaoId)
    {
        return await _dbContext.Locacoes.FindAsync(locacaoId);
    }

    public async Task<Locacao> AddLocacao(Locacao locacao)
    {
        var locacaoDb = await _dbContext.Locacoes.AddAsync(locacao);
        await _dbContext.SaveChangesAsync();
        return locacaoDb.Entity;
    }

    public async Task<Locacao> UpdateLocacao(Locacao locacao)
    {
        var locacaoDb = await _dbContext.Locacoes.FindAsync(locacao.Id);
        if (locacaoDb == null)
        {
            return null;
        }

        locacaoDb.DataInicio = locacao.DataInicio;
        locacaoDb.DataTerminoPrevista = locacao.DataTerminoPrevista;
        locacaoDb.DataDevolucao = locacao.DataDevolucao;
        locacaoDb.Plano = locacao.Plano;

        await _dbContext.SaveChangesAsync();
        return locacaoDb;
    }

    public async Task DeleteLocacao(int locacaoId)
    {
        var locacaoDb = await _dbContext.Locacoes.FindAsync(locacaoId);
        if (locacaoDb != null)
        {
            _dbContext.Locacoes.Remove(locacaoDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
