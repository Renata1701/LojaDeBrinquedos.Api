
namespace LojaDeBrinquedos.API.Models;

public class Cliente
{
    internal object CPF;
    internal DateTime DataCadastro;
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public Cliente(int id, string nome, string cpf, string email, string telefone, string endereco)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
    }
}
