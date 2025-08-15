using LojaDeBrinquedos.Domain.Entities;
using LojaDeBrinquedos.Domain.Interfaces;

namespace LojaDeBrinquedos.API.Services;

public class PedidoService : IPedidoService
{
    private readonly string _connectionString;

    public PedidoService(IConfiguration configuration)
    {
        _connectionString = configuration.ConnectionString("MinhaConexaoSQL");
    }

    private readonly List<Pedido> _pedidos;


    public IEnumerable<Pedido> ObterTodosPedidos()
    {
        return _pedidos;
    }

    public Pedido ObterPedidoPorId(int id)
    {
        return _pedidos.FirstOrDefault(p => p.Id == id);
    }

    public void AdicionarPedido(Pedido pedido)
    {
        if (pedido == null) throw new ArgumentNullException(nameof(pedido));
        if (_pedidos.Any(p => p.Id == pedido.Id)) throw new InvalidOperationException("Pedido já existe.");

        _pedidos.Add(pedido);
    }

    public void AtualizarPedido(Pedido pedido)
    {
        if (pedido == null) throw new ArgumentNullException(nameof(pedido));
        var existingPedido = ObterPedidoPorId(pedido.Id);
        if (existingPedido == null) throw new InvalidOperationException("Pedido não encontrado.");

        existingPedido.ClienteId = pedido.ClienteId;
    }

    public void RemoverPedido(int id)
    {
        var pedido = ObterPedidoPorId(id);
        if (pedido == null) throw new InvalidOperationException("Pedido não encontrado.");

        _pedidos.Remove(pedido);
    }

    public IEnumerable<Pedido> ListarPedidos()
    {
        throw new NotImplementedException();
    }

    public Pedido BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void Criar(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pedido>> ListarPedidosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Pedido> BuscarPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CriarAsync(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarAsync(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public Task ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }

    public interface IConfiguration
    {
        string? ConnectionString(string v);
    }
}
