using LojaDeBrinquedos.Domain.Entities;
using LojaDeBrinquedos.Domain.Interfaces;

namespace LojaDeBrinquedos.API.Services;

public class ClienteService : IClienteService
{
    private readonly List<Cliente> _clientes;


    public IEnumerable<Cliente> ObterTodosClientes()
    {
        return _clientes;
    }

    public Cliente ObterClientePorId(int id)
    {
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public void AdicionarCliente(Cliente cliente)
    {
        if (cliente == null) throw new ArgumentNullException(nameof(cliente));
        if (_clientes.Any(c => c.Id == cliente.Id)) throw new InvalidOperationException("Cliente já existe.");
        _clientes.Add(cliente);
    }

    public void AtualizarCliente(Cliente cliente)
    {
        if (cliente == null) throw new ArgumentNullException(nameof(cliente));
        var existente = ObterClientePorId(cliente.Id);
        if (existente == null) throw new InvalidOperationException("Cliente não encontrado.");

        existente.Nome = cliente.Nome;
        existente.Telefone = cliente.Telefone;
        existente.Endereco = cliente.Endereco;
    }

    public void RemoverCliente(int id)
    {
        var cliente = ObterClientePorId(id);
        if (cliente == null) throw new InvalidOperationException("Cliente não encontrado.");
        _clientes.Remove(cliente);
    }

    public Task<Cliente> AdicionarAsync(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> AtualizarAsync(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cliente>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    IEnumerable<Cliente> IClienteService.ObterTodosClientes()
    {
        throw new NotImplementedException();
    }

    Cliente IClienteService.ObterClientePorId(int id)
    {
        throw new NotImplementedException();
    }

}


