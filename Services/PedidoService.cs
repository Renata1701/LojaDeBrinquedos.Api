using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class PedidoService
{
    private readonly List<Pedido> _pedidos = new();

    public List<Pedido> Listar() => _pedidos;

    public void CriarPedido(Pedido pedido) => _pedidos.Add(pedido);
}
