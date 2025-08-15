using LojaDeBrinquedos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Interfaces;
public interface IPedidoService
{
    IEnumerable<Pedido> ListarPedidos();
    Pedido BuscarPorId(int id);
    void Criar(Pedido pedido);
    void Atualizar(Pedido pedido);
    void Excluir(int id);
    Task<IEnumerable<Pedido>> ListarPedidosAsync();
    Task<Pedido> BuscarPorIdAsync(int id);
    Task CriarAsync(Pedido pedido);
    Task AtualizarAsync(Pedido pedido);
    Task ExcluirAsync(int id);
}
