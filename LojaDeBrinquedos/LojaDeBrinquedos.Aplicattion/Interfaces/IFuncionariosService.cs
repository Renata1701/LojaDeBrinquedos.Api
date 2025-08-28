using LojaDeBrinquedos.Domain.Entities;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;

public interface IFuncionariosService
{
    IEnumerable<Funcionarios> ObterTodosFuncionarios();
    Funcionarios? ObterFuncionariosPorId(int id);
    void AdicionarFuncionarios(Funcionarios funcionarios);
    void AtualizarFuncionarios(Funcionarios funcionarios);
    void RemoverFuncionarios(int id);
    
    // Métodos assíncronos
    Task<IEnumerable<Funcionarios>> ObterTodosAsync();
    Task<Funcionarios?> ObterPorIdAsync(int id);
    Task<Funcionarios> AdicionarAsync(Funcionarios funcionario);
    Task<Funcionarios> AtualizarAsync(Funcionarios funcionario);
    Task<bool> ExcluirAsync(int id);
}
