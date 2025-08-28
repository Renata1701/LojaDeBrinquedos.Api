using System.ComponentModel.DataAnnotations;

namespace LojaDeBrinquedos.Domain.Entities;

public class ProgramaFidelidade
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int Pontos { get; set; }
    public string Nivel { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    // Propriedades adicionais baseadas no controller
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int PontosNecessarios { get; set; }
    
    // Navegação
    public virtual Cliente Cliente { get; set; } = null!;
}
