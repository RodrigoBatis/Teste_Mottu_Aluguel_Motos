using TesteMottu.Models;

namespace TesteMottu.Repository.Interface;

public interface ILocacaoRepository
{
    Task<IEnumerable<Locacao>> GetLocacoes();
    Task<Locacao> GetLocacaoById(int locacaoId);
    Task<Locacao> AddLocacao(Locacao locacao);
    Task<Locacao> UpdateLocacao(Locacao locacao);
    Task DeleteLocacao(int locacaoId);
}
