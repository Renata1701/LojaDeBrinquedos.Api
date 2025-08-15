using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Entities;
public class Frete
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataEnvio { get; set; }
    public string Transportadora { get; set; }
    public string Status { get; set; }
    public Frete(int id, int pedidoId, decimal valor, DateTime dataEnvio, string transportadora, string status)
    {
        Id = id;
        PedidoId = pedidoId;
        Valor = valor;
        DataEnvio = dataEnvio;
        Transportadora = transportadora;
        Status = status;
    }

}
