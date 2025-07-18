using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class FuncionariosService
{
    private readonly List<Funcionarios> _funcionarios = new();

    public List<Funcionarios> Listar() => _funcionarios;

    public void Adicionar(Funcionarios funcionario) => _funcionarios.Add(funcionario);
}
