using LojaDeBrinquedos.Domain.Entities;

namespace LojaDeBrinquedos.Domain.Interfaces;
public interface IClienteService
{
    IEnumerable<Cliente> ObterTodosClientes();
    Cliente ObterClientePorId(int id);
    void AdicionarCliente(Cliente cliente);
    void AtualizarCliente(Cliente cliente);
    void RemoverCliente(int id);
}
