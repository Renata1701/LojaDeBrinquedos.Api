using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class Loja
{
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    public string Endereco { get; set; } = string.Empty;
    
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Cnpj { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    // Propriedades adicionais
    public string? Responsavel { get; set; }
    public TimeSpan? HorarioAbertura { get; set; }
    public TimeSpan? HorarioFechamento { get; set; }
}
