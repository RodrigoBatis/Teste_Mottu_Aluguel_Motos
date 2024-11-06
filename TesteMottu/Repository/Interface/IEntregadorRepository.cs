using TesteMottu.Models;

namespace TesteMottu.Repository.Interface
{
    public interface IEntregadorRepository
    {
        Task<IEnumerable<Entregador>> GetEntregadores();
        Task<Entregador> GetEntregadorById(int entregadorId);
        Task<Entregador> AddEntregador(Entregador entregador);
        Task<Entregador> UpdateEntregador(Entregador entregador);
        Task DeleteEntregador(int entregadorId);
    }
}
