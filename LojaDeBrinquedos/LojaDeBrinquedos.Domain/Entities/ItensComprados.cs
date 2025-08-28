using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class ItensComprados
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int CompraEstoqueId { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    // Navegação
    public virtual Pedido Pedido { get; set; } = null!;
    public virtual Produto Produto { get; set; } = null!;
}
