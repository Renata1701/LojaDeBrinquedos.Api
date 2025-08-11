using LojaDeBrinquedos.API.Domain.Entities;
using LojaDeBrinquedos.API.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class PedidoService : IPedidoService
{
    private readonly string _connectionString;

    public PedidoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    private readonly List<Pedido> _pedidos;

    public PedidoService()
    {
        _pedidos = new List<Pedido>
        {
            new Pedido(1, 1, 1, DateTime.Now, 100.00m, "Pendente"),
            new Pedido(1, 1, DateTime.Now, 150.50m)
            {
                Id = 2,
                LojaId = 1,
                ClienteId = 2,
                Status = "Concluído"
            },
        };
    }

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

}
