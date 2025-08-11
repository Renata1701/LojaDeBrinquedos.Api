using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface IFuncionarioService
{
    Task<IEnumerable<Funcionarios>> ObterTodosAsync();
    Task<Funcionarios> ObterPorIdAsync(int id);
    Task<Funcionarios> AdicionarAsync(Funcionarios funcionario);
    Task<Funcionarios> AtualizarAsync(Funcionarios funcionario);
    Task<bool> ExcluirAsync(int id);
}
