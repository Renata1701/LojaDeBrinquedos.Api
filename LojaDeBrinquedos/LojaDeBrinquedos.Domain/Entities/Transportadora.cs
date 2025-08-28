using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class Transportadora
{
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    public string Telefone { get; set; } = string.Empty;
    
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    public string? Endereco { get; set; }
    public string? CNPJ { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
