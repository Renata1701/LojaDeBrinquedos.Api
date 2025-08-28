using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using static LojaDeBrinquedos.API.Services.PedidoService;

namespace LojaDeBrinquedos.API.Services;

public class FuncionariosService : IFuncionariosService
{
    public readonly string _connectionString;

    public FuncionariosService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    private readonly List<Funcionarios> _funcionarios;

    public FuncionariosService()
    {
        _funcionarios = new List<Funcionarios>
        {
            new Funcionarios(1, "Maria Souza", "Gerente", "maria@loja.com", "12345678900")
        };
    }

    public IEnumerable<Funcionarios> ObterTodosFuncionarios()
    {
        return _funcionarios;
    }

    public Funcionarios ObterFuncionarioPorId(int id)
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
     
    }

    public void RemoverFuncionario(int id)
    {
        var funcionario = ObterFuncionarioPorId(id);
        if (funcionario == null) throw new InvalidOperationException("Funcionário não encontrado.");

    }

    public Task<IEnumerable<Funcionarios>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Funcionarios> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Funcionarios> AdicionarAsync(Funcionarios funcionario)
    {
        throw new NotImplementedException();
    }

    public Task<Funcionarios> AtualizarAsync(Funcionarios funcionario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }

    IFuncionariosService IFuncionariosService.ObterFuncionariosPorId(int id)
    {
        throw new NotImplementedException();
    }

    void IFuncionariosService.AdicionarFuncionarios(Funcionarios funcionarios)
    {
        throw new NotImplementedException();
    }

    void IFuncionariosService.AtualizarFuncionarios(Funcionarios funcionarios)
    {
        throw new NotImplementedException();
    }

    void IFuncionariosService.RemoverFuncionarios(int id)
    {
        throw new NotImplementedException();
    }
}