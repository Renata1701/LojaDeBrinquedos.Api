
namespace LojaDeBrinquedos.API.Models;

public class Funcionarios
{
    internal DateTime DataAdmissao;
    internal object CPF;

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public Funcionarios(int id, string nome, string cpf, string email, string telefone, string endereco, string cargo, decimal salario)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        Cargo = cargo;
        Salario = salario;
    }
}
