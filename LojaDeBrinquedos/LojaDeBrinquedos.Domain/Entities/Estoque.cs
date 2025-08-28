using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class Estoque
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public int QuantidadeMinima { get; set; }
    public string Localizacao { get; set; } = string.Empty;
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    
    // Navegação
    public virtual Produto Produto { get; set; } = null!;
}
