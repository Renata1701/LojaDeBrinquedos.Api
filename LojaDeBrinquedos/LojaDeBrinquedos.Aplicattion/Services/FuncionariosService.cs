using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class FuncionariosService : IFuncionariosService
{
    private readonly string _connectionString;
    private readonly List<Funcionarios> _funcionarios;

    public FuncionariosService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL") ?? string.Empty;
        _funcionarios = new List<Funcionarios>
        {
            new Funcionarios(1, "Maria Souza", "Gerente", 5000.00m, DateTime.Now)
        };
    }

    public IEnumerable<Funcionarios> ObterTodosFuncionarios()
    {
        return _funcionarios;
    }

    public Funcionarios? ObterFuncionarioPorId(int id)
    {
        return _funcionarios.FirstOrDefault(f => f.Id == id);
    }

    public void AtualizarFuncionario(Funcionarios funcionario)
    {
        if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
        var existente = ObterFuncionarioPorId(funcionario.Id);
        if (existente == null) throw new InvalidOperationException("Funcionário não encontrado.");

        existente.Nome = funcionario.Nome;
        existente.Cargo = funcionario.Cargo;
        existente.Salario = funcionario.Salario;
    }

    public void RemoverFuncionario(int id)
    {
        var funcionario = ObterFuncionarioPorId(id);
        if (funcionario == null) throw new InvalidOperationException("Funcionário não encontrado.");
        
        _funcionarios.Remove(funcionario);
    }

    public Task<IEnumerable<Funcionarios>> ObterTodosAsync()
    {
        return Task.FromResult(_funcionarios.AsEnumerable());
    }

    public Task<Funcionarios?> ObterPorIdAsync(int id)
    {
        return Task.FromResult(_funcionarios.FirstOrDefault(f => f.Id == id));
    }

    public Task<Funcionarios> AdicionarAsync(Funcionarios funcionario)
    {
        if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
        
        funcionario.Id = _funcionarios.Count > 0 ? _funcionarios.Max(f => f.Id) + 1 : 1;
        _funcionarios.Add(funcionario);
        
        return Task.FromResult(funcionario);
    }

    public Task<Funcionarios> AtualizarAsync(Funcionarios funcionario)
    {
        if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
        
        var existente = _funcionarios.FirstOrDefault(f => f.Id == funcionario.Id);
        if (existente == null) throw new InvalidOperationException("Funcionário não encontrado.");

        existente.Nome = funcionario.Nome;
        existente.Cargo = funcionario.Cargo;
        existente.Salario = funcionario.Salario;
        existente.DataContratacao = funcionario.DataContratacao;
        
        return Task.FromResult(existente);
    }

    public Task<bool> ExcluirAsync(int id)
    {
        var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario == null) return Task.FromResult(false);
        
        return Task.FromResult(_funcionarios.Remove(funcionario));
    }

    public Funcionarios? ObterFuncionariosPorId(int id)
    {
        return ObterFuncionarioPorId(id);
    }

    public void AdicionarFuncionarios(Funcionarios funcionarios)
    {
        if (funcionarios == null) throw new ArgumentNullException(nameof(funcionarios));
        
        funcionarios.Id = _funcionarios.Count > 0 ? _funcionarios.Max(f => f.Id) + 1 : 1;
        _funcionarios.Add(funcionarios);
    }

    public void AtualizarFuncionarios(Funcionarios funcionarios)
    {
        AtualizarFuncionario(funcionarios);
    }

    public void RemoverFuncionarios(int id)
    {
        RemoverFuncionario(id);
    }
}