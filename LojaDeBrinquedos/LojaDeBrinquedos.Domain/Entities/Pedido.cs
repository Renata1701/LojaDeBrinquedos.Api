using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Entities;
public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public string Status { get; set; } 
    public Pedido(int id, int clienteId, DateTime dataPedido, decimal valorTotal, string status)
    {
        Id = id;
        ClienteId = clienteId;
        DataPedido = dataPedido;
        ValorTotal = valorTotal;
        Status = status;
    }
}
