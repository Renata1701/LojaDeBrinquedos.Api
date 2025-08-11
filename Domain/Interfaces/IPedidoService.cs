using LojaDeBrinquedos.API.Domain.Entities;

namespace LojaDeBrinquedos.API.Domain.Interfaces;

public interface IPedidoService
{
    
    IEnumerable<Pedido> ObterTodosPedidos();
    Pedido ObterPedidoPorId(int id);
    void AdicionarPedido(Pedido pedido);
    void AtualizarPedido(Pedido pedido);
    void RemoverPedido(int id);
}
 


