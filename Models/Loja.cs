namespace LojaDeBrinquedos.API.Models;

public class Loja
{
    internal object CNPJ;
    internal object Responsavel;

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public Loja(int id, string nome, string cnpj, string email, string telefone, string endereco)
    {
        Id = id;
        Nome = nome;
        Cnpj = cnpj;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
    }
}
