using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto> ObterPorIdAsync(int id);
    Task<Produto> AdicionarAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<bool> ExcluirAsync(int id);
}
