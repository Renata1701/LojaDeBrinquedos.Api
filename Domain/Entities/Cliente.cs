namespace LojaDeBrinquedos.API.Domain.Entities;

public class Cliente
{
    internal object CPF;
    internal DateTime DataCadastro;
    private string v1;
    private string v2;

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

    public Cliente(int id, string nome, string cpf, string email, string telefone, string endereco, string v1, string v2) : this(id, nome, cpf, email, telefone, endereco)
    {
        this.v1 = v1;
        this.v2 = v2;
    }
}
