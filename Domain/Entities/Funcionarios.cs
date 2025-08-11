namespace LojaDeBrinquedos.API.Domain.Entities;

public class Funcionarios
{
    internal DateTime DataAdmissao;
    internal object CPF;
    private int v1;
    private string v2;
    private string v3;
    private string v4;
    private string v5;

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

    public Funcionarios(int v1, string v2, string v3, string v4, string v5)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.v5 = v5;
    }
}
