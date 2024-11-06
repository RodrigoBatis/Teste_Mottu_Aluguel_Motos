using Microsoft.EntityFrameworkCore;
using TesteMottu.Data;
using TesteMottu.Models;
using TesteMottu.Repository.Interface;

namespace TesteMottu.Repository
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EntregadorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Entregador>> GetEntregadores()
        {
            return await _dbContext.Entregadores.ToListAsync();
        }

        public async Task<Entregador> GetEntregadorById(int entregadorId)
        {
            return await _dbContext.Entregadores.FindAsync(entregadorId);
        }

        public async Task<Entregador> AddEntregador(Entregador entregador)
        {
            // Verificar se o CNPJ já está cadastrado
            var existingCnpj = await _dbContext.Entregadores
                .FirstOrDefaultAsync(e => e.Cnpj == entregador.Cnpj);
            if (existingCnpj != null)
            {
                throw new Exception("CNPJ já cadastrado.");
            }

            // Verificar se o número da CNH já está cadastrado
            var existingCNH = await _dbContext.Entregadores
                .FirstOrDefaultAsync(e => e.NumeroCNH == entregador.NumeroCNH);
            if (existingCNH != null)
            {
                throw new Exception("Número da CNH já cadastrado.");
            }

            // Adicionar o novo entregador
            var entregadorDb = await _dbContext.Entregadores.AddAsync(entregador);
            await _dbContext.SaveChangesAsync();

            return entregadorDb.Entity;
        }

        public async Task<Entregador> UpdateEntregador(Entregador entregador)
        {
            var entregadorDb = await _dbContext.Entregadores.FindAsync(entregador.Id);

            if (entregadorDb == null)
            {
                return null; 
            }

            entregadorDb.Nome = entregador.Nome;
            entregadorDb.Cnpj = entregador.Cnpj;
            entregadorDb.DataNascimento = entregador.DataNascimento;
            entregadorDb.NumeroCNH = entregador.NumeroCNH;
            entregadorDb.TipoCNH = entregador.TipoCNH;

            await _dbContext.SaveChangesAsync();
            return entregadorDb;
        }

        public async Task DeleteEntregador(int entregadorId)
        {
            var entregadorDb = await _dbContext.Entregadores.FindAsync(entregadorId);
            if (entregadorDb != null)
            {
                _dbContext.Entregadores.Remove(entregadorDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
