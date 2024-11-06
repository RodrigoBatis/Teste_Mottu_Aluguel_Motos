using TesteMottu.Data;
using TesteMottu.Models;
using TesteMottu.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace TesteMottu.Repository;


public class MotoRepository : IMotoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MotoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Moto>> GetMotos()
    {
        return await _dbContext.Motos.ToListAsync();
    }

    public async Task<Moto> GetMotoById(int motoId)
    {
        return await _dbContext.Motos.FindAsync(motoId);
    }

    public async Task<Moto> AddMoto(Moto moto)
    {
        var motoDb = await _dbContext.Motos.AddAsync(moto);
        await _dbContext.SaveChangesAsync();
        return motoDb.Entity;
    }

    public async Task<Moto> UpdateMoto(Moto moto)
    {
        var motoDb = await _dbContext.Motos.FindAsync(moto.Id);
        if (motoDb == null)
        {
            return null;
        }

        motoDb.Placa = moto.Placa;
        motoDb.Modelo = moto.Modelo;
        motoDb.Ano = moto.Ano;

        await _dbContext.SaveChangesAsync();
        return motoDb;
    }

    public async Task DeleteMoto(int motoId)
    {
        var motoDb = await _dbContext.Motos.FindAsync(motoId);
        if (motoDb != null)
        {
            _dbContext.Motos.Remove(motoDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
