namespace LojaDeBrinquedos.Domain.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    
    // Construtor padrão
    public Categoria() { }
    
    public Categoria(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }
}
