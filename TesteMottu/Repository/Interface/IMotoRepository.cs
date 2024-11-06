using TesteMottu.Models;

namespace TesteMottu.Repository.Interface
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetMotos();
        Task<Moto> GetMotoById(int motoId);
        Task<Moto> AddMoto(Moto moto);
        Task<Moto> UpdateMoto(Moto moto);
        Task DeleteMoto(int motoId);
    }
}
