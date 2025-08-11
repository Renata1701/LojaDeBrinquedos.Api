using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> ObterTodosAsync();
    Task<Cliente> ObterPorIdAsync(int id);
    Task<Cliente> AdicionarAsync(Cliente cliente);
    Task<Cliente> AtualizarAsync(Cliente cliente);
    Task<bool> ExcluirAsync(int id);
}
