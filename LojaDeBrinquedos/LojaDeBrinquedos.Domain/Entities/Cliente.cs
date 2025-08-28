using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    public string CPF { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Endereco { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;
    
    // Navegação
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    public virtual ICollection<ProgramaFidelidade> ProgramasFidelidade { get; set; } = new List<ProgramaFidelidade>();
}



