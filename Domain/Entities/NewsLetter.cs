namespace LojaDeBrinquedos.API.Domain.Entities;

public class NewsLetter
{
    internal object Status;

    public int Id { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public NewsLetter(int id, string email, string nome, string telefone, string endereco)
    {
        Id = id;
        Email = email;
        Nome = nome;
        Telefone = telefone;
        Endereco = endereco;
    }
}
