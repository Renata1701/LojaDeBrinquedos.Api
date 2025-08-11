using System.Text.Json.Serialization;

namespace LojaDeBrinquedos.API.Domain.Entities;
using System.Text.Json.Serialization;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public int V1 { get; set; }
    public string V2 { get; set; }
    public string V3 { get; set; }
    public string V4 { get; set; }

    public Fornecedor() { }

  
    [JsonConstructor]
    public Fornecedor(int id, string nome, string cnpj, string email, string telefone, string endereco)
    {
        Id = id;
        Nome = nome;
        Cnpj = cnpj;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
    }
}
