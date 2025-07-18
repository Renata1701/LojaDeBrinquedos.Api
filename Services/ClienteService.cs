using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class ClienteService
{
    private readonly List<Cliente> _clientes = new();

    public List<Cliente> Listar() => _clientes;

    public void Adicionar(Cliente cliente) => _clientes.Add(cliente);
}

