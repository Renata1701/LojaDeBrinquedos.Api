using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class Pagamento
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
    public string Metodo { get; set; } = string.Empty;
    public string Status { get; set; } = "Pendente";
    public DateTime DataPagamento { get; set; } = DateTime.Now;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    // Navegação
    public virtual Pedido Pedido { get; set; } = null!;
}
