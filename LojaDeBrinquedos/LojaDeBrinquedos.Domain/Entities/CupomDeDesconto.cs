using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class CupomDeDesconto
{
    public int Id { get; set; }
    
    [Required]
    public string Codigo { get; set; } = string.Empty;
    
    [Required]
    public decimal ValorDesconto { get; set; }
    
    public DateTime DataValidade { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    // Propriedades adicionais
    public string? Descricao { get; set; }
    public int? PercentualDesconto { get; set; }
    public decimal? ValorMinimoCompra { get; set; }
}
