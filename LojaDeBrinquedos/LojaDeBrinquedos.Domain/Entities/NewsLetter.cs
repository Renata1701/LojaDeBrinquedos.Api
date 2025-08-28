using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class NewsLetter
{
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Ativo";
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
}
