using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Entities;
public class Pagamento
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataPagamento { get; set; }
    public string MetodoPagamento { get; set; } 
    public Pagamento(int id, int pedidoId, decimal valor, DateTime dataPagamento, string metodoPagamento)
    {
        Id = id;
        PedidoId = pedidoId;
        Valor = valor;
        DataPagamento = dataPagamento;
        MetodoPagamento = metodoPagamento;
    }

}
