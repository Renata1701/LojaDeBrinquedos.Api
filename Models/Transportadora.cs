﻿namespace LojaDeBrinquedos.API.Models;

public class Transportadora
{
 public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public string Fornecedor { get; set; }
    public Transportadora(int id, string nome, string telefone, string email, string endereco, string Fornecedor)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        Fornecedor = Fornecedor;
    }


}
